"use client";

import {
  InputFieldControlled,
  SelectFieldControlled,
} from "@/lib/forms/fields";
import { Button, Center, FormControl } from "@chakra-ui/react";
import React from "react";
import { FormProvider, useForm } from "react-hook-form";

const Login = () => {
  const methods = useForm({
    mode: "onChange",
  });
  const onSubmit = (data: any) => console.log(data);

  return (
    <>
      <Center>
        <FormProvider {...methods}>
          <FormControl>
            <InputFieldControlled
              name="email"
              label="Email"
              type="text"
              rules={{ validate: { isValid: (value: string) => "ERROR" } }}
            />
            <InputFieldControlled
              name="password"
              label="Password"
              type="password"
            />
            <SelectFieldControlled name="password" label="Password">
              <option value="option1">Option 1</option>
              <option value="option2">Option 2</option>
              <option value="option3">Option 3</option>
            </SelectFieldControlled>
            <Button colorScheme="blue" onClick={methods.handleSubmit(onSubmit)}>
              Submit
            </Button>
          </FormControl>
        </FormProvider>
      </Center>
    </>
  );
};

export default Login;
