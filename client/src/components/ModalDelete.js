import { Button, Typography } from "@mui/material";

export default function ModalDelete({
  onClose,
  deleteModal,
  deleteHandler,
  title,
}) {
  return (
    <div className="overlay_styles">
      <div className="modal_styles">
        <div>
          <Typography variant="h6" sx={style.title}>
            Are you sure you want to permanently erase {title}?
          </Typography>
          &nbsp;
          <Typography align="center">You can't undo this action!</Typography>
        </div>
        &nbsp;
        <div style={style.buttons}>
          <Button
            variant="contained"
            fullWidth
            color="inherit"
            onClick={onClose}
          >
            Cancel
          </Button>
          <Button
            variant="contained"
            fullWidth
            sx={style.button}
            onClick={deleteHandler}
          >
            Delete
          </Button>
        </div>
      </div>
    </div>
  );
}

const style = {
  title: {
    textAlign: "center",
    color: "#b80c09",
  },
  buttons: {
    display: "flex",
    gap: "15px",
  },
  button: {
    backgroundColor: "#b80c09",
  },
};
