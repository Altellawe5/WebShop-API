import React, { useEffect, useState } from "react";
import Style from "./VerticalNavBar.module.css";
//import Categorieen from "../Utils/Categorieen.json";
import Axios from "axios";
import NavItem from "./NavItem";

const VerticalNavBar = ({ categorie }) => {
  const [categorieen, setCategorieen] = useState([]);

  useEffect(() => {
    const fetchCategorieen = async () => {
      try {
        const response = await Axios.get('https://localhost:7127/api/Category')
        setCategorieen(response.data)
      } catch (error) {
        console.log(error)
      }
    }
    fetchCategorieen()

  }, [])

  return (
    <div className={Style.navContainer}>
      <div className={Style.navBarLogo}>
        <svg
          version="1.1"
          viewBox="0 0 47 31"
          xmlns="http://www.w3.org/2000/svg"
        >
          <polygon
            points="14.654 0 47 0 32.346 31 9.1932e-14 31"
            fill="#F5822A"
          ></polygon>
        </svg>
      </div>
      <div className={Style.scrollable}>
        {categorieen.map(c => (
          <NavItem key={c.id} id={c.id} categorie={c.name} />
        ))}
      </div>
    </div>
  );
};

export default VerticalNavBar;
