import { Link } from "react-router-dom";
import { useSelector } from "react-redux";
import { useState } from "react";

import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  Button,
  TableFooter,
  TablePagination,
} from "@mui/material";
import ArrowDownwardIcon from "@mui/icons-material/ArrowDownward";
import ArrowUpwardIcon from "@mui/icons-material/ArrowUpward";
import {
  StyledTableCell,
  cellWidth,
  STUDENTSTABLEHEADER,
} from "../helpers/constants";
import SearchField from "./SearchField";

export default function StudentsTable({
  setOpen,
  setDeleteModal,
  search,
  setSearchHandler,
  order,
  setOrderHandler,
  setPage,
  page,
}) {
  const students = useSelector((s) => s.store.students);
  const pages = useSelector((s) => s.store.pages);

  return (
    <>
      <TableContainer component={Paper} className="table-container">
        <Table sx={{ minWidth: 700 }}>
          <TableHead>
            <TableRow>
              {STUDENTSTABLEHEADER.map((name, i) => (
                <StyledTableCell align="center" sx={cellWidth} key={i}>
                  <Button
                    startIcon={
                      !order[i].includes("desc") ? (
                        <ArrowDownwardIcon
                          color="action"
                          onClick={() => setOrderHandler(i, `${name} desc`)}
                        />
                      ) : (
                        <ArrowUpwardIcon
                          color="action"
                          onClick={() => setOrderHandler(i, name)}
                        />
                      )
                    }
                    color="inherit"
                  >
                    {name}
                  </Button>
                  <SearchField
                    name={name}
                    i={i}
                    setSearchHandler={setSearchHandler}
                    search={search}
                  />
                </StyledTableCell>
              ))}
              <StyledTableCell align="center" sx={{ maxWidth: "40px" }}>
                Actions
              </StyledTableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {students.map((student, i) => (
              <TableRow
                key={i}
                sx={{
                  "&:last-child th": { border: 0 },
                }}
              >
                <StyledTableCell align="center">
                  {student.firstName}
                </StyledTableCell>
                <StyledTableCell align="center">
                  {student.lastName}
                </StyledTableCell>
                <StyledTableCell align="center">
                  {student.status.name}
                </StyledTableCell>
                <StyledTableCell
                  align="center"
                  onClick={() => setOpen(student.selection.program)}
                >
                  {student.selection
                    ? student.selection.program.description
                    : "No program"}
                </StyledTableCell>
                <StyledTableCell align="center">
                  {student.selection ? student.selection.name : "No selection"}
                </StyledTableCell>
                <StyledTableCell align="right">
                  <Link to={"/edit-student/" + student.id} className="link">
                    <Button>Edit</Button>
                  </Link>
                  <Link className="link">
                    <Button onClick={() => setDeleteModal(student.id)}>
                      Delete
                    </Button>
                  </Link>
                  <Link to={"/details-student/" + student.id} className="link">
                    <Button>Details</Button>
                  </Link>
                  <Link to={"/add-comment/" + student.id} className="link">
                    <Button>Add</Button>
                  </Link>
                </StyledTableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
        <TableFooter sx={style.tableFooter}>
          <TableRow>
            <Button
              disabled={page === 1}
              variant="contained"
              onClick={() => setPage((page) => page - 1)}
            >
              Back
            </Button>
            &nbsp;
            <Button
              disabled={page === pages}
              variant="contained"
              onClick={() => setPage((page) => page + 1)}
            >
              Next
            </Button>
          </TableRow>
        </TableFooter>
      </TableContainer>
    </>
  );
}

const style = {
  tableFooter: {
    float: "right",
    padding: 1,
  },
};
