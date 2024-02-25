import { AppBar, Box, Toolbar, Typography } from "@mui/material";
import React from "react";
import AuthenticatedUser from "./components/AuthenticatedUserBox";
import NotAuthenticatedUserBox from "./components/NotAuthenticatedUserBox";
import { useAuthSession } from "@/shared/auth/useAuthSession";

const NavBar = () => {
  const { isAuthenticated, user } = useAuthSession();
  console.log(user);


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
