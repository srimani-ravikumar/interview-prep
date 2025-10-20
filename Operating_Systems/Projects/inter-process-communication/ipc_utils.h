// ipc_utils.h
// Helper declarations for named-pipe based IPC
#ifndef IPC_UTILS_H
#define IPC_UTILS_H

#include <windows.h>

HANDLE create_named_pipe(const char *pipe_name, DWORD buffer_size);
BOOL connect_named_pipe(HANDLE hPipe);
HANDLE open_named_pipe_client(const char *pipe_name);
BOOL write_pipe(HANDLE hPipe, const void *buffer, DWORD bytesToWrite, DWORD *bytesWritten);
BOOL read_pipe(HANDLE hPipe, void *buffer, DWORD bufferSize, DWORD *bytesRead);

#endif // IPC_UTILS_H
