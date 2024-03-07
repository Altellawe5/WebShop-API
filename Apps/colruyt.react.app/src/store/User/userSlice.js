import { createSlice } from "@reduxjs/toolkit";

const initialState = { email: "", password: "" };

export const userSlice = createSlice({
    name: "user",
    initialState,
    reducers: {
        addUser: (state, action) => {
            const user = action.payload;
            state.email = user.email;
            state.password = user.password;
        },
        removeUser: (state, action) => {
            state.email = "";
            state.password = "";
        },
    }
})
export const {
    addUser,
    removeUser,
} = userSlice.actions;
export default userSlice.reducer;
