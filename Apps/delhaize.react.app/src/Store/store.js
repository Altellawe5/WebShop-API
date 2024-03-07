import { configureStore } from "@reduxjs/toolkit";
import counterReducer from "../Store/shoppingCart/shoppingCartSlice";

export const store = configureStore({
  reducer: {
    shoppingCart: counterReducer,
  },
});
