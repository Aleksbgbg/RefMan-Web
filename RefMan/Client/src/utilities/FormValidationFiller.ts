export function fillValidationErrors(fields: any, error: any) {
  for (const field of Object.keys(fields)) {
    fields[field].isValid = true;
  }

  const response = error.response.data;

  for (const field of Object.keys(response)) {
    fields[field].isValid = false;
    fields[field].invalidMessage = response[field][0];
  }
}