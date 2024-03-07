import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import Axios from "axios";
import ProductContainer from "../Components/ProductContainer";

const SearchPage = () => {
  const { term } = useParams();
  const [producten, setProducten] = useState([]);
  useEffect(() => {
    const fetchProducten = async () => {
      try {
        const response = await Axios.get(
          `http://localhost:5298/api/Products/${term}`
        );
        setProducten(response.data);
      } catch (error) {
        console.log(error);
      }
    };

    fetchProducten();
  }, [term]);
  return (
    <ProductContainer
      categorie={`Resultaat voor: ${term}`}
      producten={producten}
    />
  );
};

export default SearchPage;
