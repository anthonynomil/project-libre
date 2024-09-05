import { AccountCircleRounded } from "@mui/icons-material";
import { CircularProgress, IconButton, type IconButtonProps, Menu, MenuItem } from "@mui/material";
import { useMutation } from "@tanstack/react-query";
import { useSnackbar } from "notistack";
import { type MouseEvent, useState } from "react";
import { useNavigate } from "react-router-dom";

import AuthRequests from "~/classes/requests/Auth.requests.ts";
import RoutesUrl from "~/constants/enums/routes.url.ts";
import useAppDispatch from "~/hooks/useAppDispatch.tsx";
import { userActions } from "~/store/reducers/user.reducer.ts";

export default function ProfileButton(props: IconButtonProps) {
  const navigate = useNavigate();
  const { enqueueSnackbar } = useSnackbar();
  const dispatch = useAppDispatch();
  const [anchor, setAnchor] = useState<HTMLElement | null>(null);
  const open = Boolean(anchor);

  const { isPending, mutate } = useMutation({ mutationFn: AuthRequests.logout });

  function setAnchorFromButtonEvent(event: MouseEvent<HTMLButtonElement>) {
    setAnchor(event.currentTarget);
  }

  function closeMenu() {
    setAnchor(null);
  }

  function goToProfilePage() {
    navigate(RoutesUrl.Account);
    closeMenu();
  }

  function logout() {
    closeMenu();
    mutate(undefined, {
      onError: (error) => enqueueSnackbar(error.message, { variant: "error" }),
      onSuccess: () => {
        enqueueSnackbar("Logged out successfully.", { variant: "success" });
        dispatch(userActions.clear());
      },
    });
  }

  return (
    <>
      <IconButton onClick={setAnchorFromButtonEvent} {...props}>
        {isPending ? <CircularProgress size={24} /> : <AccountCircleRounded />}
      </IconButton>
      <Menu anchorEl={anchor} onClose={closeMenu} open={open}>
        <MenuItem onClick={goToProfilePage}>My account</MenuItem>
        <MenuItem onClick={logout}>Logout</MenuItem>
      </Menu>
    </>
  );
}
