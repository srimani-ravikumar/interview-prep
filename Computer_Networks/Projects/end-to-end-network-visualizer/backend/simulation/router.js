// simulation/router.js
const { maybeDropPacket, isTTLValid, logPacket } = require('../utils/networkHelpers');

class Router {
  forward(packet) {
    if (!isTTLValid(packet)) {
      packet.status = 'Dropped';
      logPacket(packet, 'Router');
      return null;
    }

    if (maybeDropPacket(packet)) {
      logPacket(packet, 'Router');
      return null;
    }

    packet.header.TTL--;
    packet.status = 'Forwarded';
    logPacket(packet, 'Router');
    return packet;
  }
}

module.exports = Router;
