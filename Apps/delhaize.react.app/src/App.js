import "./App.css";
import React from "react";
import HomePage from "./Pages/HomePage";
import { RouterProvider, createBrowserRouter } from "react-router-dom";
import CategoriePage from "./Pages/CategoriePage";
import SearchPage from "./Pages/SearchPage";
import RegistratiePage from "./Pages/RegistratiePage";
import NotFoundPage from "./Pages/NotFoundPage";
import AppLayout from "./Navigation/AppLayout";
import ShoppingCardPage from "./Pages/ShoppingCardPage";

function App() {
  const browserRouter = createBrowserRouter([
    {
      element: <AppLayout />,
      children: [
        {
          path: "/",
          element: <HomePage />,
        },
        {
          path: "categorie/:id",
          element: <CategoriePage />,
        },
        {
          path: "search/:term",
          element: <SearchPage />,
        },
        {
          path: "winkelmandje",
          element: <ShoppingCardPage />,
        },
        {
          path: "*",
          element: <NotFoundPage />,
        },
      ],
    },
    {
      children: [
        {
          path: "registratie",
          element: <RegistratiePage />,
        },
      ],
    },
  ]);
  return <RouterProvider router={browserRouter} />;
}

export default App;
