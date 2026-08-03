//actionRenderer.js
const actionTemplates = {
  edit: () => `
    <button 
      class="btn btn-sm btn-primary dt-action-btn"
      data-action="edit">
      <i class="bi bi-pencil"></i> Editar
    </button>
  `,

  delete: () => `
    <button 
      class="btn btn-sm btn-danger dt-action-btn"
      data-action="delete">
      <i class="bi bi-trash"></i> Eliminar
    </button>
  `,

  default: (action) => `
    <button 
      class="btn btn-sm btn-secondary dt-action-btn"
      data-action="${action}">
      ${action}
    </button>
  `,
};


const renderActions = (actions) => {
  return Object.keys(actions)
    .map((action) => {
      const template = actionTemplates[action] || actionTemplates.default;

      return template(action);
    })
    .join(" ");
};

export default renderActions;
