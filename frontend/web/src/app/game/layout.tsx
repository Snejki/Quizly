"use client";
import React from 'react';
import * as signalR from "@microsoft/signalr";

interface Props {
    children: React.ReactNode
}

const Layout = (props : Props) => {
    const { children } = props;

    const connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5215/game", {
            skipNegotiation: true,
            transport: signalR.HttpTransportType.WebSockets
        })
        .build();
    connection.start().catch((err) => console.log(err));

    console.log(connection);
    console.log("WTF");

    connection.on("notify", () => {
        console.log("triggered");
    })

    setTimeout(() => {
        connection.send("searchGame", { categoryId: "SAMOICVHODY", userId: "Tomek"});

    }, 2000)

  return (
    <>{children}asd</>
  )
}

export default Layout