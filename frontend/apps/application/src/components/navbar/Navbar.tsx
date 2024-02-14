"use client";

import { Button, Container, Flex, Switch } from "@chakra-ui/react";
import Link from "next/link";
import React from "react";

const Navbar = () => {
  return (
    <Flex>
      <Flex
        position="fixed"
        right="1rem"
        align="center"
        bgColor={"red"}
        w={"100%"}
        h={"60px"}
        justifyContent="space-between"
      >
        {/* Desktop */}
        <Flex></Flex>
        <Flex>
          <Link href="/auth/login" passHref>
            <Button as="a" variant="ghost" aria-label="About" my={5} w="100%">
              Login
            </Button>
          </Link>
          <Link href="/register" passHref>
            <Button as="a" aria-label="Contact" my={5} w="100%">
              Register
            </Button>
          </Link>
        </Flex>
      </Flex>
    </Flex>
  );
};

export default Navbar;
