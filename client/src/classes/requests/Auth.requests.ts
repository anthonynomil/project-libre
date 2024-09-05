import type { AuthenticationDtoLogin, UserDtoCreate } from "~/types/api/api_types.ts";

import apiManager from "~/classes/Api.manager.ts";

export default class AuthRequests {
  public static async login(data: AuthenticationDtoLogin) {
    return apiManager.authentication.loginCreate(data);
  }

  public static async logout(): Promise<void> {}

  public static async register(data: UserDtoCreate) {
    return apiManager.user.createCreate(data);
  }
}
