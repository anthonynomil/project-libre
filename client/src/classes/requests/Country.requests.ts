import apiManager from "~/classes/Api.manager.ts";

export default class CountryRequests {
  public static getAll() {
    return apiManager.country.countryList({
      limit: 1000,
    });
  }
}
