import { Route, Routes } from "react-router-dom";
import AddComment from "../pages/AddComment";
import Login from "../pages/Login";
import LectureEventRouter from "./LectureEventRouter";
import ProgramRouter from "./ProgramRouter";
import ProtectedRoutes from "./ProtectedRoutes";
import SelectionsRouter from "./SelectionsRouter";
import StudentRouter from "./StudentRouter";

export default function Router() {
  return (
    <Routes>
      <Route exact path="/" element={<Login />} />
      <Route element={<ProtectedRoutes />}>
        <Route exact path="/*" element={<StudentRouter />} />
        <Route exact path="/programs/*" element={<ProgramRouter />} />
        <Route exact path="/add-comment/:studentId" element={<AddComment />} />
        <Route exact path="/selections/*" element={<SelectionsRouter />} />
        <Route exact path="/lecture-event/*" element={<LectureEventRouter />} />
      </Route>
    </Routes>
  );
}
