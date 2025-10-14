// server.js
const express = require('express');
const http = require('http');
const WebSocket = require('ws');
const Sender = require('./simulation/sender');
const Router = require('./simulation/router');
const ServerNode = require('./simulation/serverNode');
const Receiver = require('./simulation/receiver');

const app = express();
const server = http.createServer(app);
const wss = new WebSocket.Server({ server });

wss.on('connection', (ws) => {
    console.log('Client connected');

    const sender = new Sender(ws);
    const router = new Router();
    const serverNode = new ServerNode();
    const receiver = new Receiver(ws);

    ws.on('message', (msg) => {
        const data = JSON.parse(msg);

        if (data.event === 'sendMessage') {
            // Send each packet through full pipeline
            sender.sendMessage(data.message, (packet) => {
                // Packet goes through Router
                let routed = router.forward(packet);
                if (!routed) {
                    ws.send(JSON.stringify({ event: 'packetUpdate', packet })); // Dropped
                    return;
                }

                // Process at Server
                let processed = serverNode.process(routed);

                // Receive at Receiver (sends ACK)
                receiver.receive(processed);

                // Send updated packet status to frontend
                ws.send(JSON.stringify({ event: 'packetUpdate', packet: processed }));
            });
        } else if (data.event === 'ACK') {
            sender.handleACK(data.seq);
        }
    });

    ws.on('close', () => console.log('Client disconnected'));
});


server.listen(5000, () => console.log('Server running on port 5000'));
