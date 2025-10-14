class Receiver {
  receive(packet) {
    packet.currentNode = "Receiver";
    packet.status = "delivered";
    console.log(`Packet ${packet.id} delivered at Receiver`);
  }
}

module.exports = Receiver;
