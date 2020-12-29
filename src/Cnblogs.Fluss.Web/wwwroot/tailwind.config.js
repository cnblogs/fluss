module.exports = {
  purge: {
    content: ["./src/blog.js"],
    layers: ["components", "utilities"],
  },
  darkMode: "media", // or 'media' or 'class'
  theme: {
    extend: {},
  },
  variants: {
    extend: {},
  },
  plugins: [],
};
