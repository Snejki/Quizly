import Button from "@mui/material/Button";
import React from "react";

interface PrimaryButtonProps {
  children: any;
}

const PrimaryButton = (props: PrimaryButtonProps) => {
  const { children } = props;
  return <Button>{children}</Button>;
};

export default PrimaryButton;
