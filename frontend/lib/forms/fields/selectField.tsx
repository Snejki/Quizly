import { Select } from "@chakra-ui/react";
import React from "react";
import { WrappedComponentProps } from "../withControlledField";

const SelectField = ({ error, ...other }: WrappedComponentProps) => {
  return (
    <>
      <Select placeholder="Select option">{other.children}</Select>
      {error && <>{error.message}</>}
    </>
  );
};

export default SelectField;
