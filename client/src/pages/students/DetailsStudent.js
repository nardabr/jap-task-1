import { useSelector } from "react-redux";
import { useEffect } from "react";
import { useParams } from "react-router-dom";

import { useStudentApi } from "../../hooks/useStudentApi";
import { useFormFields } from "../../hooks/useFormFields";
import CardWrapper from "../../components/UI/CardWrapper";
import StudentForm from "../../components/UI/StudentForm";

export default function DetailsStudent() {
  const { getStudent, apiError } = useStudentApi();
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

  useEffect(() => {
    getStudent(studentId);
  }, [studentId]);

  useEffect(() => {
    if (student.id == studentId) {
      setInput({
        firstName: student.firstName,
        lastName: student.lastName,
        status: { ...student.status },
        selection: { ...student.selection },
        program: { ...student.selection?.program },
        comments: [...student.comments],
      });
    }
  }, [student, studentId]);

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
    </CardWrapper>
  );
}
