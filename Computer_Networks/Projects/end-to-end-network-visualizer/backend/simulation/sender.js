const Packet = require('./packet');

class Sender {
  constructor(ws) {
    this.ws = ws;
    this.seqNum = 1;
  }

  sendMessage(message) {
    const packets = message.split(' ').map(word => {
      const packet = new Packet(this.seqNum++, word);
      this.ws.send(JSON.stringify(packet));
      return packet;
    });
    return packets;
  }
}

module.exports = Sender;
