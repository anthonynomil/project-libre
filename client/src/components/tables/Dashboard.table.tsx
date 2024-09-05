import Box from "@mui/material/Box";
import { DataGrid, GridColDef, GridValueGetterParams } from "@mui/x-data-grid";

const columns: GridColDef[] = [
  { field: "id", headerName: "ID", width: 90 },
  {
    editable: true,
    field: "projectName",
    headerName: "Project name",
    width: 150,
  },
  {
    editable: true,
    field: "clientName",
    headerName: "Client name",
    width: 150,
  },
  {
    editable: true,
    field: "startingDate",
    headerName: "Starting date",
    type: "date",
    valueGetter: (params: GridValueGetterParams) => new Date(params.value),
    width: 110,
  },
  {
    editable: true,
    field: "endingDate",
    headerName: "Ending date",
    type: "date",
    valueGetter: (params: GridValueGetterParams) => new Date(params.value),
    width: 110,
  },
  {
    field: "status",
    headerName: "Status",
    sortable: true,
    width: 160,
  },
];

const rows = [
  { clientName:"Bob Spencer",endingDate: "2023-08-10", id: 1,projectName: "Go go power rangers",startingDate: "2022-10-21", status: "Active" },
  { clientName:"Stan Shelby",endingDate: "2023-01-07", id: 2,projectName: "Stopper",startingDate: "2022-01-12", status: "Done" },
  { clientName:"Anthony Limon",endingDate: "2022-11-12", id: 3,projectName: "Joe lovers",startingDate: "2023-01-11", status: "Done" },
  { clientName:"Hiroshi Yoma",endingDate: "2023-12-12", id: 4,projectName: "Yakuma",startingDate: "2023-10-01", status: "Active" },
  { clientName:"Dodo Pizza",endingDate: "2022-07-07", id: 5,projectName: "Kanibal",startingDate: "2022-09-10", status: "Active" },
  { clientName:"ZARA",endingDate: "2021-11-09", id: 6,projectName: "T-shirt",startingDate: "2022-01-05", status: "Done" },
  { clientName:"Audi",endingDate: "2022-05-13", id: 7,projectName: "Motor-B",startingDate: "2022-08-17", status: "Active" },
  { clientName:"LuftHansa",endingDate: "2022-09-02", id: 8,projectName: "Bomb",startingDate: "2022-10-02", status: "Done" },
  { clientName:"PSG",endingDate: "2022-03-01", id: 9,projectName: "White",startingDate: "2022-09-22", status: "Active" },
];

export default function DataGridDemo() {
  return (
    <Box sx={{ height: 400, width: "100%" }}>
      <DataGrid
        checkboxSelection
        columns={columns}
        disableRowSelectionOnClick
        initialState={{
          pagination: {
            paginationModel: {
              pageSize: 5,
            },
          },
        }}
        pageSizeOptions={[5]}
        rows={rows}
      />
    </Box>
  );
}
