import { useEffect } from "react";
import { useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";

import { useProgramApi } from "../../hooks/useProgramApi";

import {
  Card,
  CardActionArea,
  CardContent,
  Typography,
  CardActions,
  Button,
} from "@mui/material";
import "../../assets/css/allPrograms.css";

export default function AllPrograms() {
  const navigate = useNavigate();
  const { getAllPrograms } = useProgramApi();
  const allPrograms = useSelector((s) => s.store.allPrograms);
  const user = useSelector((s) => s.store.user);

  function getAllProgramsHandler() {
    getAllPrograms();
  }

  useEffect(() => {
    getAllProgramsHandler();
  }, []); // eslint-disable-line

  return (
    <div className="all-programs_container">
      {allPrograms.map((program, i) => (
        <Card key={i} className="all-programs-card">
          <CardActionArea
            onClick={() => navigate(`/programs/details/${program.id}`)}
          >
            <CardContent>
              <Typography
                gutterBottom
                variant="h5"
                component="div"
                className="text"
              >
                {program.name}
              </Typography>
              <Typography variant="body2" color="text.secondary">
                {program.description}
              </Typography>
            </CardContent>
          </CardActionArea>
          {user === "admin" && (
            <CardActions>
              <Button
                variant="contained"
                color="primary"
                fullWidth
                onClick={() => navigate(`/lecture-event/add-new/${program.id}`)}
              >
                Add Program / Event
              </Button>
            </CardActions>
          )}
        </Card>
      ))}
    </div>
  );
}
