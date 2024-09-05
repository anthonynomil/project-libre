import AccountSchema from "~/classes/schemas/base/Account.schema.ts";
import AddressSchema from "~/classes/schemas/base/Address.schema.ts";
import CitySchema from "~/classes/schemas/base/City.schema.ts";
import ClientSchema from "~/classes/schemas/base/Client.schema.ts";
import HelpersSchema from "~/classes/schemas/base/Helpers.schema.ts";

export default class BaseSchemas {
  public static readonly Account = AccountSchema;
  public static readonly Address = AddressSchema;
  public static readonly City = CitySchema;
  public static readonly Client = ClientSchema;
  public static readonly Helpers = HelpersSchema;
}
