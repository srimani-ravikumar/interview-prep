// main.c
// Parent process: creates two named pipes (Parent->Child and Child->Parent), spawns child process,
// sends a message, waits for reply, prints result, cleans up.

#include <windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "ipc_utils.h"

#define PIPE_NAME_PARENT_TO_CHILD "\\\\.\\pipe\\ParentToChildPipe"
#define PIPE_NAME_CHILD_TO_PARENT "\\\\.\\pipe\\ChildToParentPipe"
#define MUTEX_NAME "Global\\MyIpcMutex"
#define BUFFER_SIZE 1024

int main(void) {
    HANDLE hPipeParentToChild = INVALID_HANDLE_VALUE;
    HANDLE hPipeChildToParent = INVALID_HANDLE_VALUE;
    HANDLE hMutex = NULL;
    STARTUPINFO si;
    PROCESS_INFORMATION pi;
    char writeBuf[BUFFER_SIZE];
    char readBuf[BUFFER_SIZE];
    DWORD bytesRead = 0, bytesWritten = 0;
    BOOL success;

    printf("[Parent] Starting IPC demo (Named Pipes)\n");

    // Create a named mutex for demonstration of synchronization (not strictly necessary here)
    hMutex = CreateMutexA(NULL, FALSE, MUTEX_NAME);
    if (!hMutex) {
        fprintf(stderr, "[Parent] CreateMutex failed: %lu\n", GetLastError());
        // Not fatal for this demo — continue
    }

    // Create the two named pipes (server ends)
    hPipeParentToChild = create_named_pipe(PIPE_NAME_PARENT_TO_CHILD, BUFFER_SIZE);
    if (hPipeParentToChild == INVALID_HANDLE_VALUE) goto cleanup;

    hPipeChildToParent = create_named_pipe(PIPE_NAME_CHILD_TO_PARENT, BUFFER_SIZE);
    if (hPipeChildToParent == INVALID_HANDLE_VALUE) goto cleanup;

    // Prepare to spawn child process
    ZeroMemory(&si, sizeof(si)); si.cb = sizeof(si);
    ZeroMemory(&pi, sizeof(pi));

    printf("[Parent] Created pipes, spawning child...\n");

    // Spawn the child process (assumes child.exe is in same directory)
    if (!CreateProcessA(NULL, "child.exe", NULL, NULL, FALSE, 0, NULL, NULL, &si, &pi)) {
        fprintf(stderr, "[Parent] CreateProcess failed: %lu\n", GetLastError());
        goto cleanup;
    }

    // Wait for child to connect to both pipes
    printf("[Parent] Waiting for child to connect to pipes...\n");
    if (!connect_named_pipe(hPipeParentToChild)) {
        fprintf(stderr, "[Parent] Failed waiting for client on ParentToChild pipe\n");
        goto cleanup;
    }
    if (!connect_named_pipe(hPipeChildToParent)) {
        fprintf(stderr, "[Parent] Failed waiting for client on ChildToParent pipe\n");
        goto cleanup;
    }

    // Compose message and write to child
    snprintf(writeBuf, BUFFER_SIZE, "Hello Child, time for IPC!");

    // Demonstrate mutex usage around the write (not strictly necessary, but educational)
    WaitForSingleObject(hMutex, INFINITE);
    success = write_pipe(hPipeParentToChild, writeBuf, (DWORD)strlen(writeBuf) + 1, &bytesWritten);
    ReleaseMutex(hMutex);

    if (!success) {
        fprintf(stderr, "[Parent] Failed to write to pipe\n");
        goto cleanup;
    }

    printf("[Parent] Sent: %s\n", writeBuf);

    // Read reply from child
    success = read_pipe(hPipeChildToParent, readBuf, BUFFER_SIZE, &bytesRead);
    if (!success) {
        fprintf(stderr, "[Parent] Failed to read reply from child\n");
        goto cleanup;
    }

    printf("[Parent] Received reply: %s\n", readBuf);

    // Wait for child to exit
    WaitForSingleObject(pi.hProcess, INFINITE);

    printf("[Parent] Child exited. Cleaning up and exiting.\n");

cleanup:
    if (hPipeParentToChild != INVALID_HANDLE_VALUE) CloseHandle(hPipeParentToChild);
    if (hPipeChildToParent != INVALID_HANDLE_VALUE) CloseHandle(hPipeChildToParent);
    if (hMutex) CloseHandle(hMutex);
    if (pi.hProcess) CloseHandle(pi.hProcess);
    if (pi.hThread) CloseHandle(pi.hThread);
    return 0;
}
