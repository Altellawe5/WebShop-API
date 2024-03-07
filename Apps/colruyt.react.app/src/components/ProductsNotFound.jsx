import React from 'react';
import Style from './ProductsNotFound.module.css';

const ProductsNotFound = () => {
    return (
        <div className={Style.productsNotFound}>
            <h2>No products found</h2>
            <p>Sorry, there are no products available for this category.</p>
        </div>
    );
};

export default ProductsNotFound;
