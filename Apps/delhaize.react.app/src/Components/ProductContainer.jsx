import ProductCard from "./ProductCard";
import Style from "./ProductContainer.module.css";
import NotFound from "./NotFound";

const ProductContainer = ({ categorie, producten }) => {
  const checkIfEmpty = () => {
    if (producten.length !== 0) {
      return (
        <>
          <div className={Style.sorteerBar}>
            <p className={Style.titel}>{categorie}</p>
          </div>
          <div className={Style.productContainer}>
            {producten.map((p) => (
              <ProductCard key={p.id} product={p} />
            ))}
          </div>
        </>
      );
    } else {
      return (
        <>
          <NotFound />
        </>
      );
    }
  };

  return (
    <>
      <div className={Style.mainContainer}>{checkIfEmpty()}</div>
    </>
  );
};

export default ProductContainer;
