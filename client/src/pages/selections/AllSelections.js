import { useSelector } from "react-redux";
import { useEffect } from "react";

import { useSelectionApi } from "../../hooks/useSelectionApi";
import SelectionsTable from "../../components/SelectionsTable";

export default function AllSelections() {
  const { getSelections, apiError } = useSelectionApi();
  const selections = useSelector((s) => s.store.selections);

  useEffect(() => {
    getSelections();
  }, []);

  return <SelectionsTable />;
}
