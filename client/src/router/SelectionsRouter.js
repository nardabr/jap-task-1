import { Route, Routes } from "react-router-dom";
import AllSelections from "../pages/selections/AllSelections";
import EditSelection from "../pages/selections/EditSelection";

export default function SelectionsRouter() {
  return (
    <Routes>
      <Route exact path="all" element={<AllSelections />} />
      <Route
        exact
        path="edit-selection/:selectionId"
        element={<EditSelection />}
      />
    </Routes>
  );
}
