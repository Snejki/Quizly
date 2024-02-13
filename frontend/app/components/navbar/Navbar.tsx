"use client";

import { Button, Container, Flex, Switch } from '@chakra-ui/react'
import Link from 'next/link'
import React from 'react'

const Navbar = () => {
  return (
    <Flex>
    <Flex position="fixed" top="1rem" right="1rem" align="center">
      {/* Desktop */}
      <Flex>
        <Link href="/" passHref>
          <Button as="a" variant="ghost" aria-label="Home" my={5} w="100%">
            Home
          </Button>
        </Link>
    
        <Link href="/about" passHref>
          <Button as="a" variant="ghost" aria-label="About" my={5} w="100%">
            About
          </Button>
        </Link>
    
        <Link href="/contact" passHref>
          <Button as="a" aria-label="Contact" my={5} w="100%">
            Contact
          </Button>
        </Link>
        <Button colorScheme='teal' size='xs'>
    Button
  </Button>      </Flex>
    
      {/* Mobile */}
      <Switch color="green" />
    </Flex>
    {/* Mobile Content */}
    </Flex>
   
  )
}

export default Navbar
