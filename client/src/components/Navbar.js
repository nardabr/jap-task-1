import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useSelector, useDispatch } from "react-redux";
import { actions } from "../store/store";

import {
  AppBar,
  Box,
  Toolbar,
  Typography,
  IconButton,
  MenuItem,
  Menu,
  CardMedia,
} from "@mui/material";
import AccountCircle from "@mui/icons-material/AccountCircle";
import logo from "../assets/img/elearning.png";

export default function Navbar() {
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const user = useSelector((s) => s.store.user);
  const [anchorEl, setAnchorEl] = useState(null);

  const handleMenu = (event) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  function allProgramsNavigate() {
    navigate("/programs/all-programs");
  }

  function homepageNavigate() {
    navigate("/homepage");
  }

  function allSelectionsNavigate() {
    navigate("/selections/all");
  }

  function reportTabNavigate() {
    navigate("/report-tab");
  }

  function logoutHandler() {
    dispatch(actions.logout());
    navigate("/");
  }

  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="fixed" sx={{ backgroundColor: "#0077b6" }}>
        <Toolbar>
          <CardMedia
            component="img"
            image={logo}
            alt="school-logo"
            sx={styles.logo}
          />
          &emsp;
          <Typography
            variant="h6"
            component="div"
            sx={{ flexGrow: 1, cursor: "pointer" }}
            onClick={homepageNavigate}
          >
            Jap platform
          </Typography>
          <div>
            <IconButton size="large" onClick={handleMenu} color="inherit">
              <AccountCircle />
            </IconButton>
            <Menu
              id="menu-appbar"
              anchorEl={anchorEl}
              anchorOrigin={{
                vertical: "top",
                horizontal: "right",
              }}
              keepMounted
              transformOrigin={{
                vertical: "top",
                horizontal: "right",
              }}
              open={Boolean(anchorEl)}
              onClose={handleClose}
              onClick={handleClose}
            >
              {user !== "student" && (
                <div>
                  <MenuItem onClick={allProgramsNavigate}>
                    All Programs
                  </MenuItem>
                  <MenuItem onClick={allSelectionsNavigate}>
                    Selections
                  </MenuItem>
                  <MenuItem onClick={reportTabNavigate}>Report tab</MenuItem>
                </div>
              )}
              <MenuItem onClick={logoutHandler}>Logout</MenuItem>
            </Menu>
          </div>
        </Toolbar>
      </AppBar>
    </Box>
  );
}

const styles = {
  logo: {
    width: 55,
  },
};
