'use client';

import React from 'react';
import { FormLabel, Input, InputProps } from '@chakra-ui/react';
import {
  Controller,
  FieldValues,
  RegisterOptions,
  useFormContext,
} from 'react-hook-form';

interface FormProps {
  name: string;
  rules?:
    | Omit<
        RegisterOptions<FieldValues, string>,
        'valueAsNumber' | 'valueAsDate' | 'setValueAs' | 'disabled'
      >
    | undefined;
}

interface CustomProps {
  label: string;
}

type ControlledInputProps = FormProps & CustomProps & InputProps;

const InputControlledField = ({
  name,
  rules,
  label,
  ...other
}: ControlledInputProps) => {
  const { control } = useFormContext();
  return (
    <Controller
      name={name}
      control={control}
      rules={rules}
      shouldUnregister
      defaultValue={''}
      render={({ field: { onChange, onBlur, value }, fieldState }) => {
        return (
          <>
            <FormLabel>{label}</FormLabel>
            <Input
              onChange={onChange}
              onBlur={onBlur}
              isInvalid={!!fieldState.error}
              value={value}
              {...other}
            />
            {fieldState.error && <>{fieldState.error.message}</>}
          </>
        );
      }}
    />
  );
};

export default InputControlledField;
