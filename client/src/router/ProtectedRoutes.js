import { useSelector } from "react-redux";
import { Outlet } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import { Box, Button, CircularProgress } from "@mui/material";

export default function ProtectedRoutes() {
  const user = useSelector((s) => s.store.user);
  const navigate = useNavigate();

  function toRegisterHandler() {
    navigate("/");
    window.location.reload();
    return false;
  }

  if (!user)
    return (
      <Box sx={style}>
        <CircularProgress />
        &nbsp;
        <Button
          variant="contained"
          className="linear-button"
          onClick={toRegisterHandler}
        >
          Back to Homepage
        </Button>
      </Box>
    );

  return <>{user && <Outlet />}</>;
}

const style = {
  display: "flex",
  flexDirection: "column",
  alignItems: "center",
  justifyContent: "center",
  marginTop: "250px",
};
