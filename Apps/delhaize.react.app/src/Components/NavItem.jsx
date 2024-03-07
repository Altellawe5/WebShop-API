import React from "react";
import { useNavigate } from "react-router-dom";
import Style from "./Nav.module.css";

const NavItem = ({ categorie, id }) => {
  const navigate = useNavigate();

  const handleClick = () => {
    navigate(`/categorie/${id}`);
  };
  return (
    <button className={Style.categorieItem} onClick={() => handleClick()}>
      {categorie}
    </button>
  );
};

export default NavItem;
