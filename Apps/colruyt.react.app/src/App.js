import HomePage from "./Pages/HomePage"
import RegistratiePage from "./Pages/RegistratiePage"
import "./App.css";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import NotFoundPage from "./Pages/NotFoundPage";
import PaymentPage from "./Pages/PaymentPage";
import ShoppingcartPage from "./Pages/ShoppingcartPage";
import CategoriePage from "./Pages/CatagoriePage";
import SearchPage from "./Pages/SearchPage";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/Registratie" element={<RegistratiePage />} />
        <Route path="/*" element={<NotFoundPage />} />
        <Route path="/categorie/:id" element={<CategoriePage />} />
        <Route path="search/:term" element={<SearchPage />} />
        <Route path="/Payment" element={<PaymentPage />} />
        <Route path="/Cart" element={<ShoppingcartPage />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;