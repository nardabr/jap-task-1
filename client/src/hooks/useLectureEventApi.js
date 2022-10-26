import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useDispatch } from "react-redux";
import { actions } from "../store/store";
import axios from "axios";

import { METHODS, PATHS } from "../helpers/constants";
import ApiError from "../components/UI/ApiError";
import { useProgramApi } from "./useProgramApi";

export function useLectureEventApi() {
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const { getProgramDetails } = useProgramApi();

  const [error, setError] = useState("");

  async function addNewLectureEvent(input) {
    await axios({
      method: METHODS.POST,
      url: PATHS.ADD_LECTURE_EVENT,
      data: input,
    })
      .then(() => navigate("/programs/all-programs"))
      .catch((err) => setError(err.response.data.error));
  }

  async function editOrderNumber(array, programId) {
    array
      .map(async (le, i) => {
        await axios({
          method: METHODS.PATCH,
          url: PATHS.EDIT_ORDER_NUMBER,
          data: { lectureEventId: le.id, orderNumber: i + 1 },
        }).catch((err) => setError(err.response.data.error));
      })
      .then(() => getProgramDetails(programId));
  }

  async function getLectureEventById(programId) {
    await axios({
      method: METHODS.GET,
      url: PATHS.GET_LECTURE_EVENT_BY_ID + "/" + programId,
    })
      .then((res) => {
        dispatch(actions.setLectureEventById(res.data.data));
      })
      .catch((err) => setError(err.response.data.error));
  }

  async function editLectureEvent(programId, input) {
    await axios({
      method: METHODS.PATCH,
      url: PATHS.EDIT_LECTURE_EVENT + "/" + programId,
      data: input,
    })
      .then(() => navigate(`/programs/details/${input.programId}`))
      .catch((err) => setError(err.response.data.error));
  }

  async function deleteLectureEvent(programId) {
    await axios({
      method: METHODS.DELETE,
      url: PATHS.DELETE_LECTURE_EVENT + "/" + programId,
    }).then((res) => dispatch(actions.setProgramDetails(res.data.data)));
  }

  const apiError = error && <ApiError message={error} />;

  return {
    addNewLectureEvent,
    editOrderNumber,
    getLectureEventById,
    editLectureEvent,
    deleteLectureEvent,
    apiError,
  };
}
