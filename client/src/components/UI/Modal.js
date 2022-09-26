import { Button, Typography } from "@mui/material";

export default function Modal({ onClose, open }) {
  return (
    <div className="overlay_styles">
      <div className="modal_styles">
        <Typography variant="h5" float="left">
          {open.name}
        </Typography>
        &nbsp;
        <Typography variant="subtitle2">{open.description}</Typography>
        <div style={buttonPosition}>
          <Button onClick={onClose} variant="contained">
            Cancel
          </Button>
        </div>
      </div>
    </div>
  );
}

const buttonPosition = {
  float: "right",
  paddingTop: "6px",
};
