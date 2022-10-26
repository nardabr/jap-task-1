import { Route, Routes } from "react-router-dom";
import AllPrograms from "../pages/programs/AllPrograms";
import ProgramDetails from "../pages/programs/ProgramDetails";

export default function ProgramRouter() {
  return (
    <Routes>
      <Route exact path="all-programs" element={<AllPrograms />} />
      <Route exact path="details/:programId" element={<ProgramDetails />} />
    </Routes>
  );
}
