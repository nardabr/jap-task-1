import { useState } from "react";

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
  const [anchorEl, setAnchorEl] = useState(null);

  const handleMenu = (event) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static">
        <Toolbar>
          <CardMedia
            component="img"
            image={logo}
            alt="school-logo"
            sx={styles.logo}
          />
          &emsp;
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            Jap platform
          </Typography>
          <div>
            <IconButton
              size="large"
              aria-label="account of current user"
              aria-controls="menu-appbar"
              aria-haspopup="true"
              onClick={handleMenu}
              color="inherit"
            >
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
            >
              <MenuItem onClick={handleClose}>All Programs</MenuItem>
              <MenuItem onClick={handleClose}>Selections</MenuItem>
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
