import { Paper } from "@mui/material";
import Grid from "@mui/material/Grid";

const data = [
  { key: "Contracts", value: 2 },
  { key: "Another Metric", value: 5 },
];

const DashboardGrid = () => {
  return (
    <Paper
      sx={{
        padding: 2,
      }}
    >
      <Grid container spacing={1}>
        {data.map((item, index) => (
          <Grid item key={index} lg={2} md={3} sm={4} xl={1.5} xs={6}>
            <div>
              <strong>{item.key}:</strong> {item.value}
            </div>
          </Grid>
        ))}
      </Grid>
    </Paper>
  );
};

export default DashboardGrid;
