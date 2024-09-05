import RoutesPath from "~/constants/enums/routes.path.ts";

enum RoutesUrl {
  Account = `/${RoutesPath.Account}`,
  Clients = `/${RoutesPath.Clients}`,
  ForgotPassword = `/${RoutesPath.ForgotPassword}`,
  Home = `/${RoutesPath.Home}`,
  Invoices = `/${RoutesPath.Invoices}`,
  Legal = `/${RoutesPath.Legal}`,
  Login = `/${RoutesPath.Login}`,
  Quotes = `/${RoutesPath.Quotes}`,
  Register = `/${RoutesPath.Register}`,
}

export default RoutesUrl;
