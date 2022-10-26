import { useSelector } from "react-redux";

import InputField from "./InputField";
import { styleTextField } from "../../helpers/constants";
import { Typography, MenuItem, Button } from "@mui/material";

export default function StudentForm({
  view,
  input,
  lengthValidation,
  onChange,
  error,
  edit,
  submitHandler,
  add,
}) {
  const selections = useSelector((s) => s.store.selections);
  const studentStatuses = useSelector((s) => s.store.studentStatuses);
  const user = useSelector((s) => s.store.user);
  
  return (
    <div>
      <InputField
        disabled={view}
        label="First Name"
        name="firstName"
        value={input.firstName}
        onChange={onChange}
        error={error.firstName}
        sx={styleTextField}
        onBlur={() => lengthValidation("firstName", 1, 999)}
      />
      &nbsp;
      <InputField
        disabled={view}
        label="Last Name"
        name="lastName"
        value={input.lastName}
        onChange={onChange}
        error={error.lastName}
        sx={styleTextField}
        onBlur={() => lengthValidation("lastName", 1, 999)}
      />
      &nbsp;
      {user === "admin" && add && (
        <InputField
          disabled={view}
          label="Email"
          name="email"
          value={input.email}
          onChange={onChange}
          error={error.email}
          sx={styleTextField}
          onBlur={() => lengthValidation("email", 1, 999)}
        />
      )}
      &nbsp;
      {user === "admin" && view && (
        <InputField
          disabled={view}
          label="Status"
          name="status"
          value={input.status.name}
          onChange={onChange}
          error={error.status.name}
          sx={styleTextField}
          onBlur={() => lengthValidation("status", 1, 999)}
        />
      )}
      {user === "admin" && !view && (
        <InputField
          disabled={view}
          label="Status"
          name="statusId"
          value={input.statusId}
          onChange={onChange}
          select={edit || add}
          sx={styleTextField}
        >
          {studentStatuses.map((status) => (
            <MenuItem key={status.id} value={status.id} sx={{ maxHeight: 15 }}>
              {status.name}
            </MenuItem>
          ))}
        </InputField>
      )}
      &nbsp;
      {user === "admin" && view && (
        <InputField
          disabled={view}
          label="Selection"
          name="selection"
          value={input.selection.name}
          onChange={onChange}
          error={error.selection.name}
          sx={styleTextField}
          onBlur={() => lengthValidation("selection", 1, 999)}
        />
      )}
      {user === "admin" && !view && (
        <InputField
          label="Selection"
          name="selectionId"
          value={input.selectionId}
          onChange={onChange}
          select={edit || add}
          sx={styleTextField}
        >
          {selections.map((selection) => (
            <MenuItem
              key={selection.id}
              value={selection.id}
              sx={{ maxHeight: 15 }}
            >
              {selection.name}
            </MenuItem>
          ))}
        </InputField>
      )}
      &nbsp;
      {view && input?.program && (
        <InputField
          disabled={view || edit}
          label="Program info"
          name="program"
          value={input.program.description}
          onChange={onChange}
          error={error.program.description}
          sx={styleTextField}
          multiline
          onBlur={() => lengthValidation("program", 1, 999)}
        />
      )}
      &nbsp;
      {user === "admin" && view && (
        <div>
          <Typography variant="h6" gutterBottom>
            Comments
          </Typography>
          {input.comments.length > 0 ? (
            input.comments.map((comment) => (
              <div key={comment.id}>• {comment.text}</div>
            ))
          ) : (
            <Typography variant="subtitle2">No comments yet.</Typography>
          )}
        </div>
      )}
      &nbsp;
      {!view && (
        <Button variant="contained" fullWidth onClick={submitHandler}>
          {edit ? "Edit Student" : "Add Student"}
        </Button>
      )}
    </div>
  );
}
