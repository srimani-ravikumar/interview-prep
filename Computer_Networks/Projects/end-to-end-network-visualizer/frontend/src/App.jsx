// App.jsx
import React, { useState, useEffect, useRef } from 'react';
import PacketVisualizer from './components/PacketVisualizer';
import StatsPanel from './components/StatsPanel';

function App() {
  const ws = useRef(null);
  const [packets, setPackets] = useState([]);
  const [input, setInput] = useState('');

  useEffect(() => {
    ws.current = new WebSocket('ws://localhost:5000');

    ws.current.onmessage = (event) => {
      const data = JSON.parse(event.data);
      if (data.event === 'packetUpdate') {
        setPackets(prev => [...prev, data.packet]);
      }
    };

    return () => ws.current.close();
  }, []);

  const sendMessage = () => {
    if (input && ws.current.readyState === WebSocket.OPEN) {
      ws.current.send(JSON.stringify({ event: 'sendMessage', message: input }));
      setInput('');
    }
  };

  return (
    <div style={{ textAlign: 'center' }}>
      <h1>End-to-End Network Visualizer</h1>

      <input
        type="text"
        value={input}
        onChange={(e) => setInput(e.target.value)}
        placeholder="Type a message"
      />
      <button onClick={sendMessage}>Send</button>

      <PacketVisualizer packets={packets} />
      <StatsPanel packets={packets} />
    </div>
  );
}

export default App;
