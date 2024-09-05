import { useModal } from "@ebay/nice-modal-react";
import { CloseRounded } from "@mui/icons-material";
import { Box, type BoxProps, Divider, Fade, IconButton, Modal, ModalProps, Paper, Typography } from "@mui/material";
import { styled } from "@mui/system";
import { ReactNode } from "react";

export interface BaseModalProps extends Omit<ModalProps, "title"> {
  bodyPadding?: number;
  height?: number;
  title?: ReactNode | string;
  width?: number;
}

export default function BaseModal({ bodyPadding, height, title, width, ...props }: BaseModalProps) {
  const modal = useModal();

  async function close() {
    if (props.onClose) props.onClose({}, "escapeKeyDown");
    else await modal.hide();
  }

  async function onClose(event: Record<string, unknown>, reason: "backdropClick" | "escapeKeyDown") {
    if (props.onClose) props.onClose?.(event, reason);
    else await modal.hide();
  }

  const TitleComponent = () => {
    if (!title) {
      return <Box width={"100%"} />;
    }
    if (title && typeof title === "string") {
      return (
        <Typography component={"h3"} variant={"h5"}>
          {title}
        </Typography>
      );
    }
    return title;
  };

  return (
    <Modal {...props} onClose={onClose}>
      <Fade in={modal.visible}>
        <BaseModalOuter height={height} width={width}>
          <BaseModalHeader>
            <TitleComponent />
            <Box>
              <IconButton onClick={close}>
                <CloseRounded />
              </IconButton>
            </Box>
          </BaseModalHeader>
          <Divider />
          <BaseModalBody bodyPadding={bodyPadding}>{props.children}</BaseModalBody>
        </BaseModalOuter>
      </Fade>
    </Modal>
  );
}

const BaseModalOuter = styled(Paper)<{ height?: number; width?: number }>(({ theme, ...props }) => ({
  borderRadius: theme.shape.borderRadius,
  // eslint-disable-next-line @typescript-eslint/ban-ts-comment
  //@ts-expect-error
  boxShadow: theme.shadows[5],
  display: "flex",
  flexDirection: "column",
  height: props.height ?? "auto",
  left: "50%",
  maxWidth: "100vw",
  position: "fixed",
  top: "50%",
  transform: "translate(-50%, -50%)",
  width: props.width ?? 800,
}));

const BaseModalHeader = styled(Box)(({ theme }) => ({
  alignItems: "center",
  display: "flex",
  justifyContent: "space-between",
  padding: `${theme.spacing(4)} ${theme.spacing(6)}`,
  width: "100%",
}));

const BaseModalBody = styled(({ bodyPadding: _, ...props }: BoxProps & { bodyPadding?: number }) => (
  <Box {...props} />
))<{
  bodyPadding?: number;
}>(({ theme, ...props }) => ({
  display: "flex",
  flexDirection: "column",
  height: "100%",
  padding: props.bodyPadding ?? `${theme.spacing(4)} ${theme.spacing(6)}`,
  width: "100%",
}));
