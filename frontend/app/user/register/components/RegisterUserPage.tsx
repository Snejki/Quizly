import { createUser } from "@/app/lib/api/user/usersRepository";
import { InputFieldControlled } from "@/lib/forms/fields";
import { Button, Center, FormControl, FormLabel } from "@chakra-ui/react";
import { zodResolver } from "@hookform/resolvers/zod";
import React from "react";
import { FormProvider, useForm } from "react-hook-form";
import { z } from "zod";

const validationSchema = z
  .object({
    email: z.string().email(),
    login: z.string().min(1),
    password: z.string().min(1),
    confirmPassword: z.string(),
  })
  .refine((schema) => schema.password === schema.confirmPassword, {
    message: "Passwords did not match",
    path: ["confirmPassword"],
  });

type RegisterUserForm = z.infer<typeof validationSchema>;

const RegisterUserPage = () => {
  const methods = useForm<RegisterUserForm>({
    mode: "onChange",
    resolver: zodResolver(validationSchema),
  });

  const onSubmit = async (form: RegisterUserForm) => {
    const response = await createUser(form);
  };

  return (
    <>
      <Center>
        <FormProvider {...methods}>
          <FormControl>
            <FormLabel>Email</FormLabel>
            <InputFieldControlled name="email" type="email" />
            <FormLabel>Login</FormLabel>
            <InputFieldControlled name="login" type="text" />
            <FormLabel>Password</FormLabel>
            <InputFieldControlled name="password" type="password" />
            <FormLabel>Confirm Password</FormLabel>
            <InputFieldControlled name="confirmPassword" type="password" />
            <Button colorScheme="blue" onClick={methods.handleSubmit(onSubmit)}>
              Register
            </Button>
          </FormControl>
        </FormProvider>
      </Center>
    </>
  );
};

export default RegisterUserPage;
