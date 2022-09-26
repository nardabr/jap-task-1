import { Route, Routes } from "react-router-dom";
import AllPrograms from "../pages/programs/AllPrograms";

export default function ProgramRouter() {
  return (
    <Routes>
      <Route exact path="all-programs" element={<AllPrograms />} />
    </Routes>
  );
}
