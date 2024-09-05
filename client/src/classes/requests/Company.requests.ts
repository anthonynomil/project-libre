import type { CompanyDtoCreate } from "~/types/api/api_types.ts";

import apiManager from "~/classes/Api.manager.ts";

export default class CompanyRequests {
  public static create(data: CompanyDtoCreate) {
    return apiManager.company.createCreate(data);
  }

  public static getAll() {
    return apiManager.company.companyList();
  }

  public static getById(id: number) {
    return apiManager.company.companyDetail(id);
  }
}
