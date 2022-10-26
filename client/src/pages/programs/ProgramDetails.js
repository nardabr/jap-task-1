import { useSelector } from "react-redux";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

import LectureEventTable from "../../components/LectureEventTable";
import ModalDelete from "../../components/ModalDelete";
import { useProgramApi } from "../../hooks/useProgramApi";
import { useLectureEventApi } from "../../hooks/useLectureEventApi";
import StudentDetailsTable from "../../components/StudentDetailsTable";

export default function ProgramDetails() {
  const { getProgramDetails } = useProgramApi();
  const { deleteLectureEvent } = useLectureEventApi();
  const params = useParams();
  const programId = params.programId;
  const programDetails = useSelector((s) => s.store.programDetails);
  const user = useSelector((s) => s.store.user);
  const [deleteModal, setDeleteModal] = useState(false);

  useEffect(() => {
    getProgramDetails(programId);
  }, [programId]); // eslint-disable-line

  function deleteLectureEventHandler() {
    deleteLectureEvent(deleteModal);
    setDeleteModal(false);
  }

  return (
    <div>
      {deleteModal && (
        <ModalDelete
          onClose={() => setDeleteModal(false)}
          deleteModal={deleteModal}
          deleteHandler={deleteLectureEventHandler}
          title="this event / program"
        />
      )}
      {user === "admin" ? (
        <LectureEventTable
          programId={programId}
          getProgramDetails={getProgramDetails}
          setDeleteModal={setDeleteModal}
        />
      ) : (
        programDetails.length > 0 && (
          <StudentDetailsTable programDetails={programDetails} />
        )
      )}
    </div>
  );
}
