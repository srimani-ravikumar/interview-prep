// ipc_utils.c
// Implementations for simple named pipe helpers with error-checking.

#include "ipc_utils.h"
#include <windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// Create a named pipe server end with default settings. Returns INVALID_HANDLE_VALUE on error.
HANDLE create_named_pipe(const char *pipe_name, DWORD buffer_size) {
    // Convert const char * (ANSI) to LPSTR - API accepts LPCSTR for ANSI functions
    HANDLE hPipe = CreateNamedPipeA(
        pipe_name,                      // pipe name
        PIPE_ACCESS_DUPLEX,             // read/write access
        PIPE_TYPE_MESSAGE |             // message-type pipe
        PIPE_READMODE_MESSAGE |         // message-read mode
        PIPE_WAIT,                      // blocking mode
        1,                              // max. instances
        buffer_size,                    // out buffer size
        buffer_size,                    // in buffer size
        0,                              // default timeout
        NULL);                          // default security

    if (hPipe == INVALID_HANDLE_VALUE) {
        fprintf(stderr, "[ipc_utils] CreateNamedPipeA failed for %s : %lu\n", pipe_name, GetLastError());
    }
    return hPipe;
}

// Wait for a client to connect to the server-end pipe. Returns TRUE on success.
BOOL connect_named_pipe(HANDLE hPipe) {
    if (hPipe == INVALID_HANDLE_VALUE) return FALSE;
    BOOL connected = ConnectNamedPipe(hPipe, NULL) ? TRUE : (GetLastError() == ERROR_PIPE_CONNECTED);
    if (!connected) {
        fprintf(stderr, "[ipc_utils] ConnectNamedPipe failed: %lu\n", GetLastError());
    }
    return connected;
}

// Client side: open an existing named pipe. Retries until success or error.
HANDLE open_named_pipe_client(const char *pipe_name) {
    HANDLE hPipe = INVALID_HANDLE_VALUE;
    while (1) {
        hPipe = CreateFileA(
            pipe_name,                  // pipe name
            GENERIC_READ | GENERIC_WRITE,// read and write access
            0,                          // no sharing
            NULL,                       // default security attributes
            OPEN_EXISTING,              // opens existing pipe
            0,                          // default attributes
            NULL);                      // no template file

        if (hPipe != INVALID_HANDLE_VALUE) break;

        DWORD err = GetLastError();
        if (err != ERROR_PIPE_BUSY && err != ERROR_FILE_NOT_FOUND) {
            fprintf(stderr, "[ipc_utils] CreateFileA failed for %s : %lu\n", pipe_name, err);
            return INVALID_HANDLE_VALUE;
        }
        // Wait for pipe to become available
        if (!WaitNamedPipeA(pipe_name, 5000)) { // wait up to 5 seconds
            fprintf(stderr, "[ipc_utils] WaitNamedPipeA timeout or failed for %s : %lu\n", pipe_name, GetLastError());
            return INVALID_HANDLE_VALUE;
        }
    }
    return hPipe;
}

// Write buffer to pipe, returns TRUE on success
BOOL write_pipe(HANDLE hPipe, const void *buffer, DWORD bytesToWrite, DWORD *bytesWritten) {
    if (hPipe == INVALID_HANDLE_VALUE) return FALSE;
    if (!WriteFile(hPipe, buffer, bytesToWrite, bytesWritten, NULL)) {
        fprintf(stderr, "[ipc_utils] WriteFile failed: %lu\n", GetLastError());
        return FALSE;
    }
    return TRUE;
}

// Read from pipe into buffer. On success, *bytesRead contains the number of bytes read.
BOOL read_pipe(HANDLE hPipe, void *buffer, DWORD bufferSize, DWORD *bytesRead) {
    if (hPipe == INVALID_HANDLE_VALUE) return FALSE;
    if (!ReadFile(hPipe, buffer, bufferSize, bytesRead, NULL)) {
        fprintf(stderr, "[ipc_utils] ReadFile failed: %lu\n", GetLastError());
        return FALSE;
    }
    return TRUE;
}
