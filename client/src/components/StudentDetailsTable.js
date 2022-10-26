import { useSelector } from "react-redux";
import moment from "moment";
import { useState, useEffect } from "react";

import {
  Table,
  TableBody,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  Button,
  Tooltip,
} from "@mui/material";
import {
  StyledTableCellProgram,
  cellWidthProgram,
  STUDENTLECTUREEVENTTABLEHEADER,
} from "../helpers/constants";
import { useStudentApi } from "../hooks/useStudentApi";

export default function StudentDetailsTable({ programDetails }) {
  const [array, setArray] = useState([]);
  const userId = useSelector((s) => s.store.userId);
  const { getStudentLectureEvents } = useStudentApi();

  async function fetchData() {
    let temp = [...programDetails];
    for (let i = 0; i < programDetails.length; i++) {
      getStudentLectureEvents(userId, programDetails[i].id).then((res) => {
        temp[i] = { ...temp[i], done: res.done, status: res.status };
      });
    }

    setArray(temp);
  }

  useEffect(() => {
    fetchData();

    setTimeout(() => {
      setArray((array) => [...array]);
    }, 250);
  }, []); // eslint-disable-line

  return (
    <TableContainer component={Paper} className="table-container">
      <Table sx={{ minWidth: 700 }}>
        <TableHead>
          <TableRow>
            {STUDENTLECTUREEVENTTABLEHEADER.map((name, i) => (
              <StyledTableCellProgram
                align="center"
                sx={cellWidthProgram}
                key={i}
              >
                <Button color="inherit">{name}</Button>
              </StyledTableCellProgram>
            ))}
          </TableRow>
        </TableHead>
        <TableBody>
          {array.map((program, index) => (
            <TableRow
              sx={{
                "&:last-child th": { border: 0 },
              }}
              key={index}
            >
              <StyledTableCellProgram align="center">
                {program.type}
              </StyledTableCellProgram>
              <Tooltip title={program.name}>
                <StyledTableCellProgram align="center">
                  {program.name}
                </StyledTableCellProgram>
              </Tooltip>
              <Tooltip title={program.description}>
                <StyledTableCellProgram align="center">
                  {program.description}
                </StyledTableCellProgram>
              </Tooltip>
              <Tooltip title={program.url}>
                <StyledTableCellProgram align="center">
                  {program.url}
                </StyledTableCellProgram>
              </Tooltip>
              <StyledTableCellProgram align="center">
                {program.workHours}
              </StyledTableCellProgram>
              <StyledTableCellProgram align="center">
                {index + 1}
              </StyledTableCellProgram>
              <StyledTableCellProgram align="center">
                {moment(program.startDate).format("DD. MM. YYYY")}
              </StyledTableCellProgram>
              <StyledTableCellProgram align="center">
                {moment(program.endDate).format("DD. MM. YYYY")}
              </StyledTableCellProgram>
              <StyledTableCellProgram align="center">
                {program.done}
              </StyledTableCellProgram>
              <StyledTableCellProgram align="center">
                {program.status}
              </StyledTableCellProgram>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}
