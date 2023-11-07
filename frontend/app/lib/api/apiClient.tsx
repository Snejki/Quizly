import axios, { isAxiosError } from "axios";
import {
  CreateStandaloneToastReturn,
  createStandaloneToast,
} from "@chakra-ui/react";
import { isApiErrorResponse } from "./apiException";

const apiClient = axios.create({});
const standaloneToast = createStandaloneToast({});

apiClient.interceptors.response.use(
  (response) => response,
  (error) => {
    if (isAxiosError(error)) {
      const errorResponse = error.response?.data;
      if (isApiErrorResponse(errorResponse)) {
        toastError(standaloneToast, errorResponse.message);
      }
    }

    return Promise.reject(error);
  }
);

export default apiClient;

const toastError = (
  standaloneToast: CreateStandaloneToastReturn,
  title: string
) => {
  standaloneToast.toast({
    title: title,
    colorScheme: "red",
    isClosable: true,
    position: "top-right",
  });
};
