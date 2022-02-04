const IERC20 = artifacts.require("IERC20");
require('dotenv').config();
const testLiquidity = artifacts.require("Liquidity");
const BN = require("bn.js");
//const { sendEther, pow } = require("./util");


contract('testing the liquidity', (accounts) => {

    const WBTC = "0x2260fac5e5542a773aa44fbcfedf7c193bc2c599";
    const DAI = "0x6b175474e89094c44da98b954eedeac495271d0f";
    const DAI_WHALE = "0x3f5CE5FBFe3E9af3971dD833D26bA9b5C936f0bE";
    const WETH = "0xC02aaA39b223FE8D0A0e5C4F27eAD9083C756Cc2";

    const caller = accounts[0];
    const TOKEN_A = WETH;
    const TOKEN_A_WHALE = process.env.WETH_WHALE;
    const TOKEN_B = DAI;
    const TOKEN_B_WHALE = DAI_WHALE;
    const TOKEN_A_AMOUNT = pow(10, 18);
    const TOKEN_B_AMOUNT = pow(10, 18);

    let contract;
    let tokenA;
    let tokenB;

    beforeEach(async () => {

        tokenA = await IERC20.at(TOKEN_A);
        tokenB = await IERC20.at(TOKEN_B);
        contract = await testLiquidity.new();

        //fee for a successful tx
        await sendEther(web3, accounts[0], TOKEN_A_WHALE, 1);
        await sendEther(web3, accounts[0], TOKEN_B_WHALE, 1);

        await tokenA.transfer(caller, TOKEN_A_AMOUNT, { from: TOKEN_A_WHALE });
        await tokenB.transfer(caller, TOKEN_B_AMOUNT, { from: TOKEN_B_WHALE });

        await tokenA.approve(contract.address, TOKEN_A_AMOUNT, { from: caller });
        await tokenB.approve(contract.address, TOKEN_B_AMOUNT, { from: caller });

    });

    it("add/remove liquidity", async () => {

        let tx = await contract.addLiquidity(
          tokenA.address,
          tokenB.address,
          TOKEN_A_AMOUNT,
          TOKEN_B_AMOUNT,
          {
            from: caller,
          }
        );
          //from the tx object retiriving the logs array and consoling
        console.log("adding liquidity");
        for (const log of tx.logs) {
          console.log(`${log.args.message} ${log.args.val}`);
        }
    
        tx = await contract.removeLiquidity(
            tokenA.address, 
            tokenB.address, {from: caller,});

            //from the tx object retiriving the logs array and consoling
        console.log("removing liquidity");
        for (const log of tx.logs) {
          console.log(`${log.args.message} ${log.args.val}`);
        }
    });

})

function sendEther(web3, from, to, amount) {
    return web3.eth.sendTransaction({
      from,
      to,
      value: web3.utils.toWei(amount.toString(), "ether"),
    });
}

function pow(x, y) {
    x = cast(x);
    y = cast(y);
    return x.pow(y);
}

function cast(x) {
    if (x instanceof BN) {
      return x;
    }
    return new BN(x);
}