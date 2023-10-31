import { Button, Center, FormControl } from '@chakra-ui/react';
import React from 'react';
import { FormProvider, SubmitHandler, useForm } from 'react-hook-form';
import InputControlledField from '../lib/forms/fields/InputControlledField';

const test = () => {
  const methods = useForm({
    mode: 'onChange',
  });
  const onSubmit = (data: any) => console.log(data);

  return (
    <>
      <Center>
        <FormProvider {...methods}>
          <FormControl>
            <InputControlledField
              name="email"
              label="Email"
              type="text"
              rules={{ validate: { isValid: (value: string) => 'ERROR' } }}
            />
            <InputControlledField
              name="password"
              label="Password"
              type="password"
            />
            <Button colorScheme="blue" onClick={methods.handleSubmit(onSubmit)}>
              Submit
            </Button>
          </FormControl>
        </FormProvider>
        {console.log('asd')}
      </Center>
    </>
  );
};

export default test;
