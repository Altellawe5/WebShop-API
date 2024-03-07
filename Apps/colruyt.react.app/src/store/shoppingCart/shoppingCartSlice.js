import { createSlice } from "@reduxjs/toolkit";

const initialState = { producten: [] };

export const shoppingCartSlice = createSlice({
    name: "shoppingCart",
    initialState,
    reducers: {
        addProduct: (state, action) => {
            const product = action.payload;

            const existingProduct = state.producten.find((p) => p.id === product.id);
            if (existingProduct) {
                existingProduct.qty += 1;
            } else {
                state.producten.push({ ...product, qty: 1 });
            }
        },
        removeProduct: (state, action) => {
            const indexToRemove = action.payload;
            state.producten = state.producten.filter((_, i) => i !== indexToRemove);
        },
        emptyCart: (state) => {
            state.producten = [];
        },
        increaseQty: (state, action) => {
            const index = action.payload;
            state.producten[index].qty += 1;
        },
        decreaseQty: (state, action) => {
            const index = action.payload;
            if (state.producten[index].qty !== 1) {
                state.producten[index].qty -= 1;
            } else {
                state.producten = state.producten.filter((_, i) => i !== index);
            }
        },
    },
});
export const {
    addProduct,
    removeProduct,
    emptyCart,
    increaseQty,
    decreaseQty,
} = shoppingCartSlice.actions;
export default shoppingCartSlice.reducer;
