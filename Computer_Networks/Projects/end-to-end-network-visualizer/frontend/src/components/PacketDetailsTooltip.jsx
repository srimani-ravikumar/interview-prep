import React from 'react';

export default function PacketDetailsTooltip({ packet }) {
  if (!packet) return null;
  return (
    <div style={{ position: 'absolute', background: '#fff', border: '1px solid #000', padding: '5px' }}>
      <p>Seq: {packet.seq}</p>
      <p>Data: {packet.data}</p>
      <p>Protocol: {packet.protocol}</p>
      <p>TTL: {packet.header.TTL}</p>
      <p>Status: {packet.status}</p>
    </div>
  );
}
