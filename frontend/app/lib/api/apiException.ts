import { isAxiosError } from "axios";
import { FieldValues, UseFormSetError } from "react-hook-form";

const apiErrorResponseCodes = [
  "QuizlyException",
  "ValidationException",
  "unexpected_error",
] as const;
type CodeTuple = typeof apiErrorResponseCodes;

type BadRequestErrorResponse = {
  code: CodeTuple[0];
  message: string;
};

type ValidationErrorResponse = {
  code: CodeTuple[1];
  message: string;
  errors: {
    errorMessage: string;
    propertyName: string;
  }[];
};

type InternalServerErrorResponse = {
  code: CodeTuple[2];
  message: string;
};

export type ErrorResponse =
  | BadRequestErrorResponse
  | ValidationErrorResponse
  | InternalServerErrorResponse;

export const isValidationError = (
  error: ErrorResponse
): error is ValidationErrorResponse => {
  return error && error.code && error.code == apiErrorResponseCodes[1];
};

export const isApiErrorResponse = (error: any): error is ErrorResponse => {
  return apiErrorResponseCodes.includes(error);
};

export function handleValidationErrors<T extends FieldValues>(
  error: any,
  setError: UseFormSetError<T>
) {
  if (isAxiosError(error)) {
    const errorResponse = error.response?.data;
    if (isValidationError(errorResponse)) {
      errorResponse.errors.forEach((element) => {
        // @ts-ignore
        setError(element.propertyName, { message: element.errorMessage });
      });
    }
  }
}
