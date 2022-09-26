import { useSelector } from "react-redux";
import { useEffect } from "react";
import { useParams } from "react-router-dom";
import moment from "moment";

import { useFormFields } from "../../hooks/useFormFields";
import { useSelectionApi } from "../../hooks/useSelectionApi";
import CardWrapper from "../../components/UI/CardWrapper";
import InputField from "../../components/UI/InputField";

import { Button, List, Typography } from "@mui/material";

export default function EditSelection() {
  const { getSelection, editSelection, removeStudent } = useSelectionApi();
  const [input, error, onChange, lengthValidation, setInput] = useFormFields({
    startAt: "",
    endAt: "",
  });
  const params = useParams();
  const selectionId = params.selectionId;
  const selection = useSelector((s) => s.store.selection);

  useEffect(() => {
    getSelection(selectionId);
  }, [selectionId]); // eslint-disable-line

  function editSelectionHandler() {
    editSelection(selectionId, {
      startAt: input.startAt,
      endAt: input.endAt,
      studentStatusId: input.statusId,
      selectionId: input.selectionId,
    });
  }

  function removeStudentHandler(studentId) {
    removeStudent({
      selectionId,
      studentId,
    });
  }

  useEffect(() => {
    if (selection.id == selectionId) { // eslint-disable-line
      setInput({
        startAt: moment(selection.startAt).format("YYYY-MM-DD"),
        endAt: moment(selection.endAt).format("YYYY-MM-DD"),
      });
    }
  }, [selection, selectionId]); // eslint-disable-line

  return (
    <CardWrapper title="Edit Selection">
      <InputField
        label="Start Date"
        name="startAt"
        type="date"
        value={input.startAt}
        onChange={onChange}
        error={error.startAt}
        onBlur={() => lengthValidation("startAt", 2, 999)}
      />
      <InputField
        label="End Date"
        name="endAt"
        type="date"
        value={input.endAt}
        onChange={onChange}
        error={error.endAt}
        onBlur={() => lengthValidation("endAt", 2, 999)}
      />
      <List
        sx={{
          width: "100%",
          position: "relative",
          overflow: "auto",
          maxHeight: 100,
          "& ul": { padding: 0 },
        }}
      >
        {selection.students &&
          selection.students.map((student, i) => (
            <div key={i}>
              <div style={style.student}>
                <Typography>
                  {student.firstName + " " + student.lastName}
                </Typography>
                <Button onClick={() => removeStudentHandler(student.id)}>
                  X
                </Button>
              </div>
            </div>
          ))}
      </List>
      <Button variant="contained" fullWidth onClick={editSelectionHandler}>
        Edit Selection
      </Button>
    </CardWrapper>
  );
}

const style = {
  student: {
    backgroundColor: "white",
    borderRadius: "5px",
    padding: 5,
    display: "flex",
    justifyContent: "space-between",
    alignItems: "center",
    margin: 5,
  },
};
