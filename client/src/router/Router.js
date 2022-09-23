import { Route, Routes } from "react-router-dom";
import Login from "../pages/Login";
import ProtectedRoutes from "./ProtectedRoutes";
import StudentRouter from "./StudentRouter";

export default function Router() {
  return (
    <Routes>
      <Route exact path="/" element={<Login />} />
      <Route element={<ProtectedRoutes />}>
        <Route exact path="/*" element={<StudentRouter />} />
      </Route>
    </Routes>
  );
}
