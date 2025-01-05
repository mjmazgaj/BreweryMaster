const removeFields = (obj, fields) =>
  Object.fromEntries(
    Object.entries(obj).filter(([key]) => !fields.includes(key))
  );

export { removeFields };
