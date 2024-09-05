import type { LoginFormSchema } from "~/classes/schemas/form/Login.form.schema.ts";
import type { FormRef } from "~/types/form.types.ts";

import { LoadingButton } from "@mui/lab";
import { Box, Button, Checkbox, Divider, FormControlLabel, Paper, Typography, darken } from "@mui/material";
import { styled, useTheme } from "@mui/system";
import { useMutation } from "@tanstack/react-query";
import { useSnackbar } from "notistack";
import { useRef, useState } from "react";
import { Link, useNavigate } from "react-router-dom";

import Logo from "~/assets/app.icon.svg?react";
import apiManager from "~/classes/Api.manager.ts";
import AuthRequests from "~/classes/requests/Auth.requests.ts";
import tokenStorage from "~/classes/storage/Token.storage.ts";
import LoginForm from "~/components/forms/Login.form.tsx";
import Flex from "~/components/layout/Flex.tsx";
import RoutesUrl from "~/constants/enums/routes.url.ts";
import useAppDispatch from "~/hooks/useAppDispatch.tsx";
import { userActions } from "~/store/reducers/user.reducer.ts";

export default function LoginPage() {
  const { enqueueSnackbar } = useSnackbar();
  const navigate = useNavigate();
  const theme = useTheme();
  const dispatch = useAppDispatch();
  const formRef = useRef<FormRef<LoginFormSchema>>(null);

  const [_shouldRemember, setShouldRemember] = useState<boolean>(true);

  const { isPending, mutate } = useMutation({ mutationFn: AuthRequests.login });

  function navigateToRegisterPage() {
    navigate(RoutesUrl.Register);
  }

  function getEventValue(_: unknown, checked: boolean) {
    setShouldRemember(checked);
  }

  function loginUser(data: LoginFormSchema) {
    mutate(data, {
      onError: (error) => enqueueSnackbar(error.message, { variant: "error" }),
      onSuccess: (data) => {
        const token = data.value?.token;
        const user = data.value?.user;
        if (!user || !token) throw new Error("User not received.");
        enqueueSnackbar(data.message, { variant: "success" });
        dispatch(userActions.set(user));
        tokenStorage.set(token);
        apiManager.setToken(token);
        navigate(RoutesUrl.Home);
      },
    });
  }

  function submitForm() {
    formRef.current?.submit();
  }

  return (
    <AuthPaper elevation={4}>
      <Flex alignItems={"center"} flexDirection={"column"} justifyContent={"center"}>
        <AuthLogo fill={theme.palette.text.primary} />
        <Typography component={"h1"} pt={1} variant={"h5"}>
          SoloSail
        </Typography>
      </Flex>
      <LoginForm hideSubmitButton onSubmit={loginUser} ref={formRef} />
      <LoadingButton loading={isPending} onClick={submitForm} variant={"contained"}>
        Login
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
      <Button onClick={navigateToRegisterPage} variant={"contained"}>
        Register
      </Button>
      <Box alignItems={"center"} display={"flex"} flex={1} justifyContent={"space-between"}>
        <FormControlLabel
          control={<Checkbox color={"default"} defaultChecked onChange={getEventValue} />}
          label="Remember me"
        />
        <AuthLink to={RoutesUrl.ForgotPassword}>Forgot password ?</AuthLink>
      </Box>
    </AuthPaper>
  );
}

export const AuthPaper = styled(Paper)(({ theme }) => ({
  display: "flex",
  flexDirection: "column",
  gap: theme.spacing(4),
  margin: "auto",
  maxWidth: theme.spacing(128),
  padding: theme.spacing(12),
  width: "100%",
}));

export const AuthLogo = styled(Logo)(({ theme }) => ({
  height: theme.spacing(12),
  width: theme.spacing(12),
}));

export const AuthLink = styled(Link)(({ theme }) => ({
  "&:hover": {
    color: theme.palette.text.primary,
  },
  color: darken(theme.palette.text.primary, 0.2),
  margin: 0,
  padding: 0,
  textDecoration: "none",
}));

export const AuthDivider = styled(Divider)(({ theme }) => ({
  backgroundColor: theme.palette.text.primary,
}));
