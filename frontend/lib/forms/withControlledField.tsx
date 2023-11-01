import { InputProps } from "@chakra-ui/react";
import React from "react";
import {
  Controller,
  FieldError,
  FieldValues,
  RegisterOptions,
  useFormContext,
} from "react-hook-form";

interface FormProps {
  name: string;
  rules?:
    | Omit<
        RegisterOptions<FieldValues, string>,
        "valueAsNumber" | "valueAsDate" | "setValueAs" | "disabled"
      >
    | undefined;
}

export type WrappedComponentProps = InputProps & {
  error: FieldError | undefined;
  label: string;
};
type ComponentProps = FormProps & InputProps & { label: string };

export default function withControlledField(
  WrappedComponent: React.FC<WrappedComponentProps>
) {
  const Component = ({ name, rules, ...other }: ComponentProps) => {
    const { control } = useFormContext();

    return (
      <Controller
        name={name}
        control={control}
        rules={rules}
        shouldUnregister
        defaultValue={""}
        render={({ field: { onChange, onBlur, value }, fieldState }) => {
          return (
            <WrappedComponent
              onChange={onChange}
              onBlur={onBlur}
              value={value}
              {...other}
              name={name}
              error={fieldState.error}
            />
          );
        }}
      />
    );
  };
  Component.displayName = `reactFormControlled(${WrappedComponent.name})`;
  return Component;
}
