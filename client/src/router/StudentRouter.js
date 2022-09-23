import { Route, Routes } from "react-router-dom";
import Homepage from "../pages/students/Homepage";

export default function StudentRouter() {
  return (
    <Routes>
      <Route exact path="homepage" element={<Homepage />} />
    </Routes>
  );
}
