import { useEffect } from "react";
import { useSelector } from "react-redux";

import { useFormFields } from "../../hooks/useFormFields";
import { useStudentApi } from "../../hooks/useStudentApi";
import { useSelectionApi } from "../../hooks/useSelectionApi";
import CardWrapper from "../../components/UI/CardWrapper";
import StudentForm from "../../components/UI/StudentForm";

export default function AddStudent() {
  const { getStudentStatuses, addNewStudent } = useStudentApi();
  const { getSelections } = useSelectionApi();
  const [input, error, onChange, lengthValidation] = useFormFields({
    firstName: "",
    lastName: "",
    statusId: "",
    selectionId: "",
  });
  const studentStatuses = useSelector((s) => s.store.studentStatuses);

  useEffect(() => {
    getSelections();
    getStudentStatuses();
  }, []); // eslint-disable-line

  function addStudentHandler() {
    addNewStudent({
      firstName: input.firstName,
      lastName: input.lastName,
      studentStatusId: input.statusId,
      selectionId: input.selectionId,
    });
  }

  if (!studentStatuses) return null;
  return (
    <CardWrapper title="Add Student">
      <StudentForm
        add={true}
        input={input}
        onChange={onChange}
        lengthValidation={lengthValidation}
        error={error}
        submitHandler={addStudentHandler}
      />
    </CardWrapper>
  );
}
