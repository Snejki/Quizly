"use client";

import React, { useEffect } from "react";
import { TextFieldControlled } from "@/shared/form";
import Button from "@/shared/ui/buttons/Button";
import { zodResolver } from "@hookform/resolvers/zod";
import type { InferGetServerSidePropsType } from "next";
import { FormProvider, useForm } from "react-hook-form";
import { z } from "zod";
import { Stack } from "@mui/material";
import { signIn, useSession } from "next-auth/react";
import { DefaultError, useMutation } from "@tanstack/react-query";
import { LoginUserRequest, LoginUserResponse, loginUserService } from "@/lib/auth/authService";

export default function Page(props: InferGetServerSidePropsType<any>) {
  const { data, status, update} = useSession();

  const form = useForm<LoginUserForm>({
    mode: "onChange",
    resolver: zodResolver(validationSchema),
  });


  useEffect(() => {
    console.log(data);
    console.log(status);
  }, [data, status])

  const loginUser = async (formData: LoginUserForm) => {
    try {
      signIn("credentials", formData);
     
    } catch (error) {
      
    }
  };

  const loginUserMutation = useMutation({
    mutationFn: async (data: LoginUserRequest) => loginUserService(data),
    retry: 2,
  });

  return (
    <FormProvider {...form}>
      <Stack
        justifyContent="center"
        alignItems="center"
        sx={{ width: 1, height: "100vh" }}
      >
        <Stack width={"360px"} spacing={2}>
          <TextFieldControlled name="login" type="text" label="login" />
          <TextFieldControlled
            id="password"
            name="password"
            type="password"
            label="password"
          />
          <Button
            onClick={form.handleSubmit(loginUser)}
            disabled={!form.formState.errors}
          >
            Login
          </Button>
        </Stack>
      </Stack>
    </FormProvider>
  );
}

const validationSchema = z.object({
  login: z.string().min(8),
  password: z.string().min(8),
});

type LoginUserForm = z.infer<typeof validationSchema>;
