import { Link } from "react-router-dom";
import { useSelector, useDispatch } from "react-redux";
import { DragDropContext, Draggable, Droppable } from "react-beautiful-dnd";
import moment from "moment";

import { actions } from "../store/store";
import { useLectureEventApi } from "../hooks/useLectureEventApi";

import {
  Table,
  TableBody,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  Button,
  TableFooter,
  Tooltip,
} from "@mui/material";
import ArrowDownwardIcon from "@mui/icons-material/ArrowDownward";
import ArrowUpwardIcon from "@mui/icons-material/ArrowUpward";
import {
  StyledTableCellProgram,
  cellWidthProgram,
  cellWidthDnD,
  LECTUREEVENTTABLEHEADER,
} from "../helpers/constants";

export default function LectureEventTable({
  programId,
  setDeleteModal,
  getProgramDetails,
}) {
  const dispatch = useDispatch();
  const programDetails = useSelector((s) => s.store.programDetails);
  const { editOrderNumber } = useLectureEventApi();

  function handleDragEnd(e) {
    if (!e.destination) return;
    if (
      e.destination.droppableId === e.source.droppableId &&
      e.destination.index === e.source.index
    ) {
      console.log("they're equal");
      return;
    }
    let tempUser = Array.from(programDetails);
    let [selectedRow] = tempUser.splice(e.source.index, 1);
    tempUser.splice(e.destination.index, 0, selectedRow);
    dispatch(actions.setProgramDetails(tempUser));
    editOrderNumber(tempUser, programId);
    getProgramDetails(programId);
  }

  return (
    <DragDropContext onDragEnd={handleDragEnd}>
      <TableContainer component={Paper} className="table-container">
        <Table sx={{ minWidth: 700 }}>
          <TableHead>
            <TableRow>
              <StyledTableCellProgram
                align="center"
                sx={cellWidthDnD}
              ></StyledTableCellProgram>
              {LECTUREEVENTTABLEHEADER.map((name, i) => (
                <StyledTableCellProgram
                  align="center"
                  sx={cellWidthProgram}
                  key={i}
                >
                  <Button
                    // startIcon={
                    //   !order[i].includes("desc") ? (
                    //     <ArrowDownwardIcon
                    //       color="action"
                    //       onClick={() => setOrderHandler(i, `${name} desc`)}
                    //     />
                    //   ) : (
                    //     <ArrowUpwardIcon
                    //       color="action"
                    //       onClick={() => setOrderHandler(i, name)}
                    //     />
                    //   )
                    // }
                    color="inherit"
                  >
                    {name}
                  </Button>
                </StyledTableCellProgram>
              ))}
              <StyledTableCellProgram align="center" sx={{ maxWidth: "40px" }}>
                Actions
              </StyledTableCellProgram>
            </TableRow>
          </TableHead>
          <Droppable droppableId="droppable-1">
            {(provided) => (
              <TableBody ref={provided.innerRef} {...provided.droppableProps}>
                {programDetails.map((program, index) => (
                  <Draggable
                    draggableId={program.id.toString()}
                    index={index}
                    key={program.id}
                  >
                    {(provided) => (
                      <TableRow
                        sx={{
                          "&:last-child th": { border: 0 },
                        }}
                        ref={provided.innerRef}
                        {...provided.draggableProps}
                      >
                        <StyledTableCellProgram
                          align="center"
                          {...provided.dragHandleProps}
                        >
                          =
                        </StyledTableCellProgram>
                        <StyledTableCellProgram align="center">
                          {program.type}
                        </StyledTableCellProgram>
                        <StyledTableCellProgram align="center">
                          {program.name}
                        </StyledTableCellProgram>
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
                          <Link
                            to={"/lecture-event/edit/" + program.id}
                            className="link"
                          >
                            <Button>Edit</Button>
                          </Link>
                          <Link className="link">
                            <Button onClick={() => setDeleteModal(program.id)}>
                              Delete
                            </Button>
                          </Link>
                        </StyledTableCellProgram>
                      </TableRow>
                    )}
                  </Draggable>
                ))}
                {provided.placeholder}
              </TableBody>
            )}
          </Droppable>
        </Table>
        {/* <TableFooter sx={style.tableFooter}>
          <TableRow>
            <Button
              //   disabled={page === 1}
              variant="contained"
              //   onClick={() => setPage((page) => page - 1)}
            >
              Back
            </Button>
            &nbsp;
            <Button
              //   disabled={page === pages}
              variant="contained"
              //   onClick={() => setPage((page) => page + 1)}
            >
              Next
            </Button>
          </TableRow>
        </TableFooter> */}
      </TableContainer>
    </DragDropContext>
  );
}

const style = {
  tableFooter: {
    float: "right",
    padding: 1,
  },
};
