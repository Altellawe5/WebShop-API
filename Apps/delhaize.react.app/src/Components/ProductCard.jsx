import React from "react";
import { AddCartButton } from "./AddCartButton";
import Style from "./ProductCard.module.css";

const ProductCard = ({ product }) => {
  return (
    <div className={Style.productCard}>
      <div>
        <div className={Style.imgContainer}>
          <img
            className={Style.productImg}
            src={`/../Images/producten/${product.id}.jpg`}
            alt={product.name}
          />
          <img
            className={Style.nutriImg}
            src={`/../Images/nutriscore/${product.nutriScore}.svg`}
            alt={product.nutriScore}
          />
        </div>
        <div className={Style.textContainer}>
          <p className={Style.merk}>{product.brand}</p>
          <p className={Style.naam}>{product.name}</p>
        </div>
      </div>

      <div className={Style.prijsContainer}>
        <div className={Style.prijs}>
          <p className={Style.bedrag}>{`€${product.price}`}</p>
          <p className={Style.type}>{product.priceType.type}</p>
        </div>
        <AddCartButton product={product} />
      </div>
    </div>
  );
};

export default ProductCard;
