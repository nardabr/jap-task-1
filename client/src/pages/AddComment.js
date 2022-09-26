import { useSelector } from "react-redux";
import { useEffect } from "react";
import { useParams } from "react-router-dom";

import { useStudentApi } from "../hooks/useStudentApi";
import { useCommentApi } from "../hooks/useCommentApi";
import { useFormFields } from "../hooks/useFormFields";
import { Typography, Button } from "@mui/material";
import CardWrapper from "../components/UI/CardWrapper";
import InputField from "../components/UI/InputField";

export default function AddComment() {
  const { getStudent } = useStudentApi();
  const { createComment } = useCommentApi();
  const [input, error, onChange, lengthValidation] = useFormFields({
    text: "",
  });
  const params = useParams();
  const studentId = params.studentId;
  const student = useSelector((s) => s.store.student);

  useEffect(() => {
    getStudent(studentId);
  }, [studentId]); // eslint-disable-line

  function addCommentHandler() {
    createComment({
      text: input.text,
      studentId,
    });
  }

  return (
    <CardWrapper title="Add Comments">
      <div>
        <Typography variant="h6" gutterBottom>
          Comments
        </Typography>
        {student?.comments?.length > 0 ? (
          student.comments.map((comment) => (
            <div key={comment.id}>• {comment.text}</div>
          ))
        ) : (
          <Typography variant="subtitle2">No comments yet.</Typography>
        )}
      </div>
      <InputField
        label="Text"
        name="text"
        value={input.text}
        onChange={onChange}
        error={error.text}
        onBlur={() => lengthValidation("text", 1, 999)}
      />
      <Button variant="contained" fullWidth onClick={addCommentHandler}>
        Add Comments
      </Button>
    </CardWrapper>
  );
}
