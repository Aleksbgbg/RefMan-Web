module.exports = {
  root: true,
  env: {
    node: true
  },
  "extends": [
    "plugin:vue/essential",
    "@vue/standard",
    "@vue/typescript"
  ],
  rules: {
    "no-console": process.env.NODE_ENV === "production" ? "error" : "off",
    "no-debugger": process.env.NODE_ENV === "production" ? "error" : "off",
    "eol-last": ["error", "never"],
    quotes: ["error", "double", { "avoidEscape": true }],
    semi: ["error", "always"],
    "space-before-function-paren": ["error", "never"],
    "no-extend-native": "off"
  },
  parserOptions: {
    parser: "@typescript-eslint/parser"
  }
};