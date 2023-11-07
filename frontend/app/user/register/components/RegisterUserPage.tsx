import { handleValidationErrors } from "@/app/lib/api/apiException";
import { createUser } from "@/app/lib/api/user/usersRepository";
import { toastSuccess } from "@/app/lib/toast/toast";
import { InputFieldControlled } from "@/lib/forms/fields";
import { Button, Container, FormControl } from "@chakra-ui/react";
import { zodResolver } from "@hookform/resolvers/zod";
import { useRouter } from "next/navigation";
import React from "react";
import { FormProvider, useForm } from "react-hook-form";
import { z } from "zod";

const RegisterUserPage = () => {
  const methods = useForm<RegisterUserForm>({
    mode: "onChange",
    resolver: zodResolver(validationSchema),
  });
  const { push } = useRouter();

  const onSubmit = async (form: RegisterUserForm) => {
    try {
      await createUser(form);
      toastSuccess("You created account");
      push("/index");
    } catch (error) {
      handleValidationErrors(error, methods.setError);
    }
  };

  return (
    <Container>
      <FormProvider {...methods}>
        <FormControl mt="3">
          <InputFieldControlled name="email" type="email" placeholder="Email" />
        </FormControl>
        <FormControl mt="3">
          <InputFieldControlled name="login" type="text" placeholder="Login" />
        </FormControl>
        <FormControl mt="3">
          <InputFieldControlled
            name="password"
            type="password"
            placeholder="Password"
          />
        </FormControl>
        <FormControl mt="3">
          <InputFieldControlled
            name="confirmPassword"
            type="password"
            placeholder="Confirm password"
          />
        </FormControl>
        <FormControl mt="3">
          <Button
            colorScheme="yellow"
            onClick={methods.handleSubmit(onSubmit)}
            width="100%"
          >
            Register
          </Button>
        </FormControl>
      </FormProvider>
    </Container>
  );
};

export default RegisterUserPage;

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
