import React from "react";
import "../index.css";
import VerticalNavBar from "../components/VerticalNavBar";
import Header from "../components/Header";
import Body from "../components/body";
import Footer from "../components/Footer";
import { useParams } from "react-router-dom";

const HomePage = () => {
  const { categorie } = useParams();
  return (
    <>
      <VerticalNavBar categorie={categorie} />
      <div className="mainBody">
        <Header />
        <Body />
        <Footer />
      </div>
    </>
  );
};

export default HomePage;
