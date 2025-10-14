const WebSocket = require('ws');
const Sender = require('./simulation/sender');
const Router = require('./simulation/router');
const Receiver = require('./simulation/receiver');

const wss = new WebSocket.Server({ port: 8080 });
console.log("WebSocket server running on ws://localhost:8080");

function broadcast(packet) {
  wss.clients.forEach(client => {
    if (client.readyState === WebSocket.OPEN) {
      client.send(JSON.stringify(packet));
    }
  });
}

// Setup network
const sender = new Sender();
const router1 = new Router("Router 1");
const router2 = new Router("Router 2");
const receiver = new Receiver();

// Connect nodes
sender.on('send', packet => router1.forwardPacket(packet));
router1.on('forward', packet => router2.forwardPacket(packet));
router1.on('drop', packet => broadcast(packet));

router2.on('forward', packet => {
  receiver.receive(packet);
  broadcast(packet);
});
router2.on('drop', packet => broadcast(packet));

// Send packets every second
setInterval(() => sender.sendPacket(), 1000);
