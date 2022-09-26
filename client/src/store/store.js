import { configureStore, createSlice } from "@reduxjs/toolkit";

const store = createSlice({
  name: "store",
  initialState: {
    user: undefined,
    allPrograms: [],
    students: [],
    student: {},
    selections: [],
    selectionsStatus: [],
    studentStatuses: [],
    selection: {},
    pages: 1,
  },
  reducers: {
    setUser(state, { payload }) {
      state.user = payload;
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
  },
});

export const storeConfiguration = configureStore({
  reducer: { store: store.reducer },
});

export const actions = store.actions;
