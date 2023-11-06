import { createUser } from "@/app/lib/api/user/usersRepository";
import { InputFieldControlled } from "@/lib/forms/fields";
import { Button, Center, FormControl } from "@chakra-ui/react";
import { zodResolver } from "@hookform/resolvers/zod";
import React from "react";
import { FormProvider, useForm } from "react-hook-form";
import { z } from "zod";

const validationSchema = z.object({
  email: z.string().email(),
  login: z.string().min(1),
  password: z.string(),
  confirmPassword: z.string(),
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
            <InputFieldControlled name="email" label="Email" type="email" />
            <InputFieldControlled name="login" label="Login" type="text" />
            <InputFieldControlled
              name="password"
              label="Password"
              type="password"
            />
            <InputFieldControlled
              name="confirmPassword"
              label="Confirm password"
              type="password"
            />
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
