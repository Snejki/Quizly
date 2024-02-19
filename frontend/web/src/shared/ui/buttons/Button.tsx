import MuiButton from "@mui/material/Button";
import React from "react";

interface PrimaryButtonProps {
  children: any;
  onClick?: any;
  disabled?: boolean;
  variant?: string
}

const PrimaryButton = (props: PrimaryButtonProps) => {
  const { children, onClick, disabled } = props;
  return (
    <MuiButton onClick={onClick} disabled={disabled} variant="contained">
      {children}
    </MuiButton>
  );
};

export default PrimaryButton;
