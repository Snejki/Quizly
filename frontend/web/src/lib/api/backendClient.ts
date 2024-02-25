import { getAuthTokens } from "@/shared/auth/useAuthSession";
import axios, { InternalAxiosRequestConfig } from "axios";

const backendClient = axios.create({
  // todo: to environment
  baseURL: "http://localhost:5215/",
});


const accessTokenInterceptor = async (
  config: InternalAxiosRequestConfig<any>
) => {
  const { jwt } = await getAuthTokens();
  if(jwt !== undefined) {
    config.headers["Authorization"] = "Bearer: " + jwt;
  }

  return config;
};

backendClient.interceptors.request.use(accessTokenInterceptor);

export { backendClient };
