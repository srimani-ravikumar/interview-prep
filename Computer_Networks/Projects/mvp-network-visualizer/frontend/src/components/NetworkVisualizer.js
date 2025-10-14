import React, { useEffect, useState } from "react";
import "../NetworkVisualizer.css";

const nodes = ["Sender", "Router 1", "Router 2", "Receiver"];

const nodePositions = {
  "Sender": { x: 50, y: 150 },
  "Router 1": { x: 200, y: 150 },
  "Router 2": { x: 350, y: 150 },
  "Receiver": { x: 500, y: 150 }
};

function NetworkVisualizer() {
  const [packets, setPackets] = useState([]);

  useEffect(() => {
    const ws = new WebSocket("ws://localhost:8080");

    ws.onmessage = (message) => {
      const packet = JSON.parse(message.data);
      setPackets(prev => {
        const filtered = prev.filter(p => p.id !== packet.id);
        return [...filtered, packet];
      });
    };

    return () => ws.close();
  }, []);

  return (
    <div className="network-container">
      {/* Nodes */}
      {nodes.map(node => (
        <div
          key={node}
          className="node"
          style={{ left: nodePositions[node].x, top: nodePositions[node].y }}
        >
          {node}
        </div>
      ))}

      {/* Packets */}
      {packets.map(packet => {
        const pos = nodePositions[packet.currentNode] || nodePositions["Sender"];
        let color = "blue";
        if (packet.status === "delivered") color = "green";
        if (packet.status === "dropped") color = "red";

        return (
          <div
            key={packet.id}
            className="packet"
            style={{
              left: pos.x,
              top: pos.y - 10,
              backgroundColor: color
            }}
            title={`Packet ${packet.id}, Protocol: ${packet.protocol}, Status: ${packet.status}`}
          />
        );
      })}
    </div>
  );
}

export default NetworkVisualizer;
