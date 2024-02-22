import axios from "axios";
import { getSession, useSession } from "next-auth/react";

const backendClient = axios.create({
    baseURL: "http://localhost:5215/",
    
});


backendClient.interceptors.request.use(async (config) => {
    const session = await getSession();
    console.log(session);
    console.log("test")
    config.headers["Authorization"] = "UR MOMMA";
    return config;
})

export { backendClient };