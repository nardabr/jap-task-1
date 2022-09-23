import { Card, Typography } from "@mui/material";
import "../../assets/css/cardWrapper.css";

export default function CardWrapper({ title, children }) {
  return (
    <Card className="card-wrapper">
      <Typography variant="h4" className="text">
        {title}
      </Typography>
      {children}
    </Card>
  );
}
