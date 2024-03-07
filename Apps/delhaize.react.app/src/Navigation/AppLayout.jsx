import React from "react";
import Header from "../Components/Header";
import Nav from "../Components/Nav";
import { Outlet } from "react-router-dom";
import Footer from "../Components/Footer";
import Style from "./AppLayout.module.css";

const AppLayout = () => {
  return (
    <>
      <div className={Style.header}>
        <Header />
        <Nav />
      </div>
      <div className={Style.main}>
        <Outlet />
      </div>
      <Footer />
    </>
  );
};

export default AppLayout;
