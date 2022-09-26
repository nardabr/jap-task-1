import { TextField } from "@mui/material";

export default function InputField(props) {
  return (
    <TextField
      error={props.error?.length > 0}
      label={props.label}
      type={props.type || "text"}
      name={props.name}
      helperText={props.error}
      value={props.value}
      onChange={props.onChange}
      onBlur={props.onBlur}
      fullWidth
      multiline={props.multiline}
      select={props.select}
      disabled={props.disabled}
      sx={props.sx}
    >
      {props.children}
    </TextField>
  );
}
