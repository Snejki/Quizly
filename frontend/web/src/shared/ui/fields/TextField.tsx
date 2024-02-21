import MuiTextField from "@mui/material/TextField";
import React from "react";

export interface TextFieldProps {
  children: any;
  id: string;
  label: string;
  onChange: any;
  onBlur: any;
  value: any;
  name: string;
  error: string
}

const TextField = (props: TextFieldProps) => {
  const { children, id, label, onChange, onBlur, value, name, error } = props;
  return (
    <MuiTextField
      id={id}
      name={name}
      label={label}
      onChange={onChange}
      onBlur={onBlur}
      value={value}
      variant="outlined"
      style={{width: '100%'}}
      error={!!error}
      helperText={error}
    >
      {children}
    </MuiTextField>
  );
};

export default TextField;
