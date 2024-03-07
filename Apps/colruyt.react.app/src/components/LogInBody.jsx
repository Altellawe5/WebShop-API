import React, { useState } from 'react'
import Style from "./LogInBody.module.css";
import { useDispatch } from 'react-redux';
import { addUser } from '../store/User/userSlice';
import { useNavigate } from 'react-router-dom';

const LogInBody = ({ onGoToRegister }) => {
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')
    const handleGoToRegister = (event) => {
        event.preventDefault();
        onGoToRegister();
    };
    const navigate = useNavigate()
    const handleEmail = (event) => {
        setEmail(event.target.value)
    }
    const handlePassword = (event) => {
        setPassword(event.target.value)

    }
    const dispatch = useDispatch();
    const user = {
        email: email,
        password: password
    }
    return (
        <>
            <div className={Style.pageBody}>
                <div className={Style.loginContainer}>
                    <img className={Style.logo} src="../Images/xtra.svg" alt="" />
                    <h4 className={Style.txt}>Aanmelden</h4>
                    <form action="" className={Style.form}>
                        <div className={Style.inputContainer}>
                            <input onChange={handleEmail} className={Style.input} type="email" />
                            <label htmlFor="">E-mail of Xtra-kaartnummer</label>
                            <span className={Style.tooltip}></span>
                            <p className={Style.tooltipTxt}>Op je Xtra-kaart vind je een 12-cijferige code. Dit is je kaartnummer.</p>
                        </div>
                        <div className={Style.inputContainer}>
                            <input onChange={handlePassword} className={Style.input} type="password" required />
                            <label htmlFor="password">Passwoord (min.10 tekens)</label>
                        </div>
                        <button onClick={() => {
                            console.log(user)
                            dispatch(addUser(user))
                            navigate('/')
                        }} className={Style.button}>Volgende</button>
                    </form>
                    <div className={Style.containerFooter}>
                        <p>Nieuw bij Xtra? <a href="#" onClick={handleGoToRegister}>Maak je profiel aan</a></p>
                    </div>
                </div>
            </div >
        </>
    )
}

export default LogInBody