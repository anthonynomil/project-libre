import type { ClientContactDto } from "~/types/api/api_types.ts";

import { Box, Divider, Typography } from "@mui/material";
import { useQuery } from "@tanstack/react-query";
import { Fragment, useEffect } from "react";

import CompanyRequests from "~/classes/requests/Company.requests.ts";
import Flex from "~/components/layout/Flex.tsx";
import CenteredSpinner from "~/components/spinners/Centered.spinner.tsx";
import PaymentMethod from "~/constants/enums/Payment.method.enum.ts";

export default function ClientsInfosPanel(props: { clientId: null | number }) {
  const { data, isLoading, refetch } = useQuery({
    enabled: Boolean(props.clientId),
    queryFn: () => CompanyRequests.getById(props.clientId!),
    queryKey: ["client"],
  });

  function getAddress() {
    if (data?.value?.address?.number) {
      return `${data?.value?.address?.number} ${data?.value?.address?.road} ${data?.value?.address?.city?.name} ${data?.value?.address?.city?.postalCode}`;
    }
    return "N/A";
  }

  function getContactAddress(contact: ClientContactDto | null | undefined) {
    if (!contact?.address) return "N/A";
    return `${contact.address?.number} ${contact.address?.road} ${contact.address?.city?.name} ${contact.address?.city?.postalCode}`;
  }

  useEffect(() => {
    if (props.clientId) refetch();
  }, [props.clientId]);

  return (
    <Flex flex={1} flexDirection={"column"}>
      {!props.clientId ? (
        <Box sx={{ alignItems: "center", display: "flex", flex: 1, justifyContent: "center" }}>
          <Typography variant="body1">Click on a client to get it&apos;s details</Typography>
        </Box>
      ) : isLoading ? (
        <CenteredSpinner />
      ) : (
        <Box
          sx={{ display: "flex", flex: 1, flexDirection: "column", maxHeight: 800, minHeight: 0, overflow: "scroll" }}
        >
          <Box sx={{ display: "flex", flex: 1 }}>
            <Box
              sx={{ display: "flex", flex: 1, flexDirection: "column", gap: 3, maxWidth: "50%", p: 2, width: "50%" }}
            >
              <Typography align={"center"} color={"primary"} variant={"h6"}>
                Main Information
              </Typography>
              <Box sx={{ alignItems: "center", display: "flex" }}>
                <Typography sx={{ pr: 2 }} variant={"body2"}>
                  Business name :
                </Typography>
                {data?.value?.businessName ?? "N/A"}
              </Box>
            </Box>
            <Box
              sx={{ display: "flex", flex: 1, flexDirection: "column", gap: 3, maxWidth: "50%", p: 2, width: "50%" }}
            >
              <Typography align={"center"} color={"primary"} variant={"h6"}>
                Bank Details
              </Typography>
              <Box sx={{ alignItems: "center", display: "flex" }}>
                <Typography sx={{ pr: 2 }} variant={"body2"}>
                  IBAN :
                </Typography>
                {data?.value?.bankDetails?.iban ?? "N/A"}
              </Box>
              <Box sx={{ alignItems: "center", display: "flex" }}>
                <Typography sx={{ pr: 2 }} variant={"body2"}>
                  BIC :
                </Typography>
                {data?.value?.bankDetails?.bic ?? "N/A"}
              </Box>
            </Box>
          </Box>
          <Box sx={{ display: "flex", flex: 1 }}>
            <Box
              sx={{ display: "flex", flex: 1, flexDirection: "column", gap: 3, maxWidth: "50%", p: 2, width: "50%" }}
            >
              <Typography align={"center"} color={"primary"} variant={"h6"}>
                Financial Information
              </Typography>
              <Box sx={{ alignItems: "center", display: "flex" }}>
                <Typography sx={{ pr: 2 }} variant={"body2"}>
                  Budget :
                </Typography>
                {data?.value?.financialInformation?.budget
                  ?.toString()
                  .split("")
                  .reverse()
                  .map((joe, index) => (index % 3 === 0 ? `${joe} ` : joe))
                  .reverse()
                  .join("") ?? "N/A"}
              </Box>
              <Box sx={{ alignItems: "center", display: "flex" }}>
                <Typography sx={{ pr: 2 }} variant={"body2"}>
                  Payment Method :
                </Typography>
                <Typography variant={"body1"}>
                  {data?.value?.financialInformation?.paymentMethod
                    ? // eslint-disable-next-line @typescript-eslint/ban-ts-comment
                      //@ts-expect-error
                      PaymentMethod[data?.value?.financialInformation?.paymentMethod]
                    : "N/A"}
                </Typography>
              </Box>
            </Box>
            <Box
              sx={{ display: "flex", flex: 1, flexDirection: "column", gap: 3, maxWidth: "50%", p: 2, width: "50%" }}
            >
              <Typography align={"center"} color={"primary"} variant={"h6"}>
                Address
              </Typography>
              <Box sx={{ alignItems: "center", display: "flex" }}>
                <Typography sx={{ mr: 1, textWrap: "nowrap" }} variant={"body2"}>
                  Address :
                </Typography>
                {getAddress()}
              </Box>
              <Box sx={{ alignItems: "center", display: "flex" }}>
                <Typography sx={{ pr: 2 }} variant={"body2"}>
                  Country :
                </Typography>
                {data?.value?.country?.name ?? "N/A"}
              </Box>
            </Box>
          </Box>
          <Box sx={{ display: "flex", flex: 1, flexDirection: "column", mt: 2 }}>
            <Typography align={"center"} color={"primary"} variant={"h5"}>
              Contacts
            </Typography>
            {data?.value?.contacts?.map((contact, index) => (
              <Fragment key={index}>
                <Divider sx={{ mt: 2 }} />
                <Box key={index} sx={{ display: "flex", flex: 1, gap: 3 }}>
                  <Box sx={{ display: "flex", flex: 1, flexDirection: "column", gap: 3, p: 2 }}>
                    <Typography align={"center"} color={"primary"} variant={"h6"}>
                      Information
                    </Typography>
                    <Box sx={{ alignItems: "center", display: "flex" }}>
                      <Typography sx={{ pr: 2 }} variant={"body2"}>
                        Firstname :
                      </Typography>
                      {contact.firstname ?? "N/A"}
                    </Box>
                    <Box sx={{ alignItems: "center", display: "flex" }}>
                      <Typography sx={{ pr: 2 }} variant={"body2"}>
                        Lastname :
                      </Typography>
                      {contact.lastname}
                    </Box>
                  </Box>
                  <Box sx={{ display: "flex", flex: 1, flexDirection: "column", gap: 3, p: 2 }}>
                    <Typography align={"center"} color={"primary"} variant={"h6"}>
                      Donnée de contact
                    </Typography>
                    <Box sx={{ alignItems: "center", display: "flex" }}>
                      <Typography sx={{ pr: 2 }} variant={"body2"}>
                        Email :
                      </Typography>
                      {contact.contactInformation?.mailAddress ?? "N/A"}
                    </Box>
                    <Box sx={{ alignItems: "center", display: "flex" }}>
                      <Typography sx={{ pr: 2 }} variant={"body2"}>
                        Phone number :
                      </Typography>
                      {contact.contactInformation?.phoneNumber ?? "N/A"}
                    </Box>
                  </Box>
                </Box>
                <Box key={index} sx={{ display: "flex", flex: 1, gap: 3 }}>
                  <Box sx={{ display: "flex", flex: 1, flexDirection: "column", gap: 3, p: 2 }}>
                    <Typography align={"center"} color={"primary"} variant={"h6"}>
                      Address
                    </Typography>
                    <Box sx={{ alignItems: "center", display: "flex" }}>
                      <Typography sx={{ pr: 2 }} variant={"body2"}>
                        Address :
                      </Typography>
                      {getContactAddress(contact) ?? "N/A"}
                    </Box>
                    <Box sx={{ alignItems: "center", display: "flex" }}>
                      <Typography sx={{ pr: 2 }} variant={"body2"}>
                        Country :
                      </Typography>
                      {contact.country?.name ?? "N/A"}
                    </Box>
                  </Box>
                </Box>
              </Fragment>
            ))}
          </Box>
        </Box>
      )}
    </Flex>
  );
}
