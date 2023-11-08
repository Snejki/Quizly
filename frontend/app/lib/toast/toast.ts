import {
  ThemeTypings,
  ToastPosition,
  createStandaloneToast,
} from "@chakra-ui/react";

const standaloneToast = createStandaloneToast({});

export const toastSuccess = (
  title: React.ReactNode,
  description: React.ReactNode = null,
  isClosable = true,
  duration: number | null = 3000,
  colorScheme: ThemeTypings["colorSchemes"] = "green",
  position: ToastPosition = "top-right"
) => toast(title, description, colorScheme, isClosable, position, duration);

export const toastError = (
  title: React.ReactNode,
  description: React.ReactNode = null,
  isClosable = true,
  duration: number | null = null,
  colorScheme: ThemeTypings["colorSchemes"] = "red",
  position: ToastPosition = "top-right"
) => toast(title, description, colorScheme, isClosable, position, duration);

const toast = (
  title: React.ReactNode,
  description: React.ReactNode,
  colorScheme: ThemeTypings["colorSchemes"],
  isClosable: boolean,
  position: ToastPosition,
  duration: number | null
) => {
  standaloneToast.toast({
    title: title,
    description: description,
    colorScheme: colorScheme,
    isClosable: isClosable,
    position: position,
    duration: duration,
  });
};
