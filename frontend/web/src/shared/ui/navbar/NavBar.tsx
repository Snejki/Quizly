import { AppBar, Box, Toolbar, Typography } from "@mui/material";
import React from "react";
import useAuthSession from "@/shared/auth/useAuthSession";
import AuthenticatedUser from "./components/AuthenticatedUserBox";
import NotAuthenticatedUserBox from "./components/NotAuthenticatedUserBox";

const NavBar = () => {
  const { isAuthenticated } = useAuthSession();

  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static">
        <Toolbar>
          <Typography sx={{ flexGrow: 1 }}>Quizly</Typography>
          {isAuthenticated ? (
            <AuthenticatedUser />
          ) : (
            <NotAuthenticatedUserBox />
          )}
        </Toolbar>
      </AppBar>
    </Box>
  );
};

export default NavBar;
