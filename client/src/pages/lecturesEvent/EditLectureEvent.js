import { useSelector } from "react-redux";
import { useEffect } from "react";
import { useParams } from "react-router-dom";

import { useFormFields } from "../../hooks/useFormFields";
import { useLectureEventApi } from "../../hooks/useLectureEventApi";
import CardWrapper from "../../components/UI/CardWrapper";
import LectureEventForm from "../../components/UI/LectureEventForm";

export default function EditLectureEvent() {
  const params = useParams();
  const programId = params.programId;
  const { getLectureEventById, editLectureEvent } = useLectureEventApi();
  const [input, error, onChange, lengthValidation, setInput] = useFormFields({
    programId: 0,
    type: "",
    name: "",
    description: "",
    url: "",
    workHours: "",
  });
  const lectureEventById = useSelector((s) => s.store.lectureEventById);

  useEffect(() => {
    getLectureEventById(programId);
  }, [programId]); // eslint-disable-line

  useEffect(() => {
    if (lectureEventById.id == programId) { // eslint-disable-line
      setInput({
        programId: lectureEventById.programId,
        type: lectureEventById.type,
        name: lectureEventById.name,
        description: lectureEventById.description,
        url: lectureEventById.url,
        workHours: lectureEventById.workHours,
      });
    }
  }, [lectureEventById, programId]); // eslint-disable-line

  function editLectureEventHandler() {
    editLectureEvent(programId, input);
  }

  return (
    <CardWrapper title="Edit Lecture Or Event">
      <LectureEventForm
        edit={true}
        input={input}
        onChange={onChange}
        lengthValidation={lengthValidation}
        error={error}
        submitHandler={editLectureEventHandler}
      />
    </CardWrapper>
  );
}
