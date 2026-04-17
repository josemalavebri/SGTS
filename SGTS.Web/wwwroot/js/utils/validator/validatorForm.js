const ValidatorUtil = (() => {
  const isRequired = (value) =>
    value !== null && value !== undefined && value.toString().trim() !== "";

  const rulesMap = {
    minLength: (v, len) => v.toString().length >= len,
    maxLength: (v, len) => v.toString().length <= len,
    email: (v) => /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(v),
    numeric: (v) => /^\d+$/.test(v),
    pattern: (v, regex) => regex.test(v),
  };

  const validateField = (value, fieldRules) => {
    const errors = [];
    const valStr = value?.toString() || "";

    if (fieldRules.required && !isRequired(value)) {
      errors.push({ code: "REQUIRED" });
      return errors;
    }

    if (!fieldRules.required && !isRequired(value)) {
      return errors;
    }

    if (
      fieldRules.minLength &&
      !rulesMap.minLength(valStr, fieldRules.minLength)
    ) {
      errors.push({ code: "MIN_LENGTH", meta: { min: fieldRules.minLength } });
    }
    if (
      fieldRules.maxLength &&
      !rulesMap.maxLength(valStr, fieldRules.maxLength)
    ) {
      errors.push({ code: "MAX_LENGTH", meta: { max: fieldRules.maxLength } });
    }
    if (fieldRules.email && !rulesMap.email(valStr)) {
      errors.push({ code: "EMAIL" });
    }
    if (fieldRules.numeric && !rulesMap.numeric(valStr)) {
      errors.push({ code: "NUMERIC" });
    }
    if (fieldRules.pattern && !rulesMap.pattern(valStr, fieldRules.pattern)) {
      errors.push({ code: "PATTERN" });
    }

    return errors;
  };

  return { validateField };
})();

export default ValidatorUtil;
