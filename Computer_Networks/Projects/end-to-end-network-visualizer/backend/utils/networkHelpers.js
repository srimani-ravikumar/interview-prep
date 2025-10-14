// utils/networkHelpers.js

// Check if TTL > 0
function isTTLValid(packet) {
  return packet.header.TTL > 0;
}

// Verify checksum
function verifyChecksum(packet) {
  const computed = packet.data
    .split('')
    .reduce((sum, ch) => sum + ch.charCodeAt(0), 0) % 256;
  return computed === packet.header.checksum;
}

// Drop packet based on probability
function maybeDropPacket(packet, dropProb = 0.1) {
  if (Math.random() < dropProb) {
    packet.status = 'Dropped';
    return true;
  }
  return false;
}

// Simple logging
function logPacket(packet, nodeName) {
  console.log(`[${nodeName}] Packet ${packet.seq} | Status: ${packet.status} | TTL: ${packet.header.TTL}`);
}

module.exports = { isTTLValid, verifyChecksum, maybeDropPacket, logPacket };
