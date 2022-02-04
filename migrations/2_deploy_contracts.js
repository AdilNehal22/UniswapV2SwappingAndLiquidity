//const ConvertLib = artifacts.require("ConvertLib");
const UniswapFunctions = artifacts.require("UniswapFunctions");

module.exports = function(deployer) {
  deployer.deploy(UniswapFunctions);
};
