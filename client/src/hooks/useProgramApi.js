import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useDispatch } from "react-redux";
import { actions } from "../store/store";
import axios from "axios";

import { METHODS, PATHS } from "../helpers/constants";
import ApiError from "../components/UI/ApiError";

export function useProgramApi() {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const [error, setError] = useState("");

  async function getAllPrograms() {
    await axios({
      method: METHODS.GET,
      url: PATHS.GET_ALL_PROGRAMS,
    })
      .then((res) => {
        dispatch(actions.setAllPrograms(res.data.data));
      })
      .catch((err) => setError(err.response.data.error));
  }

  const apiError = error && <ApiError message={error} />;

  return {
    getAllPrograms,
    apiError,
  };
}
