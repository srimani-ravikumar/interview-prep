import React from 'react';
import PacketVisualizer from './components/PacketVisualizer';
import StatsPanel from './components/StatsPanel';

function App() {
  return (
    <div style={{ textAlign: 'center' }}>
      <h1>End-to-End Network Visualizer</h1>
      <PacketVisualizer />
      <StatsPanel packets={[]} /> {/* You can pass real packet state later */}
    </div>
  );
}

export default App;
