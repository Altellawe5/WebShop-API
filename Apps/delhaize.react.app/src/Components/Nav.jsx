import React, { useEffect, useRef, useState } from "react";
import NavItem from "./NavItem";
import Style from "./Nav.module.css";
import Axios from "axios";

const Nav = () => {
  const [categorieen, setCategorieen] = useState([]);

  useEffect(() => {
    const fetchCategorieen = async () => {
      try {
        const response = await Axios.get("http://localhost:5298/api/Category");
        setCategorieen(response.data);
      } catch (error) {
        console.log(error);
      }
    };

    fetchCategorieen();
  }, []);

  const scroll = useRef(null);

  const slide = (shift) => {
    scroll.current.scrollLeft += shift;
  };

  return (
    <nav className={Style.navigatie}>
      <button
        className={Style.navButton}
        onClick={() => {
          slide(-80);
        }}
      >
        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24">
          <path
            d="M14.383 7.076a1 1 0 0 0-1.09.217l-4 4a1 1 0 0 0 0 1.414l4 4A1 1 0 0 0 15 16V8a1 1 0 0 0-.617-.924z"
            data-name="Left"
          />
        </svg>
      </button>
      <div className={Style.navBar}>
        <div className={Style.left}></div>
        <div className={Style.scrollable} ref={scroll}>
          {categorieen.map((c) => (
            <NavItem key={c.id} id={c.id} categorie={c.name} />
          ))}
        </div>
        <div className={Style.right}></div>
      </div>
      <button
        className={Style.navButton}
        onClick={() => {
          slide(80);
        }}
      >
        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24">
          <path
            d="m14.707 11.293-4-4A1 1 0 0 0 9 8v8a1 1 0 0 0 1.707.707l4-4a1 1 0 0 0 0-1.414z"
            data-name="Right"
          />
        </svg>
      </button>
    </nav>
  );
};

export default Nav;
