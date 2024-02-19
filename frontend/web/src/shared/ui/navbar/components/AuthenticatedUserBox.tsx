import { Avatar, Box, IconButton, Tooltip } from '@mui/material'
import React from 'react'

interface AuthenticatedUserProps {

}

const AuthenticatedUser = (props: AuthenticatedUserProps) => {
  return (
    <Box sx={{ display: { xs: "none", sm: "block" } }}>
      <Tooltip title="Open settings">
        <IconButton sx={{ p: 0 }}>
          <Avatar alt="Remy Sharp" src="/static/images/avatar/2.jpg" />
        </IconButton>
      </Tooltip>
    </Box>
  )
}

export default AuthenticatedUser