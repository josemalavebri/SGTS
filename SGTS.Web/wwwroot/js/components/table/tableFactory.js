import dataTableAdapter from "./adapters/dataTableAdapter.js";
import buildColumns from "./builders/buildColumns.js";
import bindTableEvents from "./ui/events/bindTableEvents.js";

const tableFactory = {
  createTable: ({ tableConfig, fetchData, actions = {} }) => {
    const { tableId, columns } = tableConfig;
    if (!tableId) throw new Error("tableId es requerido");
    if (!fetchData) throw new Error("fetchData es requerido");

    const uiColumns = buildColumns({ columns, actions });

    const adapter = dataTableAdapter({
      tableId,
      columns: uiColumns,
      fetchData,
    });

    
    let initialized = false;

    const init = () => {
      if (initialized) return;

      adapter.init();

      bindTableEvents({
        tableId,
        getRowData: adapter.getRowData,
        actions,
      });

      initialized = true;
    };

    const reload = () => adapter.reload();

    const destroy = () => {
      adapter.destroy();
      initialized = false;
    };

    init();

    return {
      reload,
      destroy,
    };
  },
};

export default tableFactory;
