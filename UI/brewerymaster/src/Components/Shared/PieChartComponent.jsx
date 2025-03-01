import React from "react";
import { PieChart, Pie, Cell, Tooltip, Legend } from "recharts";

const COLORS = ["#A9A9A9", "#808080", "#696969", "#505050", "#D3D3D3", "#B0B0B0", "#C0C0C0", "#E0E0E0"];

const PieChartComponent = ({data, setOfColor = 0}) => {
  return (
    <PieChart width={400} height={250}>
      <Pie 
        data={data} 
        cx="50%" 
        cy="50%" 
        outerRadius={100} 
        fill="#8884d8"
        dataKey="value"
        label
      >
        {data.map((entry, index) => (
          <Cell key={`cell-${index}`} fill={COLORS[(index + setOfColor) % COLORS.length]} />
        ))}
      </Pie>
      <Tooltip />
      <Legend />
    </PieChart>
  );
};

export default PieChartComponent;
