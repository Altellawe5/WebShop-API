import Style from "./ShoppingCard.module.css";
import { useSelector, useDispatch } from "react-redux";
import {
  emptyCart,
  removeProduct,
  increaseQty,
  decreaseQty,
} from "../Store/shoppingCart/shoppingCartSlice";

const ShoppingCard = () => {
  const shoppingCart = useSelector((state) => state.shoppingCart.producten);
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

  return (
    <div className={Style.mainContainer}>
      <div className={Style.sorteerBar}>
        <p className={Style.titel}>Mandje</p>
        <button
          className={Style.WinkelmandjeLeegMaken}
          onClick={() => dispatch(emptyCart())}
        >
          <svg
            xmlns="http://www.w3.org/2000/svg"
            viewBox="0 0 20 20"
            width="20px"
            height="20px"
          >
            <path d="M5 6.67v10.16a1.5 1.5 0 0 0 1.5 1.5h7a1.5 1.5 0 0 0 1.5-1.5V6.67H5zm6.67-2.92V3.5a1 1 0 0 0-1-1H9.33a1 1 0 0 0-1 1v.25H4.67a.5.5 0 0 0-.5.5v.25a.5.5 0 0 0 .5.5h10.66a.5.5 0 0 0 .5-.5v-.25a.5.5 0 0 0-.5-.5h-3.66z"></path>
          </svg>
          <p>Winkelmandje leegmaken</p>
        </button>
      </div>
      <div className={Style.childContainer}>
        <div className={Style.productContainer}>
          <p
            className={Style.aantalProducten}
          >{`${totalProducts} Producten`}</p>
          <div className={Style.productenLijst}>
            {shoppingCart.map((p, i) => (
              <div key={i} className={Style.product}>
                <div className={Style.productLeft}>
                  <div className={Style.imgContainer}>
                    <img src={`/../Images/producten/${p.id}.jpg`} alt="" />
                  </div>
                  <div className={Style.detail}>
                    <p className={Style.merk}>{p.brand}</p>
                    <p className={Style.naam}>{p.name}</p>
                    <p
                      className={Style.prijsType}
                    >{`€${p.price} ${p.priceType}`}</p>
                  </div>
                </div>
                <div className={Style.productCenter}>
                  <button
                    className={`${Style.productButton} ${Style.verwijderProduct}`}
                    onClick={() => {
                      dispatch(removeProduct(i));
                    }}
                  >
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      viewBox="0 0 20 20"
                      width="20px"
                      height="20px"
                    >
                      <path d="M5 6.67v10.16a1.5 1.5 0 0 0 1.5 1.5h7a1.5 1.5 0 0 0 1.5-1.5V6.67H5zm6.67-2.92V3.5a1 1 0 0 0-1-1H9.33a1 1 0 0 0-1 1v.25H4.67a.5.5 0 0 0-.5.5v.25a.5.5 0 0 0 .5.5h10.66a.5.5 0 0 0 .5-.5v-.25a.5.5 0 0 0-.5-.5h-3.66z"></path>
                    </svg>
                  </button>
                  <button
                    className={`${Style.productButton} ${Style.hoeveelButton}`}
                    onClick={() => dispatch(decreaseQty(i))}
                  >
                    -
                  </button>
                  <p
                    className={`${Style.productButton} ${Style.productAantal}`}
                  >
                    {p.qty}
                  </p>
                  <button
                    className={`${Style.productButton} ${Style.hoeveelButton}`}
                    onClick={() => dispatch(increaseQty(i))}
                  >
                    +
                  </button>
                </div>
                <div className={Style.productRight}>
                  <p className={Style.totaalBedrag}>{`€ ${(
                    p.qty * p.price
                  ).toFixed(2)}`}</p>
                </div>
              </div>
            ))}
          </div>
        </div>
        <div className={Style.betaalContainer}>
          <div className={Style.bedragContainer}>
            <p className={Style.bedragTekst}>Totaal</p>
            <p className={Style.bedrag}>{`€ ${totalPrice.toFixed(2)}`}</p>
          </div>

          <div className={Style.betaalMethoden}>
            <button className={Style.betaalButton}>Betaal</button>
            <p className={Style.betaalMethodenTekst}>
              Aanvaarde betalingsmethodes
            </p>
            <div className={Style.methoden}>
              <img
                src="/../Images/visa.svg"
                alt="Visa"
                className={Style.creditCard}
              />
              <img
                src="/../Images/mastercard.svg"
                alt="Mastercard"
                className={Style.creditCard}
              />
              <img
                src="/../Images/maestro.svg"
                alt="Maestro"
                className={Style.creditCard}
              />
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ShoppingCard;
