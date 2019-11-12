module.exports = {
  configureWebpack: {
    devServer: {
      sockHost: "debug.iamaleks.dev",
      sockPort: 443,
      disableHostCheck: true
    }
  }
};