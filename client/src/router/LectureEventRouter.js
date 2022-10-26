import { Route, Routes } from "react-router-dom";
import AddLectureEvent from "../pages/lecturesEvent/AddLectureEvent";
import EditLectureEvent from "../pages/lecturesEvent/EditLectureEvent";

export default function LectureEventRouter() {
  return (
    <Routes>
      <Route exact path="add-new/:programId" element={<AddLectureEvent />} />
      <Route exact path="edit/:programId" element={<EditLectureEvent />} />
    </Routes>
  );
}
