import { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";

import { METHODS, PATHS } from "../helpers/constants";
import ApiError from "../components/UI/ApiError";

export function useCommentApi() {
  const navigate = useNavigate();

  const [error, setError] = useState("");

  async function createComment(input) {
    await axios({
      method: METHODS.POST,
      url: PATHS.ADD_COMMENT,
      data: input,
    })
      .then(() => navigate("/homepage"))
      .catch((err) => setError(err.response.data.error));
  }

  const apiError = error && <ApiError message={error} />;

  return {
    createComment,
    apiError,
  };
}
