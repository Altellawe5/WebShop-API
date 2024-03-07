import React from "react";
import Style from "./NotFound.module.css";

const NotFound = () => {
  return (
    <div className={Style.mainContainer}>
      <p className={Style.boldError}>
        Het spijt ons. Er is een fout opgetreden. Controleer het formulier en
        probeer het opnieuw.
      </p>
      <p className={Style.smallError}>
        Er is een fout opgetreden. Probeer het opnieuw.
      </p>
    </div>
  );
};

export default NotFound;
