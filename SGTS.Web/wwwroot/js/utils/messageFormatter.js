const formatMessage = (template, params = {}) => {
  if (!template) return "";

  return template.replace(/\{(\w+)\}/g, (_, key) => {
    return params[key] !== undefined ? params[key] : `{${key}}`;
  });
};

export { formatMessage };
