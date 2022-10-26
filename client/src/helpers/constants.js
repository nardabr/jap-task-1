import { TableCell, tableCellClasses } from "@mui/material";
import { styled } from "@mui/material/styles";

export const METHODS = {
  GET: "GET",
  POST: "POST",
  PATCH: "PATCH",
  DELETE: "DELETE",
};

export const PATHS = {
  LOGIN_USER: "/AuthControllers/login",
  GET_ALL_PROGRAMS: "/api/program/GetAll",
  GET_STUDENTS: "/api/student/GetAll",
  GET_STUDENT: "/api/student",
  DELETE_STUDENT: "/api/student",
  GET_SELECTIONS: "/api/selection/GetAll",
  GET_SELECTIONSSTATUS: "/api/selection/GetSelectionsStatuses",
  GET_STUDENT_STATUSES: "/api/student/GetStudentStatuses",
  EDIT_STUDENT: "/api/student",
  ADD_STUDENT: "/api/student",
  EDIT_SELECTION: "/api/selection",
  GET_SELECTION: "/api/selection",
  REMOVE_STUDENT: "/api/selection/removeStudent",
  ADD_COMMENT: "/api/comment",
  GET_SELECTIONSSUCCESSRATES: "/api/selection/GetSelectionsSuccessRates",
  GET_OVERALLSUCCESSRATE: "/api/selection/GetOverallSuccessRate",
  ADD_LECTURE_EVENT: "/api/lecture-event",
  GET_PROGRAM_DETAILS: "/api/program/GetProgramDetails",
  EDIT_ORDER_NUMBER: "/api/lecture-event",
  GET_LECTURE_EVENT_BY_ID: "/api/lecture-event",
  EDIT_LECTURE_EVENT: "/api/lecture-event",
  DELETE_LECTURE_EVENT: "/api/lecture-event",
  GET_STUDENT_LECTURE_EVENTS: "/api/student-lecture-events",
};

export const STUDENTSTABLEHEADER = [
  "First Name",
  "Last Name",
  "Student Status",
  "Program Info",
  "Selections",
];

export const LECTUREEVENTTABLEHEADER = [
  "Type",
  "Name",
  "Description",
  "Url",
  "Work Hours",
  "Order Number",
  "Start Date",
  "End Date",
];

export const STUDENTLECTUREEVENTTABLEHEADER = [
  "Type",
  "Name",
  "Description",
  "Url",
  "Work Hours",
  "Order Number",
  "Start Date",
  "End Date",
  "Done",
  "Status",
];

export const data = ["Lecture", "Event"];

export const StyledTableCell = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: "#7d8597",
    color: theme.palette.common.white,
  },
  [`&.${tableCellClasses.body}`]: {
    fontSize: 14,
    maxWidth: 0,
    overflow: "hidden",
    textOverflow: "ellipsis",
    whiteSpace: "nowrap",
    borderRight: "1px solid rgba(0,0,0,0.3)",
    "&:nth-of-type(n+6)": {
      borderRight: 0,
      borderLeft: 0,
    },
    "&:nth-of-type(4)": {
      cursor: "pointer",
    },
  },
}));

export const StyledTableCellProgram = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: "#7d8597",
    color: theme.palette.common.white,
  },
  [`&.${tableCellClasses.body}`]: {
    fontSize: 14,
    maxWidth: 0,
    overflow: "hidden",
    textOverflow: "ellipsis",
    whiteSpace: "nowrap",
    borderRight: "1px solid rgba(0,0,0,0.3)",
    "&:nth-of-type(n+10)": {
      borderRight: 0,
      borderLeft: 0,
    },
    "&:nth-of-type(10)": {
      cursor: "pointer",
    },
  },
}));

export const cellWidthProgram = {
  maxWidth: "15px",
  borderRight: "1px solid rgba(0,0,0,0.3)",
  "&:nth-of-type(n+10)": {
    borderRight: 0,
    borderLeft: 0,
  },
};

export const cellWidthDnD = {
  maxWidth: "10px",
  borderRight: "1px solid rgba(0,0,0,0.3)",
  // "&:nth-of-type(n+10)": {
  //   borderRight: 0,
  //   borderLeft: 0,
  // },
};

export const cellWidth = {
  maxWidth: "15px",
  borderRight: "1px solid rgba(0,0,0,0.3)",
  "&:nth-of-type(n+6)": {
    borderRight: 0,
    borderLeft: 0,
  },
};

export const styleTextField = {
  ".MuiInputBase-input.Mui-disabled": {
    WebkitTextFillColor: "#000",
    color: "rgba(0,0,0,0.8)",
  },
  "& .MuiFormLabel-root": {
    color: "rgba(0,0,0,0.8)",
  },
};
