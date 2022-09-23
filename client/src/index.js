import { BrowserRouter } from "react-router-dom";
import { Provider } from "react-redux";
import React from "react";
import ReactDOM from "react-dom/client";
import axios from "axios";

import App from "./App";
import { storeConfiguration } from "./store/store";

import "./index.css";

axios.defaults.baseURL = "https://localhost:7067";
// axios.defaults.withCredentials = true;

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <BrowserRouter>
    <Provider store={storeConfiguration}>
      <App />
    </Provider>
  </BrowserRouter>
);
