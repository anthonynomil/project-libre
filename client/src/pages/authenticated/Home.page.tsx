import { Box, Container, Stack, Typography } from "@mui/material";

import ToggleDarkModeButton from "~/components/buttons/ToggleDarkMode.button.tsx";

const HomePage = () => {
  return (
    <Container>
      <Stack alignContent={"center"} spacing={5} textAlign={"center"}>
        <Typography color={"primary"} sx={{ wordBreak: "break-word" }} variant={"h1"}>
          Hello Home !
        </Typography>
        <div>
          <ToggleDarkModeButton />
        </div>
        <Box display={"flex"}>
          <Typography color={"primary"} variant={"body2"}>
            This is a Home page
          </Typography>
          <Typography color={"primary"} variant={"body2"}>
            It is only visible to authenticated users
          </Typography>
        </Box>
      </Stack>
    </Container>
  );
};

export default HomePage;
