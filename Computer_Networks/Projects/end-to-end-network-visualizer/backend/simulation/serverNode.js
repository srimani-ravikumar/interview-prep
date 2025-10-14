// simulation/serverNode.js
class ServerNode {
  process(packet) {
    packet.status = 'Processed';
    return packet;
  }
}

module.exports = ServerNode;
