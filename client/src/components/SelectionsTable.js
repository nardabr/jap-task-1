import { Link } from "react-router-dom";
import { useSelector } from "react-redux";
import moment from "moment";

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
  List,
  Typography,
} from "@mui/material";
import { StyledTableCell, cellWidth } from "../helpers/constants";

export default function SelectionsTable() {
  const selections = useSelector((s) => s.store.selections);

  return (
    <>
      return (
      <TableContainer component={Paper} className="table-container">
        <Table sx={{ minWidth: 650 }}>
          <TableHead>
            <TableRow>
              <StyledTableCell align="center" sx={cellWidth}>
                Selections
              </StyledTableCell>
              <StyledTableCell align="center" sx={cellWidth}>
                Start Date
              </StyledTableCell>
              <StyledTableCell align="center" sx={cellWidth}>
                End Date
              </StyledTableCell>
              <StyledTableCell align="center" sx={cellWidth}>
                Selections Status
              </StyledTableCell>
              <StyledTableCell align="center" sx={cellWidth}>
                Students
              </StyledTableCell>
              <StyledTableCell align="center">Actions</StyledTableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {selections.map((selection, i) => (
              <TableRow
                key={i}
                sx={{
                  "&:last-child th": { border: 0 },
                }}
              >
                <StyledTableCell align="center">
                  {selection.name}
                </StyledTableCell>
                <StyledTableCell align="center">
                  {moment(selection.startAt).format("DD. MM. YYYY")}
                </StyledTableCell>
                <StyledTableCell align="center">
                  {moment(selection.endAt).format("DD. MM. YYYY")}
                </StyledTableCell>
                <StyledTableCell align="center">
                  {selection.status.name}
                </StyledTableCell>
                <StyledTableCell align="center">
                  {selection.students.length === 0 ? (
                    <Typography>No students</Typography>
                  ) : (
                    <List
                      sx={{
                        width: "100%",
                        position: "relative",
                        overflow: "auto",
                        maxHeight: 40,
                        "& ul": { padding: 0 },
                      }}
                    >
                      {selection.students &&
                        selection.students.map((student, i) => (
                          <div key={i}>
                            <Typography>
                              {student.firstName + " " + student.lastName}
                            </Typography>
                          </div>
                        ))}
                    </List>
                  )}
                </StyledTableCell>
                <StyledTableCell align="center">
                  <Link
                    to={"/selections/edit-selection/" + selection.id}
                    className="link"
                  >
                    <Button>Edit</Button>
                  </Link>
                  <Link to={"/add-student"} className="link">
                    <Button>Add</Button>
                  </Link>
                </StyledTableCell>
              </TableRow>
            ))}
          </TableBody>
          {/* <TableFooter>
          <TableRow></TableRow>
        </TableFooter> */}
        </Table>
      </TableContainer>
      );
    </>
  );
}
