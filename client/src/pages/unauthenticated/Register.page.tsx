import type { RegisterFormSchema } from "~/classes/schemas/form/Register.form.schema.ts";
import type { FormRef } from "~/types/form.types.ts";

import { LoadingButton } from "@mui/lab";
import { Box, Button, Typography } from "@mui/material";
import { useMutation } from "@tanstack/react-query";
import { useSnackbar } from "notistack";
import { useRef } from "react";
import { useNavigate } from "react-router-dom";

import AuthRequests from "~/classes/requests/Auth.requests.ts";
import RegisterForm from "~/components/forms/Register.form.tsx";
import Flex from "~/components/layout/Flex.tsx";
import RoutesUrl from "~/constants/enums/routes.url.ts";
import { AuthDivider, AuthLogo, AuthPaper } from "~/pages/unauthenticated/Login.page.tsx";

export default function RegisterPage() {
  const snack = useSnackbar();
  const navigate = useNavigate();
  const formRef = useRef<FormRef<RegisterFormSchema>>(null);

  const { isPending, mutate } = useMutation({
    mutationFn: AuthRequests.register,
  });

  async function registerUser({ confirmPassword: _, ...data }: RegisterFormSchema) {
    mutate(data, {
      onError: (error) => snack.enqueueSnackbar({ message: error.message, variant: "error" }),
      onSuccess: function () {
        snack.enqueueSnackbar({ message: "Registered successfully.", variant: "success" });
        navigate(RoutesUrl.Login);
      },
    });
  }

  function submitForm() {
    formRef.current?.submit();
  }

  function navigateToLoginPage() {
    navigate(RoutesUrl.Login);
  }

  return (
    <AuthPaper elevation={4}>
      <Flex alignItems={"center"} flexDirection={"column"} justifyContent={"center"}>
        <AuthLogo />
        <Typography component={"h1"} pt={1} variant={"h5"}>
          SoloSail
        </Typography>
      </Flex>
      <RegisterForm hideSubmitButton onSubmit={registerUser} ref={formRef} />
      <LoadingButton loading={isPending} onClick={submitForm} variant={"contained"}>
        Register
      </LoadingButton>
      <Box alignItems={"center"} display={"flex"} m={"auto"} width={"60%"}>
        <Box flexGrow={1}>
          <AuthDivider />
        </Box>
        <Typography px={2} variant={"button"}>
          OR
        </Typography>
        <Box flexGrow={1}>
          <AuthDivider />
        </Box>
      </Box>
      <Button onClick={navigateToLoginPage} variant={"contained"}>
        Login
      </Button>
    </AuthPaper>
  );
}
