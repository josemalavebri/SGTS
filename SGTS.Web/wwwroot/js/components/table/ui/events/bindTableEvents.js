// table/ui/events/bindTableEvents.js
const bindTableEvents = ({ tableId, getRowData, actions }) => {
  const table = document.getElementById(tableId);
  if (!table) return;

  table.addEventListener("click", (e) => {
    const btn = e.target.closest(".dt-action-btn");
    if (!btn) return;

    const action = btn.dataset.action;
    const rowData = getRowData(btn.closest("tr"));
    console.log("----- rowData", rowData);
    actions[action]?.(rowData);
  });
};

export default bindTableEvents;
