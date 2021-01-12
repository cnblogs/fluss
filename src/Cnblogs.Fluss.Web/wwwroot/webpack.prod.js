const path = require("path");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const CssMinimizerPlugin = require("css-minimizer-webpack-plugin");
const CopyWebpackPlugin = require("copy-webpack-plugin");
const { CleanWebpackPlugin } = require("clean-webpack-plugin");
module.exports = () => {
  process.env.NODE_ENV = "production";
  return {
    entry: {
      blog: "./src/index.js",
    },
    output: {
      path: path.join(__dirname, "dist"),
      filename: "[name].js",
    },
    mode: "production",
    module: {
      rules: [
        {
          test: /\.js$/,
          use: "babel-loader",
        },
        {
          test: /blog\.css$/,
          use: [
            MiniCssExtractPlugin.loader,
            "css-loader",
            {
              loader: "postcss-loader",
              options: {
                postcssOptions: {
                  plugins: [require("tailwindcss"), require("autoprefixer")],
                },
              },
            },
          ],
        },
      ],
    },
    plugins: [
      new MiniCssExtractPlugin({
        filename: "[name].min.css",
      }),
      new CopyWebpackPlugin({
        patterns: [
          { from: "./favicon.ico" }
        ]
      }),
      new CleanWebpackPlugin()
    ],
    optimization: {
      minimize: true,
      minimizer: [new CssMinimizerPlugin()],
    },
  };
};
