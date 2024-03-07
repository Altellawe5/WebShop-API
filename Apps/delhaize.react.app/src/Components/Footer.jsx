import React from "react";
import Style from "./Footer.module.css";
import SocialMedia from "./SocialMedia";

const Footer = () => {
  return (
    <footer>
      <div className={Style.topRow}>
        <div className={Style.logoContainer}>
          <img
            src="/../Images/Logo_White.svg"
            alt="Delhaize Logo"
            className={Style.logo}
          />
        </div>
        <div className={Style.socialsContainer}>
          <SocialMedia />
        </div>
        <div className={Style.creditCardContainer}>
          <img
            src="/../Images/visa.svg"
            alt="Visa"
            className={Style.creditCard}
          />
          <img
            src="/../Images/mastercard.svg"
            alt="Mastercard"
            className={Style.creditCard}
          />
          <img
            src="/../Images/maestro.svg"
            alt="Maestro"
            className={Style.creditCard}
          />
        </div>
      </div>
      <div className={Style.bottomRow}>
        <p className={Style.copyright}>
          Copyright © 2022 All rights reserved. Delhaize Group.
        </p>
      </div>
    </footer>
  );
};

export default Footer;

/* <div className={FooterCSS.footerContainer}>

<div className="CreditCardsContainer">
  
</div>

</div> */
