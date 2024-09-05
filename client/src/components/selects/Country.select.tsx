import { Autocomplete, TextField } from "@mui/material";
import { useQuery } from "@tanstack/react-query";
import { useEffect, useState } from "react";

import CountryRequests from "~/classes/requests/Country.requests.ts";
import QueryKeys from "~/constants/enums/query.keys.ts";

interface Option {
  label: string;
  value: number;
}

export interface CountrySelectProps {
  onChange: (value: null | number) => void;
  value: null | number | undefined;
}

export default function CountrySelect(props: CountrySelectProps) {
  const [countries, setCountries] = useState<Option[]>([]);

  const { data } = useQuery({
    queryFn: CountryRequests.getAll,
    queryKey: [QueryKeys.Countries],
  });

  function setCountriesFromData() {
    setCountries(
      data?.value?.map(
        (country): Option => ({
          label: country.name!,
          value: country.id!,
        }),
      ) ?? [],
    );
  }

  function propagateOnChange(_: unknown, value: Option | null) {
    props.onChange(value?.value ?? null);
  }

  useEffect(setCountriesFromData, [data]);

  return (
    <Autocomplete
      onChange={propagateOnChange}
      options={countries}
      renderInput={(params) => <TextField {...params} label={"Country"} />}
      value={countries.find(({ value }) => props.value === value) ?? null}
    />
  );
}
