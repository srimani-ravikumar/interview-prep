# Windows IPC — Named Pipe Example (C)

## Project overview

This small-scale project demonstrates Inter-Process Communication (IPC) on **Windows** using **Named Pipes** plus a simple synchronization primitive (a named Mutex). It shows a `parent` process spawning a `child` process. The parent sends a message to the child through a Named Pipe. The child reads it, processes the message (converts text to uppercase and appends a timestamp), then sends a reply back to the parent through another Named Pipe. Both processes print informative console output to demonstrate the full communication flow.

This project is written in plain C using the Win32 API and is intended to be compiled with MinGW/GCC on Windows.

## IPC concepts used

- Named Pipes (two pipes: `\\.\pipe\ParentToChild` and `\\.\pipe\ChildToParent`)
- Process creation using `CreateProcess` (parent spawns the child)
- Synchronization using a named Mutex to demonstrate a shared synchronization primitive (ensures only one writer at a time to a shared log file or console section)
- Blocking I/O on pipes with simple error handling

## Files

- `main.c` — parent (driver): creates pipes, spawns child, writes request, reads reply
- `child.c` — child: connects to parent's pipe, reads request, processes, writes reply
- `ipc_utils.h` / `ipc_utils.c` — helper functions for creating/connecting named pipes and read/write wrappers
- `Makefile` — convenience file to build with `mingw32-gcc` / `gcc` on Windows

## How to compile (MinGW / GCC)

Open a MinGW-w64 shell (or any environment with gcc that targets Windows) and run:

```bash
gcc -o parent.exe main.c ipc_utils.c -lws2_32 -static -O2
gcc -o child.exe child.c ipc_utils.c -lws2_32 -static -O2

```

> Note: -lws2_32 is harmless here though we don't use Winsock; adjust flags to fit your toolchain. If you use Microsoft Visual C (cl.exe), open a Developer Command Prompt and compile accordingly.
> 

Alternatively use the provided Makefile:

```bash
make all

```

## How to run

Simply run the parent executable. The parent will spawn the child automatically.

```bash
parent.exe

```

You should see console output from both parent and child (parent prints what it sent and the reply; child prints what it received and what it replied).

## Example output

```
[Parent] Created pipes, spawning child...
[Parent] Sent: Hello Child, time for IPC!
[Child] Connected to pipe, received: Hello Child, time for IPC!
[Child] Processed and sent reply: HELLO CHILD, TIME FOR IPC! [Processed at 2025-10-20 13:00:12]
[Parent] Received reply: HELLO CHILD, TIME FOR IPC! [Processed at 2025-10-20 13:00:12]
[Parent] Cleaning up and exiting.

```

## Notes and extension ideas

- Add a shared memory region (CreateFileMapping / MapViewOfFile) to share a large buffer between processes.
- Add message framing or structured messages (length-prefixed). The current demo uses fixed-size buffers and simple framing.
- Add more robust error recovery, retries, and timeouts when connecting to pipes.