import React from "react";
import Style from "./AddCartButton.module.css";
import { useDispatch } from "react-redux";
import { addProduct } from "../Store/shoppingCart/shoppingCartSlice";

export const AddCartButton = ({ product }) => {
  const dispatch = useDispatch();

  const productDataForShoppingCart = {
    id: product.id,
    name: product.name,
    brand: product.brand,
    priceType: product.priceType.type,
    price: product.price,
  };

  return (
    <button
      className={Style.add}
      onClick={() => dispatch(addProduct(productDataForShoppingCart))}
    >
      <svg xmlns="http://www.w3.org/2000/svg">
        <path d="M2.65 3.4a.98.98 0 1 0 0 1.96h.94l1.3 5.52.54 3.31v.01a1 1 0 0 0 1.17.81l9.2-1.67a1 1 0 0 0 .79-.71l1.43-5.01a1 1 0 0 0-.96-1.28H5.84l-.51-2.19a.98.98 0 0 0-.96-.76H2.65zM14.58 16a1.25 1.25 0 1 0 0 2.5 1.25 1.25 0 0 0 0-2.5zm-7.5 0a1.25 1.25 0 1 0 0 2.5 1.25 1.25 0 0 0 0-2.5z"></path>
      </svg>
      <p>Toevoegen</p>
    </button>
  );
};
