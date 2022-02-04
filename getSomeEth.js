const Web3 = require('web3');
const web3 = new Web3('http://127.0.0.1:8545');
 
const myAccount = "0x6d5e2C47c58B5DF79164B0E618f74BA542E5aEd3";
const ethBorrowAccount = "0x742d35Cc6634C0532925a3b844Bc454e4438f44e";
 
web3.eth.sendTransaction({from: ethBorrowAccount, to: myAccount, value: web3.utils.toWei('100', 'ether')}, (err, hash) => {
    console.log(hash);
});