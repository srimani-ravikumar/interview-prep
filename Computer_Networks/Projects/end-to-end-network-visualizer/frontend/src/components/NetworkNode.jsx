import React from 'react';

export default function NetworkNode({ name, x, y }) {
  return (
    <circle cx={x} cy={y} r="25" fill="#4CAF50">
      <title>{name}</title>
    </circle>
  );
}
