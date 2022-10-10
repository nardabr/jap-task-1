import { useEffect, useState } from "react";
import { useSelector } from "react-redux";

import { useStudentApi } from "../../hooks/useStudentApi";

import Modal from "../../components/UI/Modal";
import ModalDelete from "../../components/ModalDelete";
import StudentsTable from "../../components/StudentsTable";
import DetailsStudent from "../students/DetailsStudent";

export default function Homepage() {
  const { getStudents, deleteStudent } = useStudentApi();
  const user = useSelector((s) => s.store.user);
  const [open, setOpen] = useState(false);
  const [deleteModal, setDeleteModal] = useState(false);
  const [page, setPage] = useState(1);
  const pageSize = 4;
  const [search, setSearch] = useState(["", "", "", "", ""]);
  const [field, setField] = useState("");
  const [order, setOrder] = useState(["", "", "", "", ""]);

  function setSearchHandler(e, i, field) {
    for (let i = 0; i < search.length; i++) {
      search[i] = "";
    }
    search[i] = e.target.value;
    setSearch([...search]);
    setField(field);
    if (search[i].length) {
      getStudents(page, pageSize, field, search[i]);
    } else {
      setField("");
      getStudents(page, pageSize);
    }
  }

  function setOrderHandler(i, fieldToOrder) {
    if (!order[i]) {
      for (let i = 0; i < order.length; i++) {
        order[i] = "";
      }
    }
    order[i] = fieldToOrder;
    setOrder([...order]);
    if (order[i].length && !field) {
      getStudents(page, pageSize, undefined, undefined, order[i]);
    } else if (order[i].length && field) {
      var s = search.filter((se) => se);
      getStudents(page, pageSize, field, s[0], order[i]);
    } else getStudents(page, pageSize);
  }

  useEffect(() => {
    getStudents(page, pageSize);
    console.clear();
  }, [page]); // eslint-disable-line

  function deleteStudentHandler() {
    deleteStudent(deleteModal);
    setDeleteModal(false);
  }

  return (
    <>
      {open && <Modal onClose={() => setOpen(false)} open={open} />}
      {deleteModal && (
        <ModalDelete
          onClose={() => setDeleteModal(false)}
          deleteModal={deleteModal}
          deleteStudentHandler={deleteStudentHandler}
        />
      )}
      {user === "admin" ? (
        <StudentsTable
          setOpen={setOpen}
          setDeleteModal={setDeleteModal}
          search={search}
          setSearchHandler={setSearchHandler}
          order={order}
          setOrderHandler={setOrderHandler}
          page={page}
          setPage={setPage}
        />
      ) : (
        <DetailsStudent />
      )}
    </>
  );
}
