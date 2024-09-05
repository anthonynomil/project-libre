import { Divider } from "@mui/material";
import { useQuery } from "@tanstack/react-query";
import { Fragment } from "react";

import CompanyRequests from "~/classes/requests/Company.requests.ts";
import ClientCard from "~/components/cards/Client.card.tsx";
import Flex from "~/components/layout/Flex.tsx";
import CenteredSpinner from "~/components/spinners/Centered.spinner.tsx";
import QueryKeys from "~/constants/enums/query.keys.ts";

export interface ClientsListProps {
  onClick?: (client: any) => void;
}

export default function ClientsList(props: ClientsListProps) {
  const { data, isLoading } = useQuery({
    queryFn: CompanyRequests.getAll,
    queryKey: [QueryKeys.Companies],
  });

  const companies = data?.value ?? [];

  return (
    <Flex flexDirection={"column"} height={"100%"} maxHeight={"100%"} sx={{ overflow: "scroll" }} width={"100%"}>
      {isLoading ? (
        <CenteredSpinner />
      ) : (
        companies.map((client, index) => (
          <Fragment key={client.id}>
            <ClientCard client={client} height={"calc(100% / 6)"} key={client.id} onClick={props.onClick} />
            {index === companies.length - 1 ? null : <Divider />}
          </Fragment>
        ))
      )}
    </Flex>
  );
}
