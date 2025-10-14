const EventEmitter = require('events');

class Router extends EventEmitter {
  constructor(name) {
    super();
    this.name = name;
  }

  forwardPacket(packet) {
    packet.currentNode = this.name;
    const delay = Math.random() * 1000; // 0-1s delay
    setTimeout(() => {
      if (Math.random() < 0.1) { // 10% packet drop
        packet.status = "dropped";
        this.emit('drop', packet);
        console.log(`Packet ${packet.id} dropped at ${this.name}`);
        return;
      }
      console.log(`Packet ${packet.id} forwarded by ${this.name}`);
      this.emit('forward', packet);
    }, delay);
  }
}

module.exports = Router;
