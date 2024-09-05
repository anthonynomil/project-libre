import { z } from "zod";

import AddressSchema from "~/classes/schemas/base/Address.schema.ts";
import CitySchema from "~/classes/schemas/base/City.schema.ts";

export type AddressFormSchema = z.infer<typeof AddressFormStructure.schema>;

export default class AddressFormStructure {
  public static readonly defaultValues: AddressFormSchema = {
    cityId: null as unknown as number,
    number: 0,
    numberComplement: "",
    road: "",
  };

  public static readonly schema = z.object({
    cityId: CitySchema.id,
    number: AddressSchema.number,
    numberComplement: AddressSchema.numberComplement.nullable(),
    road: AddressSchema.road,
  });
}
