// simulation/packet.js
class Packet {
  constructor(seq, data, protocol = 'TCP') {
    this.seq = seq;
    this.data = data;
    this.protocol = protocol;
    this.header = {
      sourceIP: '192.168.1.1',
      destIP: '192.168.1.2',
      TTL: 64,
      checksum: this.computeChecksum(data),
    };
    this.status = 'Created'; // Created, Sent, Forwarded, Dropped, Received, Retransmitted
  }

  computeChecksum(data) {
    return data.split('').reduce((sum, ch) => sum + ch.charCodeAt(0), 0) % 256;
  }
}

module.exports = Packet;
