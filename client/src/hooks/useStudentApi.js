import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useDispatch } from "react-redux";
import { actions } from "../store/store";
import axios from "axios";

import { METHODS, PATHS } from "../helpers/constants";
import ApiError from "../components/UI/ApiError";

export function useStudentApi() {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const [error, setError] = useState("");

  async function getStudents(page, size, field, searchTerm, order) {
    function query() {
      if (field && !order)
        return `?page=${page}&size=${size}&field=${field}&searchTerm=${searchTerm}`;
      if (!field && order) return `?page=${page}&size=${size}&orderBy=${order}`;
      if (field && order)
        return `?page=${page}&size=${size}&field=${field}&searchTerm=${searchTerm}&orderBy=${order}`;
      if (!field && !order) return `?page=${page}&size=${size}`;
      return "";
    }
    await axios({
      method: METHODS.GET,
      url: PATHS.GET_STUDENTS + query(),
    })
      .then((res) => {
        dispatch(actions.setPages(parseInt(res.data.message)));
        dispatch(actions.setStudents(res.data.data));
      })
      .catch((err) => setError(err.response.data.error));
  }

  async function getStudent(studentId) {
    await axios({
      method: METHODS.GET,
      url: PATHS.GET_STUDENT + "/" + studentId,
    })
      .then((res) => {
        dispatch(actions.setStudent(res.data.data));
      })
      .catch((err) => setError(err.response.data.error));
  }

  async function getStudentStatuses() {
    await axios({
      method: METHODS.GET,
      url: PATHS.GET_STUDENT_STATUSES,
    })
      .then((res) => {
        dispatch(actions.setStudentStatuses(res.data.data));
      })
      .catch((err) => setError(err.response.data.error));
  }

  async function deleteStudent(studentId) {
    await axios({
      method: METHODS.DELETE,
      url: PATHS.DELETE_STUDENT + "/" + studentId,
    }).then((res) => dispatch(actions.setStudents(res.data.data)));
  }

  async function editStudent(studentId, input) {
    await axios({
      method: METHODS.PATCH,
      url: PATHS.EDIT_STUDENT + "/" + studentId,
      data: input,
    })
      .then(() => navigate("/homepage"))
      .catch((err) => setError(err.response.data.error));
  }

  async function addNewStudent(input) {
    await axios({
      method: METHODS.POST,
      url: PATHS.ADD_STUDENT,
      data: input,
    })
      .then(() => navigate("/homepage"))
      .catch((err) => setError(err.response.data.error));
  }

  const apiError = error && <ApiError message={error} />;

  return {
    getStudents,
    getStudent,
    deleteStudent,
    getStudentStatuses,
    editStudent,
    addNewStudent,
    apiError,
  };
}
