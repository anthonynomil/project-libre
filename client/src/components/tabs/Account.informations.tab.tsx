import { Box } from "@mui/material";

import { useUserSelector } from "~/store/reducers/user.reducer.ts";

export interface AccountInformationsProps {}

export default function AccountInformationsTab() {
  const user = useUserSelector();
  return (
    <Box>
      Hello {user.firstname} {user.lastname}
    </Box>
  );
}
