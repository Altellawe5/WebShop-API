import ProductCard from "./ProductCard";
import Style from "./ProductContainer.module.css";
import ProductsNotFound from "./ProductsNotFound";

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
          <ProductsNotFound />
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
