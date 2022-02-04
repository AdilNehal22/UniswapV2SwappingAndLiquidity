const HDWalletProvider = require('@truffle/hdwallet-provider');
const mnemonic = '2559dc4667948dc3da2c84c96a22c5bd0364c04b2f2e796e3734d1dc1d61e711';
const infuraURL = 'https://rinkeby.infura.io/v3/daf2ac3c93d5408f8ae10fe67c9e9bca';

module.exports = {

  networks: {
    
    mainnet_fork: {
      host: "127.0.0.1",
      port: 8545,
      network_id: "999"
    }
  
},
  compilers: {
    solc: {
      version: "^0.8.11"
    }
  }
  
}


// networks: {
//   mainnet_fork: {
//     host: "127.0.0.1",
//     port: 8545,
//     network_id: "999"
//   },
//  },