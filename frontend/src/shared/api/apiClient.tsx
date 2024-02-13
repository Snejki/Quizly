import axios, { isAxiosError } from "axios";
import { isApiErrorResponse } from "./apiException";
import { toastError } from "../toast/toast";

const apiClient = axios.create({});

apiClient.interceptors.response.use(
  (response) => response,
  (error) => {
    if (isAxiosError(error)) {
      const errorResponse = error.response?.data;
      if (isApiErrorResponse(errorResponse)) {
        toastError(errorResponse.message);
        return Promise.reject(error);
      }
    }

    toastError(error.message);
    return Promise.reject(error);
  }
);

export default apiClient;
