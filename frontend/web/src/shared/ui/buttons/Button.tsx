import MuiButton from "@mui/material/Button";
import React from "react";

interface PrimaryButtonProps {
  children: any;
  onClick: any;
  disabled?: boolean;
}

const PrimaryButton = (props: PrimaryButtonProps) => {
  const { children, onClick, disabled } = props;
  return (
    <MuiButton style={{ width: "100%" }} onClick={onClick} disabled={disabled}>
      {children}
    </MuiButton>
  );
};

export default PrimaryButton;
