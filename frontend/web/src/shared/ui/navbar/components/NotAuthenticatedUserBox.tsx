import { Box } from '@mui/material'
import React from 'react'
import PrimaryButton from '../../buttons/Button'

interface NotAuthenticatedUserBox {

}

const NotAuthenticatedUserBox = (props: NotAuthenticatedUserBox) => {
  return (
    <Box sx={{ display: { xs: "none", sm: "block" } }}>
      <PrimaryButton>Login</PrimaryButton>
      <PrimaryButton>Register</PrimaryButton>
    </Box>
  )
}

export default NotAuthenticatedUserBox