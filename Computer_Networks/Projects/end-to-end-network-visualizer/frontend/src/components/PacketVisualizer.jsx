import NetworkNode from '../components/NetworkNode';

export default function PacketVisualizer({ packets }) {
  return (
    <svg width="800" height="400">
      <NetworkNode name="Sender" x={100} y={200} />
      <NetworkNode name="Router" x={300} y={200} />
      <NetworkNode name="Server" x={500} y={200} />
      <NetworkNode name="Receiver" x={700} y={200} />

      {packets.map((packet, idx) => (
        <circle
          key={idx}
          cx={100 + (packet.seq * 50 % 600)} 
          cy={200}
          r="10"
          fill={
            packet.status === 'Dropped'
              ? 'red'
              : packet.status === 'Retransmitted'
              ? 'yellow'
              : 'green'
          }
          title={`Seq:${packet.seq} TTL:${packet.header.TTL} Status:${packet.status}`}
        />
      ))}
    </svg>
  );
}
