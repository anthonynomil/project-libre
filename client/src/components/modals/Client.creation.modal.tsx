import type { ClientFormSchema } from "~/classes/schemas/form/Client.form.schema.ts";
import type { IEnvelop } from "~/types/api/api_types.ts";
import type { FormRef } from "~/types/form.types.ts";

import NiceModal, { useModal } from "@ebay/nice-modal-react";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import { useSnackbar } from "notistack";
import { useRef } from "react";

import CompanyRequests from "~/classes/requests/Company.requests.ts";
import ClientForm from "~/components/forms/Client.form.tsx";
import BaseModal from "~/components/modals/Base.modal.tsx";
import UnsavedDataModal from "~/components/modals/Unsaved.data.modal.tsx";
import queryKeys from "~/constants/enums/query.keys.ts";

export default NiceModal.create(function (_) {
  const queryClient = useQueryClient();
  const modal = useModal();
  const confirmModal = useModal(UnsavedDataModal);
  const { enqueueSnackbar } = useSnackbar();

  const { isPending, mutate } = useMutation({
    mutationFn: CompanyRequests.create,
  });

  const formRef = useRef<FormRef<ClientFormSchema>>(null);

  function createClient(data: ClientFormSchema) {
    mutate(data, {
      onError: notifyAndCloseModal("error"),
      onSuccess: notifyAndCloseModal("success"),
    });
  }

  function notifyAndCloseModal(variant: "error" | "success") {
    return function (data: IEnvelop) {
      enqueueSnackbar(data.message, { variant });
      queryClient.refetchQueries({ queryKey: [queryKeys.Companies] });
      modal.remove();
    };
  }

  function promptIfIsDirty() {
    if (formRef.current?.isDirty()) confirmModal.show({ onOk: modal.remove });
    else modal.remove();
  }

  return (
    <BaseModal onClose={promptIfIsDirty} open={modal.visible} title={"Client creation"} width={900}>
      <ClientForm isLoading={isPending} onSubmit={createClient} ref={formRef} />
    </BaseModal>
  );
});
