import React from 'react'
import Header from "../components/Header"
import Footer from '../components/Footer'
import CartContainer from '../components/CartContainer'

const ShoppingcartPage = () => {
    return (
        <>
            <div>
                <Header />
                <CartContainer />
                <Footer />
            </div>
        </>
    )
}

export default ShoppingcartPage