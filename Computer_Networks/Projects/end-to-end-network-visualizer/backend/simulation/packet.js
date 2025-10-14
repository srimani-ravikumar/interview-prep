class Packet {
  constructor(seq, data, protocol = 'TCP') {
    this.seq = seq;
    this.data = data;
    this.protocol = protocol;
    this.header = {
      sourceIP: '192.168.1.1',
      destIP: '192.168.1.2',
      TTL: 64,
      checksum: null,
    };
    this.status = 'Created'; // Created, Sent, Dropped, Received
  }
}

module.exports = Packet;
