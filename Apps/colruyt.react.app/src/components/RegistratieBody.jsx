import React from 'react'
import Style from "./RegistratieBody.module.css";
const RegistratieBody = ({ onGoToFinishRegistratie, onGoToLogin }) => {
    const handleGoToLogin = () => {
        onGoToLogin();
    }
    const handleShowRegistratieBody2 = () => {
        onGoToFinishRegistratie();
    }



    return (
        <>
            <div className={Style.pageBody}>
                <div className={Style.loginContainer}>
                    <img className={Style.logo} src="../Images/xtra.svg" alt="" />
                    <div className={Style.text}>
                        <h4 className={Style.txt}>Maak je XTRA-profiel aan</h4>
                        <span className={Style.txt2}>Vul je e-mailadres in en kies een paswoord. Hiermee <br /> kan je aanmelden op al onze webshops.</span>
                    </div>
                    <form action="" className={Style.form}>
                        <div className={Style.inputContainer}>
                            <input className={Style.input} type="text" required />
                            <label htmlFor="">E-mail</label>
                        </div>
                        <div className={Style.inputContainer}>
                            <input className={Style.input} type="password" required />
                            <label htmlFor="password">Passwoord (min.10 tekens)</label>
                        </div>
                        <button onClick={handleShowRegistratieBody2} className={Style.button}>Maak profiel aan</button>
                    </form>
                    <div className={Style.containerFooter}>
                        <p>Al een account? <a href="#" onClick={handleGoToLogin}>Naar aanmelden</a></p>
                    </div>
                </div>
            </div>

        </>
    )
}


export default RegistratieBody