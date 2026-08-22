const containerSelector = ".ticket-pagination";

let currentPage = 1;
let pageSize = 0;
let totalRecords = 0;

let paginationLoaded = false;

let onPageChangeCallback = null;

const getContainer = () => {
  return document.querySelector(containerSelector);
};

const getTotalPages = () => {
  if (!pageSize) {
    return 1;
  }

  return Math.max(1, Math.ceil(totalRecords / pageSize));
};

const getStart = () => {
  return (currentPage - 1) * pageSize;
};

const changePage = (page) => {
  const totalPages = getTotalPages();

  if (page < 1 || page > totalPages || page === currentPage) {
    return;
  }

  currentPage = page;

  render();

  if (onPageChangeCallback) {
    onPageChangeCallback();
  }
};

const createPageItem = (page) => {
  const item = document.createElement("li");

  item.className = `page-item ${page === currentPage ? "active" : ""}`;

  const button = document.createElement("button");

  button.type = "button";
  button.className = "page-link";
  button.textContent = page;

  button.addEventListener("click", () => {
    changePage(page);
  });

  item.appendChild(button);

  return item;
};

const createNavigationItem = (direction) => {
  const item = document.createElement("li");

  const isPrevious = direction === "previous";
  const totalPages = getTotalPages();

  const disabled = isPrevious ? currentPage === 1 : currentPage === totalPages;

  item.className = `page-item ${disabled ? "disabled" : ""}`;

  const button = document.createElement("button");

  button.type = "button";
  button.className = "page-link";

  button.setAttribute("aria-label", isPrevious ? "Anterior" : "Siguiente");

  button.innerHTML = isPrevious
    ? '<i class="bi bi-chevron-left"></i>'
    : '<i class="bi bi-chevron-right"></i>';

  if (!disabled) {
    button.addEventListener("click", () => {
      changePage(isPrevious ? currentPage - 1 : currentPage + 1);
    });
  }

  item.appendChild(button);

  return item;
};

const renderSummary = () => {
  const container = getContainer();

  if (!container) {
    return;
  }

  const summary = container.querySelector(".pagination-summary");

  if (!summary) {
    return;
  }

  if (!paginationLoaded || totalRecords === 0) {
    summary.textContent = "No se encontraron tickets";
    return;
  }

  const start = getStart() + 1;

  const end = Math.min(getStart() + pageSize, totalRecords);

  summary.textContent = `Mostrando ${start}–${end} de ${totalRecords} tickets`;
};

const renderPages = () => {
  const container = getContainer();

  if (!container) {
    return;
  }

  const pagination = container.querySelector(".pagination");

  if (!pagination) {
    return;
  }

  pagination.innerHTML = "";

  if (!paginationLoaded || !pageSize) {
    return;
  }

  const totalPages = getTotalPages();

  pagination.appendChild(createNavigationItem("previous"));

  for (let page = 1; page <= totalPages; page++) {
    pagination.appendChild(createPageItem(page));
  }

  pagination.appendChild(createNavigationItem("next"));
};

const render = () => {
  renderSummary();
  renderPages();
};

const setPagination = (paginationData) => {
  if (!paginationData) {
    return;
  }

  pageSize = Number(paginationData.pageSize) || 0;

  currentPage = Number(paginationData.pageNumber) || 1;

  totalRecords = Number(paginationData.totalRecordsFiltered) || 0;

  paginationLoaded = true;

  render();
};

const reset = () => {
  currentPage = 1;

  render();
};

const getParams = () => {
  if (!paginationLoaded) {
    return null;
  }

  return {
    start: getStart(),
    length: pageSize,
  };
};

const onPageChange = (callback) => {
  onPageChangeCallback = callback;
};

const init = () => {
  currentPage = 1;
  pageSize = 0;
  totalRecords = 0;
  paginationLoaded = false;

  render();
};

export default {
  init,
  render,
  reset,
  setPagination,
  getParams,
  onPageChange,
};
