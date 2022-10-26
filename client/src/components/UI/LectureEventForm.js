import InputField from "./InputField";
import { MenuItem, Button } from "@mui/material";
import { data } from "../../helpers/constants";

export default function LectureEventForm({
  input,
  lengthValidation,
  onChange,
  error,
  submitHandler,
  edit,
}) {
  return (
    <div>
      <InputField
        label="Type"
        name="type"
        value={input.type}
        onChange={onChange}
        select={true}
      >
        {data.map((option) => (
          <MenuItem
            key={option}
            value={option}
            sx={{
              maxHeight: 15,
            }}
          >
            {option}
          </MenuItem>
        ))}
      </InputField>
      &nbsp;
      <InputField
        label="Name"
        name="name"
        value={input.name}
        onChange={onChange}
        error={error.name}
        onBlur={() => lengthValidation("name", 1, 999)}
      />
      &nbsp;
      <InputField
        label="Description"
        name="description"
        value={input.description}
        onChange={onChange}
        error={error.description}
        multiline
        onBlur={() => lengthValidation("description", 1, 999)}
      />
      &nbsp;
      <InputField
        label="URL"
        name="url"
        value={input.url}
        onChange={onChange}
        error={error.url}
        multiline
        onBlur={() => lengthValidation("url", 1, 999)}
      />
      &nbsp;
      <InputField
        label="Work Hours"
        name="workHours"
        value={input.workHours}
        onChange={onChange}
        error={error.workHours}
        type="number"
        onBlur={() => lengthValidation("workHours", 1, 999)}
      />
      &nbsp;
      <Button variant="contained" fullWidth onClick={submitHandler}>
        {edit ? "Edit Event or Lecture" : "Add Event or Lecture"}
      </Button>
    </div>
  );
}
