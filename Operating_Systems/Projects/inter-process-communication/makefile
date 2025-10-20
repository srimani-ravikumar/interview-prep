# Makefile for MinGW / gcc on Windows
CC=gcc
CFLAGS=-O2 -Wall

all: parent.exe child.exe

parent.exe: main.c ipc_utils.c ipc_utils.h
	$(CC) $(CFLAGS) -o parent.exe main.c ipc_utils.c

child.exe: child.c ipc_utils.c ipc_utils.h
	$(CC) $(CFLAGS) -o child.exe child.c ipc_utils.c

clean:
	del parent.exe child.exe 2>nul || rm -f parent.exe child.exe

.PHONY: all clean
