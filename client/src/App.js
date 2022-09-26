import { useSelector } from "react-redux";

import Navbar from "./components/Navbar";
import Router from "./router/Router";

export default function App() {
  const user = useSelector((s) => s.store.user);

  return (
    <div>
      {user && <Navbar />}
      <Router />
    </div>
  );
}
