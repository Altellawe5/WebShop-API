import React, { useEffect, useState } from "react";
import ProductContainer from "../Components/ProductContainer";
import { useParams } from "react-router-dom";
import Axios from "axios";

const CategoriePage = () => {
  const { id } = useParams();
  const [producten, setProducten] = useState([]);
  const [categorie, setCategorie] = useState([]);

  useEffect(() => {
    const fetchProducten = async () => {
      try {
        const response = await Axios.get(
          `http://localhost:5298/api/Category/${id}/Products`
        );
        setProducten(response.data);
      } catch (error) {
        console.log(error);
      }
    };
    fetchProducten();

    const fetchCategorie = async () => {
      try {
        const response = await Axios.get(
          `http://localhost:5298/api/Category/${id}`
        );
        setCategorie(response.data);
      } catch (error) {
        console.log(error);
      }
    };
    fetchCategorie();
  }, [id]);

  return <ProductContainer categorie={categorie.name} producten={producten} />;
};

export default CategoriePage;
