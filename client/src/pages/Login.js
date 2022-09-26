import { Button } from "@mui/material";

import { useFormFields } from "../hooks/useFormFields";
import { useUserApi } from "../hooks/useUserApi";

import CardWrapper from "../components/UI/CardWrapper";
import InputField from "../components/UI/InputField";

export default function Login() {
  const [input, error, onChange, lengthValidation] = useFormFields({
    email: "",
    password: "",
  });
  const { loginUser } = useUserApi();

  function onLoginHandler() {
    loginUser(input);
  }

  return (
    <CardWrapper title="Login">
      <InputField
        label="Email"
        name="email"
        value={input.email}
        onChange={onChange}
        error={error.email}
        onBlur={() => lengthValidation("email", 1, 999)}
      />
      <InputField
        label="Password"
        name="password"
        type="password"
        value={input.password}
        onChange={onChange}
        error={error.password}
        onBlur={() => lengthValidation("password", 6, 999)}
      />
      <Button
        variant="contained"
        className="main-button"
        onClick={onLoginHandler}
        fullWidth
      >
        Login
      </Button>
    </CardWrapper>
  );
}
