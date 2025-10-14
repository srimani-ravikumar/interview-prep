const express = require('express');
const http = require('http');
const WebSocket = require('ws');

const app = express();
const server = http.createServer(app);
const wss = new WebSocket.Server({ server });

wss.on('connection', (ws) => {
  console.log('Client connected');

  ws.on('message', (message) => {
    const packet = JSON.parse(message);
    console.log('Received packet:', packet);
    // TODO: Process packet
    ws.send(JSON.stringify({ event: 'packetUpdate', packet }));
  });

  ws.on('close', () => console.log('Client disconnected'));
});

server.listen(5000, () => console.log('Server running on port 5000'));
