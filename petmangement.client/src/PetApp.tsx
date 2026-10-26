import { RouterProvider } from "react-router-dom";
import { appRouter } from "./router/app.router";

export const PetApp = () => {
  return <RouterProvider router={appRouter} />;
};
