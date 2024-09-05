import { MenuItem, type PaperProps, Select, type SelectChangeEvent } from "@mui/material";
import { styled } from "@mui/system";
import { BarChart } from "@mui/x-charts";
import { useState } from "react";

import { DashboardChartPaper } from "~/components/charts/DashboardPieChart.tsx";
import Flex from "~/components/layout/Flex.tsx";

const chartDataOptions = {
  option1: [
    { data: [4, 3, 5, 6, 3, 2, 1, 6, 7, 3, 5, 6] },
    { data: [1, 6, 3, 7, 5, 2, 3, 7, 2, 6, 8, 2] },
    { data: [2, 5, 6, 9, 6, 4, 3, 2, 1, 7, 8, 2] },
  ],
  option2: [
    { data: [7, 2, 3, 7, 5, 2, 3, 7, 2, 6, 8, 2] },
    { data: [5, 8, 4, 6, 3, 2, 1, 6, 7, 3, 5, 6] },
    { data: [6, 1, 5, 9, 6, 4, 3, 2, 1, 7, 8, 2] },
  ],
  option3: [
    { data: [3, 5, 1, 6, 3, 2, 1, 6, 7, 3, 5, 6] },
    { data: [2, 4, 6, 9, 6, 4, 3, 2, 1, 7, 8, 2] },
    { data: [5, 3, 2, 6, 3, 2, 1, 6, 7, 3, 5, 6] },
  ],
};

type SelectableOptions = "option1" | "option2" | "option3";

interface DashboardBarChartProps extends PaperProps {}

export default function DashboardBarChart(props: DashboardBarChartProps) {
  const [graphDataSource, setGraphDataSource] = useState<SelectableOptions>("option1");

  const updateGraphData = (event: SelectChangeEvent) => {
    setGraphDataSource(event.target.value as SelectableOptions);
  };

  const options = [
    {
      label: "Bob",
      value: "option1",
    },
    {
      label: "Tom",
      value: "option2",
    },
    {
      label: "Joe",
      value: "option3",
    },
  ];

  return (
    <DashboardChartPaper {...props}>
      <Select
        displayEmpty
        inputProps={{ "aria-label": "Without label" }}
        onChange={updateGraphData}
        value={graphDataSource}
      >
        {options.map((option, index) => (
          <MenuItem key={index} value={option.value}>
            {option.label}
          </MenuItem>
        ))}
      </Select>
      <Flex flex={1}>
        <StyledBarChart
          series={chartDataOptions[graphDataSource]}
          xAxis={[
            {
              data: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
              scaleType: "band",
            },
          ]}
        />
      </Flex>
    </DashboardChartPaper>
  );
}

const StyledBarChart = styled(BarChart)(() => ({
  height: "100%",
}));
