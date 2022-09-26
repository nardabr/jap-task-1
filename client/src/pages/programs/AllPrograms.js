import { useEffect } from "react";
import { useSelector } from "react-redux";

import { useProgramApi } from "../../hooks/useProgramApi";

import { Card, CardActionArea, CardContent, Typography } from "@mui/material";
import "../../assets/css/allPrograms.css";

export default function AllPrograms() {
  const { getAllPrograms } = useProgramApi();
  const allPrograms = useSelector((s) => s.store.allPrograms);

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
          <CardActionArea>
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
        </Card>
      ))}
    </div>
  );
}
