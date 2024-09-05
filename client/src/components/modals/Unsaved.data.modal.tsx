import NiceModal, { useModal } from "@ebay/nice-modal-react";
import { Button, Typography } from "@mui/material";

import Flex from "~/components/layout/Flex.tsx";
import BaseModal from "~/components/modals/Base.modal.tsx";

export interface UnsavedDataModalProps {
  onOk?: () => void;
}

export default NiceModal.create(function UnsavedDataModal(props: UnsavedDataModalProps) {
  const modal = useModal();

  function triggerPropAndRemove() {
    props.onOk?.();
    modal.remove();
  }

  return (
    <BaseModal open={modal.visible} title={"Are you sure ?"} width={400}>
      <Flex flexDirection={"column"} gap={4}>
        <Typography variant={"body1"}>You are about to lose unsaved data.</Typography>
        <Flex gap={2} justifyContent={"flex-end"}>
          <Button color={"error"} onClick={modal.remove} variant={"contained"}>
            Cancel
          </Button>
          <Button color={"success"} onClick={triggerPropAndRemove} variant={"contained"}>
            Ok
          </Button>
        </Flex>
      </Flex>
    </BaseModal>
  );
});
