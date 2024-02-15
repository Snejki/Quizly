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

// export type WrappedComponentProps = InputProps & {
//   error: FieldError | undefined;
// };
// type ComponentProps = FormProps & InputProps;

export default function withControlledField(
  WrappedComponent: React.FC<any>
) {
  const Component = ({ name, rules, ...other }: any) => {
    const { control } = useFormContext();
    return (
      <Controller
        name={name}
        control={control}
        rules={rules}
        shouldUnregister
        defaultValue={""}
        render={({ field: { onChange, onBlur, value }, fieldState }) => {
          console.log(fieldState)
          return (
            <WrappedComponent
              onChange={onChange}
              onBlur={onBlur}
              value={value}
              {...other}
              name={name}
              error={fieldState.error?.message}
            />
          );
        }}
      />
    );
  };
  Component.displayName = `reactFormControlled(${WrappedComponent.name})`;
  return Component;
}