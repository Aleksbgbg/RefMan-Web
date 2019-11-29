export function grabValues(object: any) {
  const values: any = { };

  for (const key of Object.keys(object)) {
    values[key] = object[key].value;
  }

  return values;
}