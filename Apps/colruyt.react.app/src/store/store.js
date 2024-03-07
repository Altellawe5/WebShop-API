// import { configureStore } from "@reduxjs/toolkit"
import { configureStore } from "@reduxjs/toolkit";
import counterReducer from "./shoppingCart/shoppingCartSlice"
import userReducer from "./User/userSlice"

export const store = configureStore({
    reducer: {
        shoppingCart: counterReducer,
        user: userReducer,
    },
});
