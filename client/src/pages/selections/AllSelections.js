import { useEffect } from "react";

import { useSelectionApi } from "../../hooks/useSelectionApi";
import SelectionsTable from "../../components/SelectionsTable";

export default function AllSelections() {
  const { getSelections } = useSelectionApi();

  useEffect(() => {
    getSelections();
  }, []); // eslint-disable-line

  return <SelectionsTable />;
}
