import { createBrowserRouter } from "react-router-dom";
import { HomePage } from "../pages/Home/HomePage";
import { NewPetForm } from "../pages/Pet/NewPetForm";
import { PetExpedient } from "../pages/Pet/PetExpedient";

export const appRouter = createBrowserRouter([
  {
    path: "/",
    element: <HomePage />,
  },
  {
    path: "/petform",
    element: <NewPetForm />,
  },
  { path: "/pet/:petId", element: <PetExpedient /> },
]);
