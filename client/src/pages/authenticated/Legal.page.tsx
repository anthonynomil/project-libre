import { Box, Container, Stack, Typography } from "@mui/material";

const LegalPage = () => {
  return (
    <Container>
      <Stack alignContent={"center"} spacing={5} textAlign={"center"}>
        <Typography color={"primary"} sx={{ wordBreak: "break-word" }} variant={"h1"}>
          Hello Legal !
        </Typography>
        <Box display={"flex"}>
          <Typography color={"primary"} variant={"body2"}>
            This is a Legal page
          </Typography>
          <Typography color={"primary"} variant={"body2"}>
            It is only visible to authenticated users
          </Typography>
        </Box>
      </Stack>
    </Container>
  );
};
export default LegalPage;
