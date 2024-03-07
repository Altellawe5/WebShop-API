import React from "react";
import { useNavigate } from "react-router-dom";
import Style from "./VerticalNavBar.module.css";


const NavItem = ({ categorie, id }) => {
    const navigate = useNavigate();

    const handleClick = () => {
        navigate(`/categorie/${id}`);
    };
    return (
        <button className={Style.navBarItem} onClick={() => handleClick()}>
            {categorie}
        </button>
    );
};

export default NavItem;