import { createBrowserRouter } from "react-router-dom";
import { PetList } from "../pages/Home/PetList";
import { NewPetForm } from "../pages/Pet/NewPetForm";
import { PetExpedient } from "../pages/Pet/PetExpedient";

export const appRouter = createBrowserRouter([
  {
    path: "/",
    element: <PetList />,
  },
  {
    path: "/petform",
    element: <NewPetForm />,
  },
  {
    path: "/petform/",
    element: <NewPetForm />,
  },
  {
    path: "/petform/:petId",
    element: <NewPetForm />,
  },
  { path: "/pet/:petId", element: <PetExpedient /> },
]);
