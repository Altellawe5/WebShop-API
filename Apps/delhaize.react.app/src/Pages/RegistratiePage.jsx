import React from "react";
import { Link } from "react-router-dom";
import Style from "./RegistratiePage.module.css";

const RegistratiePage = () => {
  return (
    <>
      <div className={Style.body}>
        <header className={Style.header}>
          <Link to="/">
            <svg
              className={Style.logo}
              xmlns="http://www.w3.org/2000/svg"
              viewBox="0 0 24 24"
              width="100%"
              height="100%"
            >
              <path d="M8.5 4.23H5.7l-.1.48H3.54l.45 1.53 1.67-.26.53.47H2.36l-.3 1.14h.63l.28-.56h3.28L5.18 8.14l-1.1-.7-.43.46.77 1.13-1.67 6.17 1.13-.57.6 1.48-1.44 2.34-.62.28L2 20.11h3.2l-.27-1.02 2.04-2.81.88 2.25-.95.56-.27 1.02h3.57l.22-1.13-.96-1.53 1.18-1.74h2.93l3.46-1.73-2.6 4.67-1.02.3-.3 1.16h3.45l.14-1.22 1.87-2.7 1.3 1.5-.44 1-1.1.25-.43 1.17h3.34l.76-2.34-1.07-4.34V7.88l-1.1-.93h-6.54V5.4h6.54l1.09.88V4.23h-8.84l.01 3.95h7.55v1.57h-8.92V4.97l-1.02.56.72-2.04z"></path>
            </svg>
          </Link>
        </header>
        <div className={Style.container}>
          <div className={Style.imageContainer}>
            <img src="../Images/GirlHoldingLeeks.png" alt="" />
            <p className={Style.imageText}> Hallo Goebeziger!</p>
          </div>
          <div className={Style.formContainer}>
            <div className={Style.textContainer}>
              <p className={Style.greet}>Hallo!</p>
              <p className={Style.instruction}>
                Voer je login gegevens in om te kunnen aanmelden!
              </p>
            </div>
            <div className={Style.form}>
              <label htmlFor="email">E-mail</label>
              <input type="email" name="email" />
              <label htmlFor="wachtwoord">Wachtwoord</label>
              <input type="password" name="wachtwoord" />
              <div className={Style.buttonContainer}>
                <button className={Style.button}>Meld je aan</button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default RegistratiePage;
