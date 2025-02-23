const removeFields = (obj, fields) =>
  Object.fromEntries(
    Object.entries(obj).filter(([key]) => !fields.includes(key))
  );

const createPath = (basePath, query) => {
  let path = basePath;

  if (query) path += "?";

  Object.entries(query).forEach(([key, value]) => {
    if(value && value != 0)
      path += `${key}=${value}&`;
  });

  return path;
};

export { removeFields, createPath };
