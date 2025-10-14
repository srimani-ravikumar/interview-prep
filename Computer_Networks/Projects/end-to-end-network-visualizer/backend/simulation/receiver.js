// simulation/receiver.js
const { verifyChecksum, logPacket } = require('../utils/networkHelpers');

class Receiver {
    constructor(ws) {
        this.ws = ws;
        this.receivedPackets = [];
    }

    receive(packet) {
        if (!verifyChecksum(packet)) packet.status = 'Corrupted';
        else packet.status = 'Received';

        this.receivedPackets.push(packet);

        // Send ACK back to sender
        this.ws.send(JSON.stringify({ event: 'ACK', seq: packet.seq }));

        logPacket(packet, 'Receiver');
    }

}

module.exports = Receiver;
