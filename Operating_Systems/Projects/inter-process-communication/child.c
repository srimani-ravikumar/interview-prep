// child.c
// Child process: connects to the named pipes created by parent, reads a message, processes it,
// and replies back. Demonstrates ConvertToUpper + append timestamp.

#include <windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include "ipc_utils.h"

#define PIPE_NAME_PARENT_TO_CHILD "\\\\.\\pipe\\ParentToChildPipe"
#define PIPE_NAME_CHILD_TO_PARENT "\\\\.\\pipe\\ChildToParentPipe"
#define MUTEX_NAME "Global\\MyIpcMutex"
#define BUFFER_SIZE 1024

// Simple helper to uppercase a string in place
void to_uppercase(char *s) {
    for (; *s; ++s) {
        if (*s >= 'a' && *s <= 'z') *s = (char)(*s - ('a' - 'A'));
    }
}

int main(void) {
    HANDLE hPipeRead = INVALID_HANDLE_VALUE;
    HANDLE hPipeWrite = INVALID_HANDLE_VALUE;
    HANDLE hMutex = NULL;
    char readBuf[BUFFER_SIZE];
    char writeBuf[BUFFER_SIZE];
    DWORD bytesRead = 0, bytesWritten = 0;
    BOOL success;

    printf("[Child] Child started, attempting to connect to pipes...\n");

    // Open the named mutex if exists (optional)
    hMutex = OpenMutexA(MUTEX_ALL_ACCESS, FALSE, MUTEX_NAME);
    // If it fails it's not fatal — parent may have created it as part of demo

    // Connect to the pipes (client side)
    hPipeRead = open_named_pipe_client(PIPE_NAME_PARENT_TO_CHILD);
    if (hPipeRead == INVALID_HANDLE_VALUE) goto cleanup;

    hPipeWrite = open_named_pipe_client(PIPE_NAME_CHILD_TO_PARENT);
    if (hPipeWrite == INVALID_HANDLE_VALUE) goto cleanup;

    // Read message from parent
    success = read_pipe(hPipeRead, readBuf, BUFFER_SIZE, &bytesRead);
    if (!success) {
        fprintf(stderr, "[Child] Failed to read from parent pipe\n");
        goto cleanup;
    }

    printf("[Child] Received: %s\n", readBuf);

    // Process message: uppercase + append timestamp
    to_uppercase(readBuf);
    time_t t = time(NULL);
    struct tm tm;
    localtime_s(&tm, &t);
    char timestamp[64];
    strftime(timestamp, sizeof(timestamp), "%Y-%m-%d %H:%M:%S", &tm);

    snprintf(writeBuf, BUFFER_SIZE, "%s [Processed at %s]", readBuf, timestamp);

    // Write reply under mutex protection (demonstration only)
    if (hMutex) WaitForSingleObject(hMutex, INFINITE);
    success = write_pipe(hPipeWrite, writeBuf, (DWORD)strlen(writeBuf) + 1, &bytesWritten);
    if (hMutex) ReleaseMutex(hMutex);

    if (!success) {
        fprintf(stderr, "[Child] Failed to write reply to parent\n");
        goto cleanup;
    }

    printf("[Child] Sent reply: %s\n", writeBuf);

cleanup:
    if (hPipeRead != INVALID_HANDLE_VALUE) CloseHandle(hPipeRead);
    if (hPipeWrite != INVALID_HANDLE_VALUE) CloseHandle(hPipeWrite);
    if (hMutex) CloseHandle(hMutex);
    return 0;
}
