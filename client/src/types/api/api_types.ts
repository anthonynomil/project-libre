/* eslint-disable */
/* tslint:disable */
/*
 * ---------------------------------------------------------------
 * ## THIS FILE WAS GENERATED VIA SWAGGER-TYPESCRIPT-API        ##
 * ##                                                           ##
 * ## AUTHOR: acacode                                           ##
 * ## SOURCE: https://github.com/acacode/swagger-typescript-api ##
 * ---------------------------------------------------------------
 */

export interface AddressDto {
  /** @format int32 */
  id?: number;
  city?: CityDto;
  /** @format int32 */
  number?: number;
  numberComplement?: string | null;
  road?: string | null;
}

export interface AddressDtoCreate {
  /** @format int32 */
  cityId?: number;
  /** @format int32 */
  number?: number;
  numberComplement?: string | null;
  road?: string | null;
}

export interface AuthenticationDto {
  user?: UserDto;
  token?: string | null;
}

export interface AuthenticationDtoIEnvelop {
  value?: AuthenticationDto;
  /** @format date-time */
  generatedAt?: string;
  message?: string | null;
  warnings?: string[] | null;
}

export interface AuthenticationDtoLogin {
  /** @format email */
  email?: string | null;
  /**
   * @minLength 8
   * @maxLength 64
   */
  password?: string | null;
}

export interface BankDetailsDto {
  /** @format int32 */
  id?: number;
  bic?: string | null;
  iban?: string | null;
}

export interface BankDetailsDtoCreate {
  bic?: string | null;
  iban?: string | null;
}

export interface CityDto {
  /** @format int32 */
  id?: number;
  name?: string | null;
  postalCode?: string | null;
}

export interface CityDtoIEnumerableIEnvelop {
  value?: CityDto[] | null;
  /** @format date-time */
  generatedAt?: string;
  message?: string | null;
  warnings?: string[] | null;
}

export interface CityDtoIEnvelop {
  value?: CityDto;
  /** @format date-time */
  generatedAt?: string;
  message?: string | null;
  warnings?: string[] | null;
}

export interface ClientContactDto {
  /** @format int32 */
  id?: number;
  firstname?: string | null;
  lastname?: string | null;
  /** @format date */
  birthdate?: string | null;
  country?: CountryDto;
  address?: AddressDto;
  contactInformation?: ContactInformationDto;
}

export interface ClientContactDtoCreate {
  firstname?: string | null;
  lastname?: string | null;
  /** @format date */
  birthdate?: string | null;
  /** @format int32 */
  countryId?: number | null;
  address?: AddressDtoCreate;
  contactInformation?: ContactInformationDtoCreate;
}

export interface ClientFinancialInformationDto {
  /** @format int32 */
  id?: number;
  /** @format int32 */
  budget?: number;
  paymentMethod?: PaymentMethodEnum;
}

export interface ClientFinancialInformationDtoCreate {
  /** @format int32 */
  budget?: number;
  paymentMethod?: PaymentMethodEnum;
}

export interface CompanyDto {
  /** @format int32 */
  id?: number;
  businessName?: string | null;
  country?: CountryDto;
  address?: AddressDto;
  bankDetails?: BankDetailsDto;
  contacts?: ClientContactDto[] | null;
  financialInformation?: ClientFinancialInformationDto;
}

export interface CompanyDtoCreate {
  businessName?: string | null;
  /** @format int32 */
  countryId?: number | null;
  address?: AddressDtoCreate;
  bankDetails?: BankDetailsDtoCreate;
  contacts?: ClientContactDtoCreate[] | null;
  financialInformation?: ClientFinancialInformationDtoCreate;
}

export interface CompanyDtoIEnumerableIEnvelop {
  value?: CompanyDto[] | null;
  /** @format date-time */
  generatedAt?: string;
  message?: string | null;
  warnings?: string[] | null;
}

export interface CompanyDtoIEnvelop {
  value?: CompanyDto;
  /** @format date-time */
  generatedAt?: string;
  message?: string | null;
  warnings?: string[] | null;
}

export type CompanyDtoUpdate = object;

export interface ContactInformationDto {
  /** @format int32 */
  id?: number;
  mailAddress?: string | null;
  phoneNumber?: string | null;
}

export interface ContactInformationDtoCreate {
  mailAddress?: string | null;
  phoneNumber?: string | null;
}

export interface CountryDto {
  /** @format int32 */
  id?: number;
  name?: string | null;
  flagSvg?: string | null;
}

export interface CountryDtoIEnumerableIEnvelop {
  value?: CountryDto[] | null;
  /** @format date-time */
  generatedAt?: string;
  message?: string | null;
  warnings?: string[] | null;
}

export interface CountryDtoIEnvelop {
  value?: CountryDto;
  /** @format date-time */
  generatedAt?: string;
  message?: string | null;
  warnings?: string[] | null;
}

export interface IEnvelop {
  /** @format date-time */
  generatedAt?: string;
  message?: string | null;
  warnings?: string[] | null;
}

/** @format int32 */
export enum PaymentMethodEnum {
  Cash = 1,
  Card = 2,
}

export interface UserDto {
  /** @format int32 */
  id?: number;
  email?: string | null;
  firstname?: string | null;
  lastname?: string | null;
  userRoles?: UserRoleDto[] | null;
  /** @format date */
  birthdate?: string | null;
  country?: CountryDto;
  address?: AddressDto;
  contactInformation?: ContactInformationDto;
}

export interface UserDtoCreate {
  firstname?: string | null;
  lastname?: string | null;
  /** @format date */
  birthdate?: string | null;
  /** @format int32 */
  countryId?: number | null;
  address?: AddressDtoCreate;
  contactInformation?: ContactInformationDtoCreate;
  /**
   * @format email
   * @minLength 1
   */
  email: string;
  /**
   * @minLength 8
   * @maxLength 64
   */
  password: string;
}

export interface UserDtoIEnumerableIEnvelop {
  value?: UserDto[] | null;
  /** @format date-time */
  generatedAt?: string;
  message?: string | null;
  warnings?: string[] | null;
}

export interface UserDtoIEnvelop {
  value?: UserDto;
  /** @format date-time */
  generatedAt?: string;
  message?: string | null;
  warnings?: string[] | null;
}

export interface UserDtoUpdate {
  /** @format email */
  email?: string | null;
  /**
   * @minLength 8
   * @maxLength 64
   */
  password?: string | null;
}

export interface UserRoleDto {
  /** @format int32 */
  id?: number;
  value?: UserRoleEnum;
}

/** @format int32 */
export enum UserRoleEnum {
  Admin = 0,
  User = 1,
}

import type { AxiosInstance, AxiosRequestConfig, HeadersDefaults, ResponseType } from "axios";
import axios from "axios";

export type QueryParamsType = Record<string | number, any>;

export interface FullRequestParams extends Omit<AxiosRequestConfig, "data" | "params" | "url" | "responseType"> {
  /** set parameter to `true` for call `securityWorker` for this request */
  secure?: boolean;
  /** request path */
  path: string;
  /** content type of request body */
  type?: ContentType;
  /** query params */
  query?: QueryParamsType;
  /** format of response (i.e. response.json() -> format: "json") */
  format?: ResponseType;
  /** request body */
  body?: unknown;
}

export type RequestParams = Omit<FullRequestParams, "body" | "method" | "query" | "path">;

export interface ApiConfig<SecurityDataType = unknown> extends Omit<AxiosRequestConfig, "data" | "cancelToken"> {
  securityWorker?: (
    securityData: SecurityDataType | null,
  ) => Promise<AxiosRequestConfig | void> | AxiosRequestConfig | void;
  secure?: boolean;
  format?: ResponseType;
}

export enum ContentType {
  Json = "application/json",
  FormData = "multipart/form-data",
  UrlEncoded = "application/x-www-form-urlencoded",
  Text = "text/plain",
}

export class HttpClient<SecurityDataType = unknown> {
  public instance: AxiosInstance;
  private securityData: SecurityDataType | null = null;
  private securityWorker?: ApiConfig<SecurityDataType>["securityWorker"];
  private secure?: boolean;
  private format?: ResponseType;

  constructor({ securityWorker, secure, format, ...axiosConfig }: ApiConfig<SecurityDataType> = {}) {
    this.instance = axios.create({ ...axiosConfig, baseURL: axiosConfig.baseURL || "" });
    this.secure = secure;
    this.format = format;
    this.securityWorker = securityWorker;
  }

  public setSecurityData = (data: SecurityDataType | null) => {
    this.securityData = data;
  };

  protected mergeRequestParams(params1: AxiosRequestConfig, params2?: AxiosRequestConfig): AxiosRequestConfig {
    const method = params1.method || (params2 && params2.method);

    return {
      ...this.instance.defaults,
      ...params1,
      ...(params2 || {}),
      headers: {
        ...((method && this.instance.defaults.headers[method.toLowerCase() as keyof HeadersDefaults]) || {}),
        ...(params1.headers || {}),
        ...((params2 && params2.headers) || {}),
      },
    };
  }

  protected stringifyFormItem(formItem: unknown) {
    if (typeof formItem === "object" && formItem !== null) {
      return JSON.stringify(formItem);
    } else {
      return `${formItem}`;
    }
  }

  protected createFormData(input: Record<string, unknown>): FormData {
    return Object.keys(input || {}).reduce((formData, key) => {
      const property = input[key];
      const propertyContent: any[] = property instanceof Array ? property : [property];

      for (const formItem of propertyContent) {
        const isFileType = formItem instanceof Blob || formItem instanceof File;
        formData.append(key, isFileType ? formItem : this.stringifyFormItem(formItem));
      }

      return formData;
    }, new FormData());
  }

  public request = async <T = any, _E = any>({
    secure,
    path,
    type,
    query,
    format,
    body,
    ...params
  }: FullRequestParams): Promise<T> => {
    const secureParams =
      ((typeof secure === "boolean" ? secure : this.secure) &&
        this.securityWorker &&
        (await this.securityWorker(this.securityData))) ||
      {};
    const requestParams = this.mergeRequestParams(params, secureParams);
    const responseFormat = format || this.format || undefined;

    if (type === ContentType.FormData && body && body !== null && typeof body === "object") {
      body = this.createFormData(body as Record<string, unknown>);
    }

    if (type === ContentType.Text && body && body !== null && typeof body !== "string") {
      body = JSON.stringify(body);
    }

    return this.instance
      .request({
        ...requestParams,
        headers: {
          ...(requestParams.headers || {}),
          ...(type && type !== ContentType.FormData ? { "Content-Type": type } : {}),
        },
        params: query,
        responseType: responseFormat,
        data: body,
        url: path,
      })
      .then((response) => response.data);
  };
}

/**
 * @title Web
 * @version 1.0
 */
export class Api<SecurityDataType extends unknown> extends HttpClient<SecurityDataType> {
  authentication = {
    /**
     * No description
     *
     * @tags Authentication
     * @name LoginCreate
     * @request POST:/Authentication/Login
     * @secure
     */
    loginCreate: (data: AuthenticationDtoLogin, params: RequestParams = {}) =>
      this.request<AuthenticationDtoIEnvelop, IEnvelop>({
        path: `/Authentication/Login`,
        method: "POST",
        body: data,
        secure: true,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),
  };
  city = {
    /**
     * No description
     *
     * @tags City
     * @name CityDetail
     * @request GET:/City/{id}
     * @secure
     */
    cityDetail: (id: number, params: RequestParams = {}) =>
      this.request<CityDtoIEnvelop, IEnvelop>({
        path: `/City/${id}`,
        method: "GET",
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags City
     * @name CityList
     * @request GET:/City
     * @secure
     */
    cityList: (
      query?: {
        /** @format int32 */
        limit?: number;
        /** @format int32 */
        page?: number;
      },
      params: RequestParams = {},
    ) =>
      this.request<CityDtoIEnumerableIEnvelop, any>({
        path: `/City`,
        method: "GET",
        query: query,
        secure: true,
        format: "json",
        ...params,
      }),
  };
  company = {
    /**
     * No description
     *
     * @tags Company
     * @name CompanyDetail
     * @request GET:/Company/{id}
     * @secure
     */
    companyDetail: (id: number, params: RequestParams = {}) =>
      this.request<CompanyDtoIEnvelop, IEnvelop>({
        path: `/Company/${id}`,
        method: "GET",
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Company
     * @name CompanyPartialUpdate
     * @request PATCH:/Company/{id}
     * @secure
     */
    companyPartialUpdate: (id: number, data: CompanyDtoUpdate, params: RequestParams = {}) =>
      this.request<IEnvelop, IEnvelop>({
        path: `/Company/${id}`,
        method: "PATCH",
        body: data,
        secure: true,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Company
     * @name CompanyDelete
     * @request DELETE:/Company/{id}
     * @secure
     */
    companyDelete: (id: number, params: RequestParams = {}) =>
      this.request<IEnvelop, IEnvelop>({
        path: `/Company/${id}`,
        method: "DELETE",
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Company
     * @name CompanyList
     * @request GET:/Company
     * @secure
     */
    companyList: (
      query?: {
        /** @format int32 */
        limit?: number;
        /** @format int32 */
        page?: number;
      },
      params: RequestParams = {},
    ) =>
      this.request<CompanyDtoIEnumerableIEnvelop, any>({
        path: `/Company`,
        method: "GET",
        query: query,
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Company
     * @name CreateCreate
     * @request POST:/Company/Create
     * @secure
     */
    createCreate: (data: CompanyDtoCreate, params: RequestParams = {}) =>
      this.request<IEnvelop, IEnvelop>({
        path: `/Company/Create`,
        method: "POST",
        body: data,
        secure: true,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),
  };
  country = {
    /**
     * No description
     *
     * @tags Country
     * @name CountryDetail
     * @request GET:/Country/{id}
     * @secure
     */
    countryDetail: (id: number, params: RequestParams = {}) =>
      this.request<CountryDtoIEnvelop, IEnvelop>({
        path: `/Country/${id}`,
        method: "GET",
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Country
     * @name CountryList
     * @request GET:/Country
     * @secure
     */
    countryList: (
      query?: {
        /** @format int32 */
        limit?: number;
        /** @format int32 */
        page?: number;
      },
      params: RequestParams = {},
    ) =>
      this.request<CountryDtoIEnumerableIEnvelop, any>({
        path: `/Country`,
        method: "GET",
        query: query,
        secure: true,
        format: "json",
        ...params,
      }),
  };
  user = {
    /**
     * No description
     *
     * @tags User
     * @name UserDetail
     * @request GET:/User/{id}
     * @secure
     */
    userDetail: (id: number, params: RequestParams = {}) =>
      this.request<UserDtoIEnvelop, IEnvelop>({
        path: `/User/${id}`,
        method: "GET",
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags User
     * @name UserPartialUpdate
     * @request PATCH:/User/{id}
     * @secure
     */
    userPartialUpdate: (id: number, data: UserDtoUpdate, params: RequestParams = {}) =>
      this.request<IEnvelop, IEnvelop>({
        path: `/User/${id}`,
        method: "PATCH",
        body: data,
        secure: true,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags User
     * @name UserDelete
     * @request DELETE:/User/{id}
     * @secure
     */
    userDelete: (id: number, params: RequestParams = {}) =>
      this.request<IEnvelop, IEnvelop>({
        path: `/User/${id}`,
        method: "DELETE",
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags User
     * @name UserList
     * @request GET:/User
     * @secure
     */
    userList: (
      query?: {
        /** @format int32 */
        limit?: number;
        /** @format int32 */
        page?: number;
      },
      params: RequestParams = {},
    ) =>
      this.request<UserDtoIEnumerableIEnvelop, any>({
        path: `/User`,
        method: "GET",
        query: query,
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags User
     * @name CreateCreate
     * @request POST:/User/Create
     * @secure
     */
    createCreate: (data: UserDtoCreate, params: RequestParams = {}) =>
      this.request<IEnvelop, IEnvelop>({
        path: `/User/Create`,
        method: "POST",
        body: data,
        secure: true,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),
  };
}
