"use client";

import { registerUserService } from "@/lib/user/userService";
import { TextFieldControlled } from "@/shared/form";
import { useSnackbarNotifications } from "@/shared/notifications/SnackBarNotifications";
import PrimaryButton from "@/shared/ui/buttons/Button";
import { zodResolver } from "@hookform/resolvers/zod";
import { Stack } from "@mui/material";
import { useMutation } from "@tanstack/react-query";
import React, { Suspense } from "react";
import { FormProvider, useForm } from "react-hook-form";
import { z } from "zod";

const Page = () => {
  const form = useForm<RegisterUserForm>({
    mode: "onChange",
    resolver: zodResolver(validationSchema),
  });


  const registerUserMutation = useMutation({
    mutationFn: registerUserService,
    retry: 2,
  });

  const { displaySuccessNotification } = useSnackbarNotifications();


  const registerUser = async (formData: RegisterUserForm) => {
    try {
      await registerUserMutation.mutate(formData);
    } catch (e) {
      console.log(e);
    }
  };

  return (
    <FormProvider {...form}>
      <Suspense fallback={<div>Loading...</div>} >
        <Stack
          justifyContent="center"
          alignItems="center"
          sx={{ width: 1, height: "100vh" }}
        >
          <Stack width={"360px"} spacing={2}>
            <TextFieldControlled
              id="email"
              name="email"
              type="email"
              label="Email"
            />
            <TextFieldControlled
              id="login"
              name="login"
              type="text"
              label="Login"
            />
            <TextFieldControlled
              id="password"
              name="password"
              type="password"
              label="Password"
            />
            <TextFieldControlled
              id="confirmPassword"
              name="confirmPassword"
              type="password"
              label="Confirm Password"
            />
            <PrimaryButton onClick={form.handleSubmit(registerUser)}>
              Register
            </PrimaryButton>
          </Stack>
        </Stack>
      </Suspense>
    </FormProvider>
  );
};

type RegisterUserForm = z.infer<typeof validationSchema>;

const validationSchema = z
  .object({
    email: z.string().email(),
    login: z.string().min(8).max(24),
    password: z.string().min(8),
    confirmPassword: z.string(),
  })
  .refine((data) => data.password === data.confirmPassword, {
    message: "Password must be the same",
    path: ["confirmPassword"],
  });

export default Page;
