/* eslint-disable no-dupe-keys */
module.exports = {
  rules: {
    'allowIndentationTabs ': 1, // disable rule
  },
  root: true,
  env: {
    node: true,
  },
  extends: 'vuetify',
  rules: {
    'no-console': process.env.NODE_ENV === 'production' ? 'error' : 'off',
    'no-debugger': process.env.NODE_ENV === 'production' ? 'error' : 'off',

  },
  parserOptions: {
    parser: '@babel/eslint-parser',
  },
}
