import { Typography } from "@mui/material";
import { useEffect } from "react";
import { useSelector } from "react-redux";
import CardWrapper from "../components/UI/CardWrapper";

import { useSelectionApi } from "../hooks/useSelectionApi";

export default function ReportTab() {
  const { getSelectionsSuccessRates, getOverallSuccessRate } =
    useSelectionApi();
  const selectionsSuccessRates = useSelector(
    (s) => s.store.selectionsSuccessRates
  );
  const overallSuccessRate = useSelector((s) => s.store.overallSuccessRate);

  useEffect(() => {
    getSelectionsSuccessRates();
    getOverallSuccessRate();
  }, []); // eslint-disable-line

  return (
    <CardWrapper title="Report Tab">
      <Typography sx={style.title} variant="h6">
        Selections Success Rates
      </Typography>
      {selectionsSuccessRates &&
        selectionsSuccessRates.map((ssr, i) => (
          <div style={style.selectionsDiv} key={i}>
            <Typography>Selection Name : {ssr.selectionName}</Typography>
            <Typography>ProgramName : {ssr.programName}</Typography>
            <Typography>Success Rate : {ssr.selectionSuccessRate} %</Typography>
          </div>
        ))}
      <Typography sx={style.title} variant="h6">
        Overall Success Rate
      </Typography>

      <div style={style.selectionsDiv}>
        <Typography>
          All Selections Rate: {overallSuccessRate.overallSuccessRate} %
        </Typography>
      </div>
    </CardWrapper>
  );
}

const style = {
  selectionsDiv: {
    display: "flex",
    flexDirection: "column",
    justifyContent: "flex-start",
    alignItems: "center",
  },
  title: {
    fontWeight: "bold",
  },
};
