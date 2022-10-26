import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useDispatch } from "react-redux";
import { actions } from "../store/store";
import axios from "axios";

import { METHODS, PATHS } from "../helpers/constants";
import ApiError from "../components/UI/ApiError";

export function useUserApi() {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const [error, setError] = useState("");

  async function loginUser(input) {
    await axios({
      method: METHODS.POST,
      url: PATHS.LOGIN_USER,
      data: input,
    })
      .then((res) => {
        dispatch(actions.setUser(res.data.role));
        dispatch(actions.setUserId(res.data.userId));
        navigate("/homepage");
      })
      .catch((err) => {
        setError(err.response.data.error);
      });
  }

  const apiError = error && <ApiError message={error} />;

  return {
    loginUser,
    apiError,
  };
}
