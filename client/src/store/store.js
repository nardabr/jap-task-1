import { configureStore, createSlice } from "@reduxjs/toolkit";

const store = createSlice({
  name: "store",
  initialState: {
    user: undefined,
  },
  reducers: {
    setUser(state, { payload }) {
      state.user = payload.user;
    },
  },
});

export const storeConfiguration = configureStore({
  reducer: { store: store.reducer },
});

export const actions = store.actions;
