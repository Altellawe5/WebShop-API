import React, { useState } from 'react'
import "../index.css"
import VerticalNavBar from "../components/VerticalNavBar"
import Header from "../components/Header"
import Footer from "../components/Footer"
import LogInBody from '../components/LogInBody'
import RegistratieBody from '../components/RegistratieBody'
import RegistratieBody2 from '../components/RegistratieBody2'




const RegistratiePage = () => {
    const [showLogin, setShowLogin] = useState(true);
    const [showRegistratieBody2, setShowRegistratieBody2] = useState(false);


    const handleSignUpClick = () => {
        setShowLogin(false);
    };

    const handleBackToLoginClick = () => {
        setShowLogin(true);
        setShowRegistratieBody2(false);
    };
    const handleShowRegistratieBody2 = () => {
        setShowRegistratieBody2(true);
    };
    const handleBackToRegister = () => {
        setShowRegistratieBody2(false);

    }
    return (
        <>

            <div>
                <VerticalNavBar />
            </div>
            <div className="mainBody">
                <Header />
                {showLogin && !showRegistratieBody2 && (
                    <LogInBody onGoToRegister={handleSignUpClick} />
                )}
                {!showLogin && !showRegistratieBody2 && (
                    <RegistratieBody onGoToLogin={handleBackToLoginClick} onGoToFinishRegistratie={handleShowRegistratieBody2} />
                )}
                {!showLogin && showRegistratieBody2 && (
                    <RegistratieBody2 onGoBackToRegister={handleBackToRegister} />
                )}
                <Footer />
            </div>

        </>
    )
}

export default RegistratiePage