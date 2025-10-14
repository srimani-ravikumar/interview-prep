class Receiver {
  constructor(ws) {
    this.ws = ws;
    this.receivedPackets = [];
  }

  receive(packet) {
    packet.status = 'Received';
    this.receivedPackets.push(packet);
    // Send ACK to sender
    this.ws.send(JSON.stringify({ event: 'ACK', seq: packet.seq }));
  }
}

module.exports = Receiver;
