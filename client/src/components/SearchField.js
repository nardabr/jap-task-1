import { InputBase } from "@mui/material";
import { styled, alpha } from "@mui/material/styles";
import SearchIcon from "@mui/icons-material/Search";

export default function SearchField({ name, i, setSearchHandler, search }) {
  function onSearchHandler(e) {
    setSearchHandler(e, i, name);
  }

  return (
    <div>
      <Search>
        <SearchIconWrapper>
          <SearchIcon color="action" />
        </SearchIconWrapper>
        <StyledInputBase
          placeholder="Search…"
          inputProps={{ "aria-label": "search" }}
          value={search[i]}
          onChange={(e) => onSearchHandler(e)}
        />
      </Search>
    </div>
  );
}

const Search = styled("div")(({ theme }) => ({
  position: "relative",
  borderRadius: theme.shape.borderRadius,
  backgroundColor: alpha("#f8f9fa", 0.45),
  "&:hover": {
    backgroundColor: alpha("#ced4da", 0.75),
  },
  marginLeft: 0,
  width: "100%",
  [theme.breakpoints.up("sm")]: {
    width: "100%",
  },
  border: "1px solid rgba(0,0,0,0.5)",
}));

const SearchIconWrapper = styled("div")(({ theme }) => ({
  padding: theme.spacing(0, 2),
  height: "100%",
  position: "absolute",
  pointerEvents: "none",
  display: "flex",
  alignItems: "center",
  justifyContent: "center",
}));

const StyledInputBase = styled(InputBase)(({ theme }) => ({
  color: "inherit",
  "& .MuiInputBase-input": {
    padding: theme.spacing(1, 7, 1, 0),
    paddingLeft: `calc(1em + ${theme.spacing(4)})`,
    transition: theme.transitions.create("width"),
    width: "100%",
    [theme.breakpoints.up("sm")]: {
      width: "8ch",
      "&:focus": {
        width: "9ch",
      },
    },
    color: "black",
  },
}));
