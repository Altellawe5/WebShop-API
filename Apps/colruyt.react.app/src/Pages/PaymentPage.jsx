import React from 'react'
import VerticalNavBar from "../components/VerticalNavBar";
import Header from "../components/Header"
import Footer from "../components/Footer"
import Style from "./PaymentPage.module.css"


const PaymentPage = () => {
    return (
        <>
            <VerticalNavBar />
            <div className="mainBody">
                <Header />
                <div className={Style.body}>
                    <div className={Style.container}>
                        <div className={Style.productCard}>
                            <div>
                                <div className={Style.imgContainer}>
                                    <img
                                        className={Style.productImg}
                                        src={`../images/producten/1.jpg`}
                                        alt="suii"
                                    />

                                </div>
                                <div className={Style.textContainer}>
                                    <p className={Style.merk}>"suii"</p>
                                    <p className={Style.naam}>"suii"</p>
                                </div>
                            </div>

                            <div className={Style.prijsContainer}>
                                <div className={Style.prijs}>
                                    <p className={Style.bedrag}>30</p>
                                    <p className={Style.type}>euro</p>
                                </div>
                            </div>
                            <button className={Style.paymentButton}>Pay</button>
                        </div>
                    </div>
                </div>

                <Footer />
            </div>

        </>
    )
}

export default PaymentPage