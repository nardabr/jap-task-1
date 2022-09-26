import { Route, Routes } from "react-router-dom";
import AddStudent from "../pages/students/AddStudent";
import DetailsStudent from "../pages/students/DetailsStudent";
import EditStudent from "../pages/students/EditStudent";
import Homepage from "../pages/students/Homepage";

export default function StudentRouter() {
  return (
    <Routes>
      <Route exact path="homepage" element={<Homepage />} />
      <Route exact path="edit-student/:studentId" element={<EditStudent />} />
      <Route
        exact
        path="details-student/:studentId"
        element={<DetailsStudent />}
      />
      <Route exact path="add-student" element={<AddStudent />} />
    </Routes>
  );
}
