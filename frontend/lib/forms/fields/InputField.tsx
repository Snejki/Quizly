import { FormLabel, Input } from "@chakra-ui/react";
import React from "react";
import { WrappedComponentProps } from "../withControlledField";

const InputField = ({ label, error, ...other }: WrappedComponentProps) => {
  return (
    <>
      <FormLabel>{label}</FormLabel>
      <Input {...other} isInvalid={!!error} />
      {error && <>{error.message}</>}
    </>
  );
};

export default InputField;
