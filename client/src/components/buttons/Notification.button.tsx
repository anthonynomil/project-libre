import { NotificationsActiveRounded, NotificationsOffRounded, NotificationsRounded } from "@mui/icons-material";
import { Badge, IconButton, type IconButtonProps, Menu, MenuItem } from "@mui/material";
import { type MouseEvent, useState } from "react";

export default function NotificationButton(props: IconButtonProps) {
  const [anchor, setAnchor] = useState<HTMLElement | null>(null);
  const [notificationsCount, setNotificationsCount] = useState<number>(0);
  const [notificationsActive, setNotificationsActive] = useState<boolean>(true);
  const open = Boolean(anchor);

  function openAnchor(event: MouseEvent<HTMLButtonElement>) {
    setAnchor(event.currentTarget);
  }

  function addNotification() {
    setNotificationsCount((prev) => ++prev);
  }

  function clearNotifications() {
    setNotificationsCount(0);
  }

  function activateNotifications() {
    setNotificationsActive(true);
  }

  function deactivateNotifications() {
    setNotificationsActive(false);
  }

  function closeMenu() {
    setAnchor(null);
  }

  return (
    <>
      <IconButton {...props} onClick={openAnchor}>
        {notificationsActive ? (
          notificationsCount > 0 ? (
            <Badge badgeContent={notificationsCount} color={"error"}>
              <NotificationsActiveRounded />
            </Badge>
          ) : (
            <NotificationsRounded />
          )
        ) : (
          <NotificationsOffRounded />
        )}
      </IconButton>
      <Menu anchorEl={anchor} onClose={closeMenu} open={open}>
        <MenuItem onClick={addNotification}>Simulate Notification</MenuItem>
        <MenuItem onClick={clearNotifications}> Clear Notifications</MenuItem>
        <MenuItem onClick={activateNotifications}>Activate</MenuItem>
        <MenuItem onClick={deactivateNotifications}>Deactivate</MenuItem>
        <MenuItem onClick={closeMenu}>Close</MenuItem>
      </Menu>
    </>
  );
}
