// import { Button, Container, FormControl } from "@chakra-ui/react";
// import { zodResolver } from "@hookform/resolvers/zod";
// import React from "react";
// import { FormProvider, UseFormSetError, useForm } from "react-hook-form";
// import { z } from "zod";
// import {InputFieldControlled } from '../../../../components/fields/index'

// const LoginUserPage = () => {
//   const formMethods = useForm<LoginUserForm>({
//     mode: "onChange",
//     resolver: zodResolver(validationSchema),
//   });

//   const onLoginButtonClick = async (form: LoginUserForm) => {
//     try {
//       const loginResponse = await loginUser(form);
//       localStorage.setItem("token", loginResponse.token);
//     } catch (error) {
//       handleValidationErrors(error, formMethods.setError);
//     }
//   };

//   return (
//     <Container>
//       <FormProvider {...formMethods}>
//         <FormControl mt="3">
//           <InputFieldControlled name="login" type="text" placeholder="Login" />
//         </FormControl>
//         <FormControl mt="3">
//           <InputFieldControlled
//             name="password"
//             type="password"
//             placeholder="Password"
//           />
//         </FormControl>
//         <FormControl mt="3">
//           <Button
//             colorScheme="yellow"
//             onClick={formMethods.handleSubmit(onLoginButtonClick)}
//             width="100%"
//           >
//             Login
//           </Button>
//         </FormControl>
//       </FormProvider>
//     </Container>
//   );
// };

// export default LoginUserPage;

// const validationSchema = z.object({
//   login: z.string().min(0),
//   password: z.string().min(0),
// });

// type LoginUserForm = z.infer<typeof validationSchema>;


// function handleValidationErrors(error: any, setError: UseFormSetError<{ login: string; password: string; }>) {
//   throw new Error("Function not implemented.");
// }

// function loginUser(form: { login: string; password: string; }) {
//   throw new Error("Function not implemented.");
// }
import type {
  GetServerSidePropsContext,
  InferGetServerSidePropsType,
} from "next"
import { getCsrfToken, signIn } from "next-auth/react"

export default function SignIn({
  csrfToken,
}: InferGetServerSidePropsType<typeof getServerSideProps>) {
  const signInn = () => signIn("credentials", { username: "jsmith", password: "1234" });

  return (

    <form >
      <input name="csrfToken" type="hidden" defaultValue={csrfToken} />
      <label>
        Username
        <input name="username" type="text" />
      </label>
      <label>
        Password
        <input name="password" type="password" />
      </label>
      <button type="submit" onClick={() => signInn()}>Sign in</button>
    </form>
  )
}

export async function getServerSideProps(context: GetServerSidePropsContext) {
  return {
    props: {
      csrfToken: await getCsrfToken(context),
    },
  }
}
