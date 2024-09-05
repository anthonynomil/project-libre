import { MenuItem, Paper, type PaperProps, Select, type SelectChangeEvent } from "@mui/material";
import { styled } from "@mui/system";
import { PieChart } from "@mui/x-charts";
import { useState } from "react";

import Flex from "~/components/layout/Flex.tsx";

const dummyData = {
  clients: [
    { id: 0, label: "Bob", value: 10 },
    { id: 1, label: "Tom", value: 15 },
    { id: 2, label: "Joe", value: 20 },
  ],
  contracts: [
    { id: 0, label: "Done", value: 5 },
    { id: 1, label: "In work", value: 15 },
    { id: 2, label: "To do", value: 25 },
  ],
  paymentStatus: [
    { id: 0, label: "Payed", value: 20 },
    { id: 1, label: "Pending", value: 10 },
    { id: 2, label: "Not done", value: 5 },
  ],
};

const dummySelectOptions = [
  {
    label: "Clients",
    value: "clients",
  },
  {
    label: "Contracts",
    value: "contracts",
  },
  {
    label: "Payment Status",
    value: "paymentStatus",
  },
];

export default function DashboardPieChart(props: PaperProps) {
  const [selectedDataType, setSelectedDataType] = useState<keyof typeof dummyData>("clients");

  const setSelectedDataTypeFromSelectEvent = (event: SelectChangeEvent) => {
    setSelectedDataType(event.target.value as keyof typeof dummyData);
  };

  return (
    <DashboardChartPaper {...props}>
      <Select
        displayEmpty
        inputProps={{ "aria-label": "Without label" }}
        onChange={setSelectedDataTypeFromSelectEvent}
        value={selectedDataType}
      >
        {dummySelectOptions.map((option, index) => (
          <MenuItem key={index} value={option.value}>
            {option.label}
          </MenuItem>
        ))}
      </Select>
      <Flex flex={1} sx={{ p: 4 }}>
        <PieChart series={[{ data: dummyData[selectedDataType] }]} />
      </Flex>
    </DashboardChartPaper>
  );
}

export const DashboardChartPaper = styled(Paper)(({ theme }) => ({
  display: "flex",
  flex: 1,
  flexDirection: "column",
  maxHeight: "100%",
  maxWidth: "100%",
  minHeight: 0,
  minWidth: 390,
  padding: theme.spacing(4),
  width: "100%",
}));
