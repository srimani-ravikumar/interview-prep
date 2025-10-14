import React, { useEffect, useState } from 'react';
import NetworkNode from './NetworkNode';
import useWebSocket from '../utils/useWebSocket';

export default function PacketVisualizer() {
  const messages = useWebSocket('ws://localhost:5000');
  const [packets, setPackets] = useState([]);

  useEffect(() => {
    const latestPackets = messages.filter(m => m.event === 'packetUpdate');
    if (latestPackets.length > 0) setPackets(latestPackets.map(p => p.packet));
  }, [messages]);

  return (
    <svg width="800" height="400">
      <NetworkNode name="Sender" x={100} y={200} />
      <NetworkNode name="Router" x={300} y={200} />
      <NetworkNode name="Server" x={500} y={200} />
      <NetworkNode name="Receiver" x={700} y={200} />
      {packets.map((packet, idx) => (
        <circle key={idx} cx={100 + packet.seq * 20} cy={200} r="10" fill={packet.status === 'Dropped' ? 'red' : 'green'} />
      ))}
    </svg>
  );
}
