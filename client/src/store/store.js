import { configureStore, createSlice } from "@reduxjs/toolkit";

const store = createSlice({
  name: "store",
  initialState: {
    user: undefined,
    userId: undefined,
    allPrograms: [],
    students: [],
    student: {},
    selections: [],
    selectionsStatus: [],
    studentStatuses: [],
    selection: {},
    pages: 1,
    selectionsSuccessRates: [],
    overallSuccessRate: {},
    programDetails: [],
    lectureEventById: {},
    studentLectureEvent: {},
  },
  reducers: {
    setUser(state, { payload }) {
      state.user = payload;
    },
    setUserId(state, { payload }) {
      state.userId = payload;
    },
    setAllPrograms(state, { payload }) {
      state.allPrograms = payload;
    },
    setStudents(state, { payload }) {
      state.students = payload;
    },
    setStudent(state, { payload }) {
      state.student = payload;
    },
    setSelections(state, { payload }) {
      state.selections = payload;
    },
    setSelectionsStatus(state, { payload }) {
      state.selectionsStatus = payload;
    },
    setStudentStatuses(state, { payload }) {
      state.studentStatuses = payload;
    },
    setSelection(state, { payload }) {
      state.selection = payload;
    },
    setPages(state, { payload }) {
      state.pages = payload;
    },
    setSelectionsSuccessRates(state, { payload }) {
      state.selectionsSuccessRates = payload;
    },
    setOverallSuccessRate(state, { payload }) {
      state.overallSuccessRate = payload;
    },
    setProgramDetails(state, { payload }) {
      state.programDetails = payload;
    },
    setLectureEventById(state, { payload }) {
      state.lectureEventById = payload;
    },
    setStudentLectureEvent(state, { payload }) {
      state.studentLectureEvent = payload;
    },
    logout(state) {
      state.user = undefined;
    },
  },
});

export const storeConfiguration = configureStore({
  reducer: { store: store.reducer },
});

export const actions = store.actions;
