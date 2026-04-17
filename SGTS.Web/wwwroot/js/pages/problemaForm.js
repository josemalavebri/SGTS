import formComponent from "../components/form/core/formComponent.js";
import uiModal from "../components/ui/modal.js";

const createProblemFormHandler = ({ onSubmit, onSuccess, fetchUsuarios }) => {
  const problemForm = formComponent.createFormComponent({
    formSelector: "#problemaForm",
    fields: {
      id: {
        type: "text",
      },
      usuarioId: {
        type: "text",
        required: true,
      },
      descripcion: {
        type: "text",
        required: true,
      },
      estadoProblemaId: {
        type: "text",
        required: true,
      },
      prioridadId: {
        type: "text",
        required: true,
      },
      imagen: {
        type: "file",
      },
    },
  });

  const setupUserSearch = () => {
    const input = document.getElementById("usuarioSearch");
    const results = document.getElementById("usuarioResults");

    if (!input || !results) return;

    let debounceTimer;

    input.addEventListener("input", (e) => {
      const term = e.target.value.trim();

      clearTimeout(debounceTimer);

      debounceTimer = setTimeout(async () => {
        if (term.length < 2) {
          results.innerHTML = "";
          return;
        }

        const usuarios = await fetchUsuarios(term);
        console.log("fetch: " + usuarios);
        renderResults(usuarios, input, results);
      }, 500);
    });
  };

  const renderResults = (usuarios, input, results) => {
    results.innerHTML = "";

    usuarios.forEach((u) => {
      const item = document.createElement("button");
      item.type = "button";
      item.className = "list-group-item list-group-item-action";
      item.textContent = `${u.nombre} - ${u.correo}`;

      item.addEventListener("click", () => {
        selectUsuario(u, input, results);
      });

      results.appendChild(item);
    });
  };

  const selectUsuario = (usuario, input, results) => {
    document.querySelector('[name="usuarioId"]').value = usuario.id;
    input.value = usuario.nombre;
    results.innerHTML = "";
  };

  const openCreate = () => {
    problemForm.set(null);
    uiModal.setTitle("problemaModal", "Crear Problema");
    uiModal.show("problemaModal");
  };

  const openEdit = (problem) => {
    problemForm.set(problem);

    if (problem?.usuarioNombre) {
      document.getElementById("usuarioSearch").value = problem.usuarioNombre;
    }

    uiModal.setTitle("problemaModal", "Editar Problema");
    uiModal.show("problemaModal");
  };

  const handleSubmit = async () => {
    const data = await problemForm.submit();
    if (!data) return;

    const isEdit = !!data.id;

    const success = await onSubmit({ data, isEdit });
    if (!success) return;

    uiModal.hide("problemaModal");
    uiModal.clean();
    problemForm.reset();

    document.getElementById("usuarioSearch").value = "";
    document.getElementById("usuarioResults").innerHTML = "";

    onSuccess?.({ data, isEdit });
  };

  const bindEvents = () => {
    document
      .getElementById("btnSaveProblem")
      ?.addEventListener("click", async (e) => {
        e.preventDefault();
        e.stopPropagation();
        await handleSubmit();
      });

    setupUserSearch();
  };

  return {
    openCreate,
    openEdit,
    bindEvents,
  };
};

export default { createProblemFormHandler };
