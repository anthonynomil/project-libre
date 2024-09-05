import type { CompanyDto } from "~/types/api/api_types.ts";

import { ReceiptRounded, RequestQuoteRounded } from "@mui/icons-material";
import { Card, CardActionArea, CardContent, CardProps, Typography } from "@mui/material";
import { styled } from "@mui/system";
import { useMemo } from "react";

import Flex from "~/components/layout/Flex.tsx";

interface ClientCardProps extends Omit<CardProps, "onClick"> {
  client: CompanyDto;
  height?: number | string;
  onClick?: (id: number) => void;
}

export default function ClientCard({ onClick, ...props }: ClientCardProps) {
  function propagateClient() {
    onClick?.(props.client.id!);
  }

  const receiptsAmount = useMemo(() => Math.ceil(Math.random() * 5), []);
  const invoicesAmount = useMemo(() => Math.ceil(Math.random() * 5), []);

  return (
    <CardStyled {...props} height={props.height}>
      <CardActionArea onClick={propagateClient} sx={{ height: "100%", width: "100%" }}>
        <CardContentStyled>
          <Flex flexDirection={"column"} justifyContent={"center"}>
            <Typography variant={"h6"}>{props.client.businessName}</Typography>
          </Flex>
          <AssociationsInfos>
            <AssociationInfo>
              <ReceiptRounded />
              <Typography variant={"subtitle2"}>{receiptsAmount}</Typography>
            </AssociationInfo>
            <AssociationInfo>
              <RequestQuoteRounded />
              <Typography variant={"subtitle2"}>{invoicesAmount}</Typography>
            </AssociationInfo>
          </AssociationsInfos>
        </CardContentStyled>
      </CardActionArea>
    </CardStyled>
  );
}

const CardStyled = styled(Card)<{ height?: number | string }>(({ height }) => ({
  borderRadius: 0,
  minHeight: height ?? 100,
  minWidth: 200,
  width: "100%",
}));

const CardContentStyled = styled(CardContent)({
  display: "flex",
  flex: 1,
  height: "100%",
  justifyContent: "space-between",
  width: "100%",
});

const AssociationsInfos = styled(Flex)(({ theme }) => ({
  alignItems: "flex-end",
  flex: 1,
  flexDirection: "column",
  justifyContent: "space-evenly",
  padding: `0 ${theme.spacing(4)}`,
}));

const AssociationInfo = styled(Flex)(({ theme }) => ({
  gap: theme.spacing(2),
}));
