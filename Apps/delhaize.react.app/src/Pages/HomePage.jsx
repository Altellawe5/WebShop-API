import React, { useEffect, useState } from "react";
import Axios from "axios";
import ProductContainer from "../Components/ProductContainer";

const HomePage = () => {
  const [producten, setProducten] = useState([]);
  useEffect(() => {
    const fetchProducten = async () => {
      try {
        const response = await Axios.get("http://localhost:5298/api/Products");
        setProducten(response.data);
      } catch (error) {
        console.log(error);
      }
    };

    fetchProducten();
  }, []);

  return <ProductContainer producten={producten} categorie={"Producten"} />;
};

export default HomePage;
