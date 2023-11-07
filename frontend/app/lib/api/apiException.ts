type BadRequestErrorResponse = {
  code: "QuizlyException";
  message: string;
};

type ValidationErrorResponse = {
  code: "ValidationException";
  message: string;
  errors: {
    errorMessage: string;
    propertyName: string;
  }[];
};

type InternalServerErrorResponse = {
  code: "unexpected_error";
  message: string;
};

export type ErrorResponse =
  | BadRequestErrorResponse
  | ValidationErrorResponse
  | InternalServerErrorResponse;

export const isValidationError = (
  error: ErrorResponse
): error is ValidationErrorResponse => {
  return error.code == "ValidationException";
};

export const isApiErrorResponse = (error: any): error is ErrorResponse => {
  // TODO: to implement
  return true;
};
