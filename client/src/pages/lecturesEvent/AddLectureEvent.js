import { useParams } from "react-router-dom";

import { useFormFields } from "../../hooks/useFormFields";
import { useLectureEventApi } from "../../hooks/useLectureEventApi";
import CardWrapper from "../../components/UI/CardWrapper";
import LectureEventForm from "../../components/UI/LectureEventForm";

export default function AddLectureEvent() {
  const { addNewLectureEvent } = useLectureEventApi();
  const params = useParams();
  const programId = params.programId;
  const [input, error, onChange, lengthValidation] = useFormFields({
    programId: 0,
    type: "",
    name: "",
    description: "",
    url: "",
    workHours: "",
  });

  function addLectureEventHandler() {
    addNewLectureEvent({
      programId,
      type: input.type,
      name: input.name,
      description: input.description,
      url: input.url,
      workHours: input.workHours,
    });
  }

  return (
    <CardWrapper title="Add Lecture Or Event">
      <LectureEventForm
        input={input}
        onChange={onChange}
        lengthValidation={lengthValidation}
        error={error}
        submitHandler={addLectureEventHandler}
      />
    </CardWrapper>
  );
}
