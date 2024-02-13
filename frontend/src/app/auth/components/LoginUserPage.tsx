import { InputFieldControlled } from "@/components/fields";
import { handleValidationErrors } from "@/shared/api/apiException";
import { loginUser } from "@/shared/api/auth/authActions";
import { Button, Container, FormControl } from "@chakra-ui/react";
import { zodResolver } from "@hookform/resolvers/zod";
import React from "react";
import { FormProvider, useForm } from "react-hook-form";
import { z } from "zod";

const LoginUserPage = () => {
  const formMethods = useForm<LoginUserForm>({
    mode: "onChange",
    resolver: zodResolver(validationSchema),
  });

  const onLoginButtonClick = async (form: LoginUserForm) => {
    try {
      const loginResponse = await loginUser(form);
      localStorage.setItem("token", loginResponse.token);
    } catch (error) {
      handleValidationErrors(error, formMethods.setError);
    }
  };

  return (
    <Container>
      <FormProvider {...formMethods}>
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
          <Button
            colorScheme="yellow"
            onClick={formMethods.handleSubmit(onLoginButtonClick)}
            width="100%"
          >
            Login
          </Button>
        </FormControl>
      </FormProvider>
    </Container>
  );
};

export default LoginUserPage;

const validationSchema = z.object({
  login: z.string().min(0),
  password: z.string().min(0),
});

type LoginUserForm = z.infer<typeof validationSchema>;
