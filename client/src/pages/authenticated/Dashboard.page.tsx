import { Container, Paper, Stack } from "@mui/material";

import DashboardBarChart from "~/components/charts/DashboardBarChart.tsx";
import DashboardPieChart from "~/components/charts/DashboardPieChart.tsx";
import Flex from "~/components/layout/Flex.tsx";
import DashboardTable from "~/components/tables/Dashboard.table.tsx";

const DashboardPage = () => {
  return (
    <Container sx={{ mb: 4 }}>
      <Stack alignContent={"center"} spacing={8} sx={{ pt: 4 }} textAlign={"center"}>
        <Flex flex={1} flexWrap={"wrap"} gap={8}>
          <DashboardBarChart sx={{ height: 400 }} />
          <DashboardPieChart sx={{ height: 400 }} />
        </Flex>
        <Paper>
          <DashboardTable />
        </Paper>
      </Stack>
    </Container>
  );
};
export default DashboardPage;
