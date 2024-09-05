import { useModal } from "@ebay/nice-modal-react";
import { AddRounded } from "@mui/icons-material";
import { Badge, Box, Divider, IconButton, Typography } from "@mui/material";
import { styled } from "@mui/system";

import Flex from "~/components/layout/Flex.tsx";
import ClientsList from "~/components/lists/Clients.list.tsx";
import ClientCreationModal from "~/components/modals/Client.creation.modal.tsx";

export default function ClientsPanel(props: { onClick: (id: number) => void }) {
  const clientModal = useModal(ClientCreationModal);

  function openClientModal() {
    clientModal.show();
  }

  return (
    <Flex flex={1} flexDirection={"column"}>
      <PanelHeader>
        <StyledBadge
          badgeContent={
            <StyledIconButton onClick={openClientModal}>
              <AddRounded />
            </StyledIconButton>
          }
        >
          <Typography align={"center"} variant={"button"}>
            Clients
          </Typography>
        </StyledBadge>
      </PanelHeader>
      <Divider variant={"fullWidth"} />
      <ClientsList onClick={props.onClick} />
    </Flex>
  );
}

export const PanelHeader = styled(Box)(({ theme }) => ({
  alignItems: "center",
  display: "flex",
  height: theme.spacing(16),
  justifyContent: "center",
  span: {
    userSelect: "none",
  },
}));

const StyledBadge = styled(Badge)(({ theme }) => ({
  "& .MuiBadge-badge": {
    right: theme.spacing(-4),
    top: theme.spacing(2),
  },
}));

const StyledIconButton = styled(IconButton)(({ theme }) => ({
  color: theme.palette.primary.main,
  height: theme.spacing(6),
  svg: {
    height: theme.spacing(4),
    width: theme.spacing(4),
  },
  width: theme.spacing(6),
}));
