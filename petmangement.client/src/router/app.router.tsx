import { createBrowserRouter } from "react-router-dom";
import { HomePage } from "../pages/HomePage";
import { PetForm } from "../components/Pet/PetForm";

export const appRouter = createBrowserRouter([
  {
    path: "/",
    element: <HomePage />,
  },
  {
    path: "/petform",
    element: <PetForm />,
  },
]);
