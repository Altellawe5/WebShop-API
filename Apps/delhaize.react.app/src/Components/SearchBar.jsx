import React, { useState } from "react";
import Style from "./SearchBar.module.css";
import { useNavigate } from "react-router-dom";

const SearchBar = () => {
  const navigate = useNavigate();
  const [searchTerm, setSearchTerm] = useState("");

  const handleInputChange = (event) => {
    setSearchTerm(event.target.value);
  };

  const handleClick = () => {
    navigate(`search/${searchTerm}`);
    setSearchTerm("");
  };

  const handleKeyDown = (event) => {
    if (event.key === "Enter") {
      navigate(`search/${searchTerm}`);
      setSearchTerm("");
    }
  };

  return (
    <div className={Style.bar}>
      <input
        type="text"
        placeholder="Zoek producten"
        id="searchInput"
        name="searchInput"
        onChange={handleInputChange}
        onKeyDown={handleKeyDown}
        value={searchTerm}
      />
      <button className={Style.search} onClick={() => handleClick()}>
        <svg xmlns="http://www.w3.org/2000/svg">
          <path d="M11.91 13.92a.83.83 0 1 1 1.18-1.18l3.33 3.34a.83.83 0 1 1-1.18 1.18l-3.33-3.34Z"></path>
          <path d="M3.33 9.17a5.83 5.83 0 1 0 11.67 0 5.83 5.83 0 0 0-11.67 0Zm10 0a4.17 4.17 0 1 1-8.33 0 4.17 4.17 0 0 1 8.33 0Z"></path>
        </svg>
      </button>
    </div>
  );
};

export default SearchBar;
