import React, { useState } from 'react';
//import ReactDOM from 'react-dom';
import { useSelector, useDispatch } from 'react-redux';
import {
    emptyCart,
    removeProduct,
    increaseQty,
    decreaseQty,
} from "../store/shoppingCart/shoppingCartSlice";
import './CartContainer.css'
import axios from 'axios';


const CartContainer = () => {

    const shoppingCart = useSelector((state) => state.shoppingCart.producten);
    const user = useSelector((state) => state.user)
    console.log(user)
    const dispatch = useDispatch();

    // Bereken het totale aantal producten
    const totalProducts = shoppingCart.reduce(
        (total, product) => total + product.qty,
        0
    );
    const totalPrice = shoppingCart.reduce(
        (total, product) => total + product.qty * product.price,
        0
    );
    const handlePay = () => {
        if (user.email !== "") {
            const form = {
                iban: "string",
                amount: 0,
                currency: "EUR",
                transactionId: "string",
                comment: "string"
            };
            axios.post('https://localhost:7127/api/payments', form)
                .then(response => {
                    // handle success
                    console.log(response);
                })
                .catch(error => {
                    // handle error
                    console.log(error);
                });
            console.log(form);
            dispatch(emptyCart());
            alert("betaling geslaagd!");
        } else {
            alert("meld u aan A.U.B!");
        }
    }
    return (
        <div className="row justify-content-center m-0 min-vh-100">
            <div className="col-md-8 mt-5 mb-5">
                <div className="card">
                    <div className="card-header p-3">
                        <div className="card-header-flex">
                            <h5 className="text-white m-0">Cart Calculation {totalProducts}</h5>
                            <button className="btn btn-danger mt-0 btn-sm" onClick={() => dispatch(emptyCart())}><i className="fa fa-trash-alt mr-2"></i><span>Empty Cart</span></button>
                        </div>
                    </div>
                    <div className="card-body p-0">
                        {
                            totalProducts === 0 ? <table className="table cart-table mb-0">
                                <tbody>
                                    <tr>
                                        <td colSpan="6">
                                            <div className="cart-empty">
                                                <i className="fa fa-shopping-cart"></i>
                                                <p>Your Cart Is empty</p>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table> :
                                <table className="table cart-table mb-0">
                                    <thead>
                                        <tr>
                                            <th>Action</th>
                                            <th>Product</th>
                                            <th>Name</th>
                                            <th>Price</th>
                                            <th>Qty</th>
                                            <th className="text-right"><span id="amount" className="amount">Total Amount</span></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {
                                            shoppingCart.map((p, index) => {
                                                return (
                                                    <tr key={index}>
                                                        <td><button className="prdct-delete" onClick={() => dispatch(removeProduct(index))}><i className="fa fa-trash-alt"></i></button></td>
                                                        <td><div className="product-img"><img src={`/../Images/producten/${p.id}.jpg`} alt="" /></div></td>
                                                        <td><div className="product-name"><p>{p.name}</p></div></td>
                                                        <td>${p.price}</td>
                                                        <td>
                                                            <div className="prdct-qty-container">
                                                                <button className="prdct-qty-btn" type="button" onClick={() => dispatch(decreaseQty(index))}>
                                                                    <i className="fa fa-minus"></i>
                                                                </button>
                                                                <input type="text" name="qty" className="qty-input-box" value={p.qty} disabled />
                                                                <button className="prdct-qty-btn" type="button" onClick={() => dispatch(increaseQty(index))}>
                                                                    <i className="fa fa-plus"></i>
                                                                </button>
                                                            </div>
                                                        </td>
                                                        <td className="text-right">${(p.qty * p.price).toFixed(2)}</td>
                                                    </tr>
                                                )
                                            })
                                        }
                                    </tbody>
                                    <tfoot className="footerTable">
                                        <tr>
                                            <th colSpan="2">Items in Cart<span className="ml-2 mr-2">:</span><span className="text-danger">{totalProducts}</span></th>
                                            <th colSpan="2" className="text-right">Total Price<span className="ml-2 mr-2">:</span><span className="text-danger">$ {totalPrice.toFixed(2)}</span></th>
                                            <th colSpan="2" className="payBtnRow"><button onClick={handlePay} className="payButton ml-2 mr-2">Pay</button></th>
                                        </tr>
                                    </tfoot>
                                </table>
                        }
                    </div>
                </div>
            </div>
        </div>

    );
}


export default CartContainer;