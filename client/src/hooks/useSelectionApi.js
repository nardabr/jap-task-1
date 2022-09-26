import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useDispatch } from "react-redux";
import { actions } from "../store/store";
import axios from "axios";

import { METHODS, PATHS } from "../helpers/constants";
import ApiError from "../components/UI/ApiError";

export function useSelectionApi() {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const [error, setError] = useState("");

  async function getSelections() {
    await axios({
      method: METHODS.GET,
      url: PATHS.GET_SELECTIONS,
    })
      .then((res) => {
        dispatch(actions.setSelections(res.data.data));
      })
      .catch((err) => setError(err.response.data.error));
  }

  async function getSelectionsStatus() {
    await axios({
      method: METHODS.GET,
      url: PATHS.GET_SELECTIONSSTATUS,
    })
      .then((res) => {
        dispatch(actions.setSelectionsStatus(res.data.data));
      })
      .catch((err) => setError(err.response.data.error));
  }

  async function getSelection(selectionId) {
    await axios({
      method: METHODS.GET,
      url: PATHS.GET_SELECTION + "/" + selectionId,
    })
      .then((res) => {
        dispatch(actions.setSelection(res.data.data));
      })
      .catch((err) => setError(err.response.data.error));
  }

  async function editSelection(selectionId, input) {
    await axios({
      method: METHODS.PATCH,
      url: PATHS.EDIT_SELECTION + "/" + selectionId,
      data: input,
    })
      .then(() => navigate("/selections/all"))
      .catch((err) => setError(err.response.data.error));
  }

  async function removeStudent(input) {
    await axios({
      method: METHODS.PATCH,
      url: PATHS.REMOVE_STUDENT,
      data: input,
    })
      .then(() => navigate("/selections/all"))
      .catch((err) => setError(err.response.data.error));
  }

  const apiError = error && <ApiError message={error} />;

  return {
    getSelections,
    getSelectionsStatus,
    getSelection,
    editSelection,
    removeStudent,
    apiError,
  };
}
