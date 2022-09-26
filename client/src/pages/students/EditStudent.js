import { useSelector } from "react-redux";
import { useEffect } from "react";
import { useParams } from "react-router-dom";

import { useStudentApi } from "../../hooks/useStudentApi";
import { useSelectionApi } from "../../hooks/useSelectionApi";
import { useFormFields } from "../../hooks/useFormFields";
import CardWrapper from "../../components/UI/CardWrapper";
import StudentForm from "../../components/UI/StudentForm";

export default function EditStudent() {
  const { getStudent, getStudentStatuses, editStudent } = useStudentApi();
  const { getSelections } = useSelectionApi();
  const [input, error, onChange, lengthValidation, setInput] = useFormFields({
    firstName: "",
    lastName: "",
    statusId: 0,
    selectionId: 0,
    comments: [],
  });
 
  const params = useParams();
  const studentId = params.studentId;
  const student = useSelector((s) => s.store.student);

  useEffect(() => {
    getStudent(studentId);
    getSelections();
    getStudentStatuses();
  }, [studentId]); // eslint-disable-line

  function editStudentHandler() {
    editStudent(studentId, {
      firstName: input.firstName,
      lastName: input.lastName,
      studentStatusId: input.statusId,
      selectionId: input.selectionId,
    });
  }

  useEffect(() => {
    if (student.id == studentId) { // eslint-disable-line
      setInput({
        firstName: student.firstName,
        lastName: student.lastName,
        statusId: student.status.id,
        selectionId: student.selection?.id,
        comments: [...student.comments],
      });
    }
  }, [student, studentId]); // eslint-disable-line

  // if (!input.selectionId) return null;
  return (
    <CardWrapper title="Edit Student">
      <StudentForm
        edit={true}
        input={input}
        onChange={onChange}
        lengthValidation={lengthValidation}
        error={error}
        submitHandler={editStudentHandler}
      />
    </CardWrapper>
  );
}
