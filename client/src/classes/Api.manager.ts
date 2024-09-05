import RequestHandlers from "~/classes/requests/Request.handlers.ts";
import tokenStorage from "~/classes/storage/Token.storage.ts";
import apiUrl from "~/constants/const/api.url.ts";
import { Api } from "~/types/api/api_types.ts";

class ApiManager {
  private api: Api<any>;
  public authentication: Api<any>["authentication"];
  public city: Api<any>["city"];
  public company: Api<any>["company"];
  public country: Api<any>["country"];
  public user: Api<any>["user"];

  public constructor() {
    this.api = new Api({
      baseURL: apiUrl,
    });
    this.authentication = this.api.authentication;
    this.company = this.api.company;
    this.user = this.api.user;
    this.country = this.api.country;
    this.city = this.api.city;
    this.setErrorHandling();
    if (tokenStorage.exists()) {
      this.setToken(tokenStorage.get()!);
    }
  }

  private setErrorHandling() {
    this.api.instance.interceptors.response.use(RequestHandlers.success, RequestHandlers.fail);
  }

  public setToken(token: string) {
    this.api.instance.defaults.headers.Authorization = `Bearer ${token}`;
  }
}

export default new ApiManager();
