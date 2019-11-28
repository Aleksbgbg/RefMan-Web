interface FormDataStub {
  value: string;

  isValid: boolean | null;

  invalidMessage: string;
}

export function generateStub(): FormDataStub {
  return {
    value: "",
    isValid: null,
    invalidMessage: ""
  };
}