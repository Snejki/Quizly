import { Input } from "@chakra-ui/react";
import React from "react";
import { WrappedComponentProps } from "./withControlledField";

const InputField = ({ error, ...other }: WrappedComponentProps) => {
  return (
    <>
      <Input {...other} isInvalid={!!error} />
      {error && <div style={{ color: "red" }}>{error.message}</div>}
    </>
  );
};

export default InputField;
