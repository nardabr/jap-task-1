import { useSelector } from "react-redux";
import { useEffect } from "react";
import { useParams } from "react-router-dom";
import { useNavigate } from "react-router-dom";

import { useStudentApi } from "../../hooks/useStudentApi";
import { useFormFields } from "../../hooks/useFormFields";
import CardWrapper from "../../components/UI/CardWrapper";
import StudentForm from "../../components/UI/StudentForm";
import { Button } from "@mui/material";

export default function DetailsStudent() {
  const { getStudent } = useStudentApi();
  const navigate = useNavigate();
  const [input, error, onChange, lengthValidation, setInput] = useFormFields({
    firstName: "",
    lastName: "",
    status: {},
    selection: {},
    program: {},
    comments: [],
  });

  const params = useParams();
  const studentId = params.studentId;
  const student = useSelector((s) => s.store.student);
  const userId = useSelector((s) => s.store.userId);
  const user = useSelector((s) => s.store.user);

  useEffect(() => {
    if (user === "admin") {
      getStudent(studentId);
    } else {
      getStudent(userId);
    }
  }, [studentId, userId]); // eslint-disable-line

  useEffect(() => {
    if (user === "admin" && student.id == studentId) { // eslint-disable-line
      setInput({
        firstName: student.firstName,
        lastName: student.lastName,
        status: { ...student.status },
        selection: { ...student.selection },
        program: { ...student.selection?.program },
        comments: [...student.comments],
      });
    }
    if (user === "student" && student.id == userId) { // eslint-disable-line
      setInput({
        firstName: student.firstName,
        lastName: student.lastName,
        program: { ...student.selection?.program },
        comments: [...student.comments],
      });
    }
  }, [student, userId]); // eslint-disable-line

  if (!input.firstName) return null;
  return (
    <CardWrapper title="Student Details">
      <StudentForm
        view={true}
        input={input}
        onChange={onChange}
        lengthValidation={lengthValidation}
        error={error}
      />
      <Button
        variant="contained"
        fullWidth
        onClick={() =>
          navigate(`/programs/details/${student.selection.program.id}`)
        }
      >
        See Lectures and Events
      </Button>
    </CardWrapper>
  );
}
