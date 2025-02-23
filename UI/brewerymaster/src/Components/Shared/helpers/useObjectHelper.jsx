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

const lowerCaseFirstLetter = (text) => {
  if (!text) return "";
  return text.charAt(0).toLowerCase() + text.slice(1);
}


export { removeFields, createPath, lowerCaseFirstLetter };

