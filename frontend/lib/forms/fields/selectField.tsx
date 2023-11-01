import { FormLabel, Select } from "@chakra-ui/react";
import React from "react";
import { WrappedComponentProps } from "../withControlledField";

const SelectField = ({ label, error, ...other }: WrappedComponentProps) => {
  return (
    <>
      <FormLabel>{label}</FormLabel>
      <Select placeholder="Select option">{other.children}</Select>
      {error && <>{error.message}</>}
    </>
  );
};

export default SelectField;
