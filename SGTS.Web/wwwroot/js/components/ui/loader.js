import loadingStore from "../../state/loadingStore.js";

const loader = (() => {
  let element = null;

  const init = () => {
    element = document.getElementById("globalLoader");

    if (!element) throw new Error("Loader no encontrado");

    loadingStore.subscribe(({ loading }) => {
      if (loading) {
        element.classList.remove("d-none");
      } else {
        element.classList.add("d-none");
      }
    });
  };

  return { init };
})();

export default loader;
