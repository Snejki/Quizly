import { Alert, AlertColor, Snackbar } from "@mui/material";
import { createContext, useContext, useState } from "react";
import React from "react";

const SnackbarNotificationContext = createContext<
  { displaySuccessNotification: Function } | undefined
>(undefined);

type Props = {
  children: any;
};

export const useSnackbarNotifications = () => {
  const context = useContext(SnackbarNotificationContext);

  if (!context) {
    throw new Error("You can not use this hook outside of the provider");
  }

  return context;
};

const SnackbarNotificationProvider = (props: Props) => {
  const [show, setShow] = useState(false);
  const [message, setMessage] = useState<{
    text: string;
    severity: AlertColor;
  }>();
  console.log(show);
  const displaySuccessNotification = (messageText: string) => {
    setMessage({ text: messageText, severity: "success" });
    setShow(true);
  };

  return (
    <SnackbarNotificationContext.Provider
      value={{ displaySuccessNotification }}
    >
      {props.children}
      <Snackbar
        open={show}
        autoHideDuration={6000}
        onClose={() => {
          setShow(false);
        }}
      >
        <Alert severity={message?.severity}>{message?.text}</Alert>
      </Snackbar>
    </SnackbarNotificationContext.Provider>
  );
};

export default SnackbarNotificationProvider;
