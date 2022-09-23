import { useSelector } from "react-redux";

export default function Homepage() {
  const user = useSelector((s) => s.store.user);
  console.log(user);

  return <div>Homepage</div>;
}
