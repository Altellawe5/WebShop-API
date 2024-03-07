import React from 'react'
import Style from "./RegistratieBody2.module.css";
import { useFormik } from 'formik';
import * as Yup from "yup"

const landen = [
    {
        id: 1,
        name: "België",
        value: "België"
    },
    {
        id: 2,
        name: "Nederland",
        value: "Nederland"
    },
    {
        id: 3,
        name: "Frankrijk",
        value: "Frankrijk"
    },
    {
        id: 4,
        name: "Duitsland",
        value: "Duitsland"
    },
    {
        id: 5,
        name: "Luxemburg",
        value: "Luxemburg"
    }
]
const landCodes = [
    {
        id: 1,
        name: "België",
        value: "+32"
    },
    {
        id: 2,
        name: "Nederland",
        value: "+31"
    },
    {
        id: 3,
        name: "Frankrijk",
        value: "+33"
    },
    {
        id: 4,
        name: "Duitsland",
        value: "+49"
    },
    {
        id: 5,
        name: "Luxemburg",
        value: "+352"
    }

]

const validatieSchema = Yup.object().shape({
    naam: Yup.string().required("Naam is verplicht"),
    voornaam: Yup.string().required("Voornaam is verplicht"),
    geboortedatum: Yup.date().required("Geboortedatum is verplicht"),
    land: Yup.string().required("Land is verplicht"),
    postcode: Yup.number().required("Postcode is verplicht"),
    gemeente: Yup.string().required("Gemeente is verplicht"),
    straat: Yup.string().required("Straat is verplicht"),
    huisnummer: Yup.string().required("Huisnummer is verplicht"),
    bus: Yup.number().required("Bus is verplicht"),
    gsmnummer: Yup.number().required("Gsmnummer is verplicht"),
})
const RegistratieBody2 = ({ onGoBackToRegister }) => {
    const handleGoToRegister = (event) => {
        event.preventDefault();
        onGoBackToRegister();
    };
    const formik = useFormik({
        initialValues: {
            naam: "",
            voornaam: "",
            geboortedatum: "",
            land: landen[0].value,
            postcode: "",
            gemeente: "",
            straat: "",
            huisnummer: "",
            bus: "",
            gsmnummer: "",
        },
        onSubmit: values => {
            alert(JSON.stringify(values, null, 2));
        }


    })
    return (
        <>
            <div className={Style.pageBody}>
                <div className={Style.loginContainer}>
                    <img className={Style.logo} src="../Images/xtra.svg" alt="" />
                    <h2 className={Style.text}>Wie ben je? </h2>
                    <form action="" className={Style.form} onSubmit={formik.handleSubmit}>
                        <div className={Style.genderSelection}>
                            <input className={Style.genderInput} type="radio" name="gender-selection-group" id="male" checked />
                            <label for="male">Meneer</label>
                            <input className={Style.genderInput} type="radio" name="gender-selection-group" id="female" />
                            <label for="female">Mevrouw</label>
                        </div>
                        <div className={Style.inputContainer}>
                            <input id="naam" name="naam" value={formik.values.naam} onChange={formik.handleChange} className={Style.input} type="text" required />
                            <label htmlFor="name">Naam</label>
                            {
                                formik.touched.naam && formik.errors.naam ? <p style={{ color: "red" }}>{formik.errors.name}</p> : null
                            }
                        </div>
                        <div className={Style.inputContainer}>
                            <input id="voornaam" name="voornaam" value={formik.values.voornaam} onChange={formik.handleChange} className={Style.input} type="text" required />
                            <label htmlFor="voornaam">Voornaam</label>
                            {
                                formik.touched.voornaam && formik.errors.voornaam ? <p style={{ color: "red" }}>{formik.errors.name}</p> : null
                            }
                        </div>
                        <div className={Style.inputContainer}>
                            <input id="geboortedatum" name="geboortedatum" value={formik.values.geboortedatum} onChange={formik.handleChange} className={Style.input} type="date" required />
                            <label htmlFor="geboortedatum"></label>
                            {
                                formik.touched.geboortedatum && formik.errors.geboortedatum ? <p style={{ color: "red" }}>{formik.errors.name}</p> : null
                            }
                        </div>
                        <h2 className={Style.text2}>Hoe kunnen we je bereiken?</h2>
                        <select className={Style.select} id="land" name="land" value={formik.values.land} onChange={formik.handleChange}>
                            {landen.map((land) => (
                                <option key={land.id} value={land.value}>{land.name}</option>
                            ))}
                            {
                                formik.touched.land && formik.errors.land ? <p style={{ color: "red" }}>{formik.errors.land}</p> : null
                            }
                        </select>
                        <div className={Style.doubleInputs}>
                            <div className={`${Style.inputContainerDouble1}`}>
                                <input id="postcode" name="postcode" value={formik.values.postcode} onChange={formik.handleChange} className={Style.input} type="number" required />
                                <label htmlFor="postcode">Postcode</label>
                                {
                                    formik.touched.postcode && formik.errors.postcode ? <p style={{ color: "red" }}>{formik.errors.name}</p> : null
                                }
                            </div>
                            <div className={`${Style.inputContainerDouble2}`}>
                                <input id="gemeente" name="gemeente" value={formik.values.gemeente} onChange={formik.handleChange} className={Style.input} type="text" required />
                                <label htmlFor="gemeente">gemeente</label>
                                {
                                    formik.touched.gemeente && formik.errors.gemeente ? <p style={{ color: "red" }}>{formik.errors.name}</p> : null
                                }
                            </div>
                        </div>
                        <div className={Style.inputContainer}>
                            <input id="straat" name="straat" value={formik.values.straat} onChange={formik.handleChange} className={Style.input} type="text" required />
                            <label htmlFor="straat">Straat</label>
                            {
                                formik.touched.straat && formik.errors.straat ? <p style={{ color: "red" }}>{formik.errors.name}</p> : null
                            }
                        </div>
                        <div className={Style.doubleInputs}>
                            <div className={`${Style.inputContainerDouble1}`}>
                                <input id="huisnummer" name="huisnummer" value={formik.values.huisnummer} onChange={formik.handleChange} className={Style.input} type="number" required />
                                <label htmlFor="huisnummer">huisnummer</label>
                                {
                                    formik.touched.huisnummer && formik.errors.huisnummer ? <p style={{ color: "red" }}>{formik.errors.name}</p> : null
                                }
                            </div>
                            <div className={`${Style.inputContainerDouble2}`}>
                                <input id="bus" name="bus" value={formik.values.bus} onChange={formik.handleChange} className={Style.input} type="number" required />
                                <label htmlFor="bus">bus</label>
                                {
                                    formik.touched.bus && formik.errors.bus ? <p style={{ color: "red" }}>{formik.errors.name}</p> : null
                                }
                            </div>
                        </div>
                        <h5 className={Style.text3}>Je adres wordt alleen gebruikt om je <br /> communicaties  per post te kunnen sturen. </h5>
                        <div className={Style.doubleInputs}>
                            <select className={Style.select} id="landCode" name="landCode" value={formik.values.landCode} onChange={formik.handleChange}>
                                {landCodes.map((landCode) => (
                                    <option key={landCode.id} value={landCode.value}>{landCode.value}</option>
                                ))}
                                {
                                    formik.touched.land && formik.errors.land ? <p style={{ color: "red" }}>{formik.errors.land}</p> : null
                                }
                            </select>
                            <div className={`${Style.inputContainerDouble2}`}>
                                <input id="gsmnummer" name="gsmnummer" value={formik.values.gsmnummer} onChange={formik.handleChange} className={Style.input} type="number" required />
                                <label htmlFor="gsmnummer">gsmnummer</label>
                                {
                                    formik.touched.gsmnummer && formik.errors.gsmnummer ? <p style={{ color: "red" }}>{formik.errors.name}</p> : null
                                }
                            </div>
                        </div>
                        <h5 className={Style.text3}>Je telefoonnummer wordt alleen <br /> uitzonderlijk gebruikt, bijvoorbeeld <br /> bij updates rond je levering.</h5>
                        <div className={Style.inputContainer}>
                            <input id="terms" name="terms" onChange={formik.handleChange} className={Style.inputCheckBox} type="checkbox" required />
                            <label htmlFor="terms" className={Style.inputCheckBoxLabel}>Ik ga akkoord met de algemene voorwaarden xtra en de digitale voorwaarden van xtra</label>
                            {
                                formik.touched.terms && formik.errors.terms ? <p style={{ color: "red" }}>{formik.errors.name}</p> : null
                            }
                        </div>
                        <div className={Style.buttonsDiv}>
                            <button className={Style.buttonSubmit} type="submit" disabled={!formik.isValid}>verstuur</button>
                            <button className={Style.buttonReset} type="reset" onClick={formik.handleReset}>Reset</button>
                            <button className={Style.buttonBack} onClick={handleGoToRegister}>Terug</button>
                        </div>
                    </form>

                </div>
            </div>
        </>
    )
}

export default RegistratieBody2