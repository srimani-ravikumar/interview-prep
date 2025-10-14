// simulation/sender.js
const Packet = require('./packet');

class Sender {
    constructor(ws, protocol = 'TCP') {
        this.ws = ws;
        this.seqNum = 1;
        this.sentPackets = {};
        this.protocol = protocol;
    }

    sendMessage(message, processCallback) {
        const words = message.split(' ');
        words.forEach(word => {
            const packet = new Packet(this.seqNum++, word, this.protocol);
            this.sentPackets[packet.seq] = packet;
            // Trigger processing in callback
            if (processCallback) processCallback(packet);

            // TCP retransmission timer
            if (packet.protocol === 'TCP') {
                packet.timer = setTimeout(() => {
                    if (packet.status !== 'Received') {
                        packet.status = 'Retransmitted';
                        if (processCallback) processCallback(packet);
                    }
                }, 2000);
            }
        });
    }


    sendPacket(packet) {
        packet.status = 'Sent';
        let routedPacket = router.forward(packet);
        if (!routedPacket) {
            // Packet dropped in router
            this.ws.send(JSON.stringify({ event: 'packetUpdate', packet }));
            return;
        }

        routedPacket = serverNode.process(routedPacket);
        receiver.receive(routedPacket);

        // Send updated packet status to frontend
        this.ws.send(JSON.stringify({ event: 'packetUpdate', packet: routedPacket }));

        // TCP retransmission
        if (packet.protocol === 'TCP' && packet.status !== 'Received') {
            packet.timer = setTimeout(() => this.sendPacket(packet), 2000);
        }
    }


    handleACK(seq) {
        const packet = this.sentPackets[seq];
        if (packet && packet.timer) clearTimeout(packet.timer);
        if (packet) packet.status = 'Received';
    }
}

module.exports = Sender;
