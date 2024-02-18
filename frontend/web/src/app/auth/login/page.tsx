"use client";

import React from "react";
import { TextFieldControlled } from "@/shared/form";
import Button from "@/shared/ui/buttons/Button";
import { zodResolver } from "@hookform/resolvers/zod";
import { Container } from "@mui/material";
import Grid2 from "@mui/material/Unstable_Grid2/Grid2";
import type { InferGetServerSidePropsType } from "next";
import { getCsrfToken, signIn, useSession } from "next-auth/react";
import { FormProvider, useForm } from "react-hook-form";
import { z } from "zod";

export default function Page({ csrfToken }: InferGetServerSidePropsType<any>) {
  const form = useForm<LoginUserForm>({
    mode: "onChange",
    resolver: zodResolver(validationSchema),
  });

  const session = useSession();

  const onSubmit = async (f: LoginUserForm) => {
    await signIn("credentials", {
      username: f.login,
      password: f.password,
      redirect: true,
    });
  };

  return (
    <FormProvider {...form}>
      <Grid2 container>
        <Grid2 xs={4} xsOffset={4}>
          <TextFieldControlled name="login" type="text" label="login" />
          <TextFieldControlled
            id="password"
            name="password"
            type="password"
            label="password"
          />
          <Button onClick={form.handleSubmit(onSubmit)} disabled={!form.formState.errors}>Login</Button>
        </Grid2>
      </Grid2>
    </FormProvider>
  );
}

const validationSchema = z.object({
  login: z.string().min(0).max(2),
  password: z.string().min(0).max(2),
});

type LoginUserForm = z.infer<typeof validationSchema>;
