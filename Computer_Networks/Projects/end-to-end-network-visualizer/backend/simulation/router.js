function maybeDropPacket(packet, dropProb = 0.1) {
  if (Math.random() < dropProb) {
    packet.status = 'Dropped';
    return true;
  }
  return false;
}

class Router {
  forward(packet) {
    if (maybeDropPacket(packet)) return null;
    packet.header.TTL--;
    packet.status = 'Forwarded';
    return packet;
  }
}

module.exports = Router;
