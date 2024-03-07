import React, { useEffect, useState } from "react";
import ProductContainer from "../components/ProductContainer";
import { useParams } from "react-router-dom";
import Axios from "axios";
import Header from "../components/Header";
import VerticalNavBar from "../components/VerticalNavBar";
import Footer from "../components/Footer";
import Style from "./HomePage.module.css"

const CategoriePage = () => {
    const { id } = useParams();
    const [producten, setProducten] = useState([]);
    const [categorie, setCategorie] = useState([]);

    useEffect(() => {
        const fetchProducten = async () => {
            try {
                const response = await Axios.get(
                    `https://localhost:7127/api/Category/${id}/Products`
                );
                setProducten(response.data);
                console.log(producten)
                console.log(response.data)
            } catch (error) {
                console.log(error);
            }
        };
        fetchProducten();

        const fetchCategorie = async () => {
            try {
                const response = await Axios.get(
                    `https://localhost:7127/api/Category/${id}`
                );
                setCategorie(response.data);
            } catch (error) {
                console.log(error);
            }
        };
        fetchCategorie();
    }, [id]);

    return <>
        <VerticalNavBar />
        <div className={Style.mainBody}>
            <Header />
            <ProductContainer categorie={categorie.name} producten={producten} />;
            <Footer />
        </div>
    </>
};

export default CategoriePage;
