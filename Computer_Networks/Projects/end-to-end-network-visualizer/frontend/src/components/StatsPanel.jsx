import React from 'react';

export default function StatsPanel({ packets }) {
  const total = packets.length;
  const dropped = packets.filter(p => p.status === 'Dropped').length;
  const retransmitted = packets.filter(p => p.status === 'Retransmitted').length;

  return (
    <div>
      <p>Total Packets: {total}</p>
      <p>Dropped: {dropped}</p>
      <p>Retransmitted: {retransmitted}</p>
    </div>
  );
}
