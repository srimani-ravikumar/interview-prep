const EventEmitter = require('events');

class Sender extends EventEmitter {
  constructor() {
    super();
    this.packetId = 1;
  }

  sendPacket() {
    const packet = {
      id: this.packetId++,
      protocol: "TCP",
      source: "Sender",
      destination: "Receiver",
      status: "in-transit",
      currentNode: "Sender"
    };
    this.emit('send', packet);
  }
}

module.exports = Sender;
