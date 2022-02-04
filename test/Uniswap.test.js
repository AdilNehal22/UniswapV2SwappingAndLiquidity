const IERC20 = artifacts.require("IERC20");
const TestUniswap = artifacts.require("UniswapFunctions");
require('dotenv').config()
const BN = require('bn.js');


contract('Uniswap Functions', (accounts)=>{

    const to = '0xdCD0A442b6d23155804E1653858Edc5De8e74a7b';
    const WBTC = "0x2260fac5e5542a773aa44fbcfedf7c193bc2c599";
    const DAI = "0x6b175474e89094c44da98b954eedeac495271d0f";
    const DAI_WHALE = "0x3f5CE5FBFe3E9af3971dD833D26bA9b5C936f0bE";
//100000000
    const WHALE = process.env.WBTC_WHALE;
    const AMOUNT_IN = 1000000000;
    const AMOUNT_OUT_MIN = 2;
    const TOKEN_IN = WBTC;
    const TOKEN_OUT = DAI;
    const TO = accounts[0];

    let testUniswap;
    let tokenIn;
    let tokenOut;

    it('should swap Tokens for Tokens', async()=>{

        tokenIn = await IERC20.at(TOKEN_IN);
        tokenOut = await IERC20.at(TOKEN_OUT);
        testUniswap = await TestUniswap.new();

        await tokenIn.approve(testUniswap.address, AMOUNT_IN, { from: WHALE });

        await testUniswap.swapTokensForTokensTest(

            tokenIn.address,
            tokenOut.address,
            AMOUNT_IN,
            AMOUNT_OUT_MIN,
            TO,

            {
                from: WHALE
            }

        );

        console.log(`out ${await tokenOut.balanceOf(TO)}`);

    });

    it('should swap Tokens for Tokens', async()=>{

        tokenIn = await IERC20.at(TOKEN_IN);
        tokenOut = await IERC20.at(TOKEN_OUT);
        testUniswap = await TestUniswap.new();

        await tokenIn.approve(testUniswap.address, AMOUNT_IN, { from: WHALE });

        await testUniswap.swapTokensForExactTokensTest(

            tokenIn.address,
            tokenOut.address,
            AMOUNT_IN,
            AMOUNT_OUT_MIN,
            TO,

            {
                from: WHALE
            }

        );

        console.log(`out ${await tokenOut.balanceOf(TO)}`);

    });

    it('should swap exact eth for tokens', async()=>{

        tokenOut = await IERC20.at(TOKEN_OUT);
        testUniswap = await TestUniswap.new();

        await testUniswap.swapExactEthForTokensTest(

            AMOUNT_OUT_MIN,
            tokenOut.address,
            TO,

            {
                from: WHALE,
                value: "10"
            }

        );

        console.log(`out ${await tokenOut.balanceOf(TO)}`);

    });
    ////////////////////////////////////////////////////

    it('should swap tokens for exact eth', async()=>{

        

        tokenIn = await IERC20.at(TOKEN_IN);
        testUniswap = await TestUniswap.new();
        await tokenIn.approve(testUniswap.address, AMOUNT_IN, { from: WHALE });

        await testUniswap.swapTokensForExactEthTest(

            AMOUNT_OUT_MIN,
            tokenIn.address,
            AMOUNT_IN,
            to,

            {
                from: WHALE
            }

        );

        console.log(`sent ${await web3.eth.getBalance(to)}`);

    });

    it('should swap exact tokens for eth', async()=>{

        tokenIn = await IERC20.at(TOKEN_IN);
        testUniswap = await TestUniswap.new();
        await tokenIn.approve(testUniswap.address, AMOUNT_IN, { from: WHALE });

        await testUniswap.swapExactTokensForETHTest(

            AMOUNT_IN,
            tokenIn.address,
            AMOUNT_OUT_MIN,
            to,
            {
                from: WHALE
            }

        );

        console.log(`amount to receive ${await web3.eth.getBalance(to)}`);

    });

    it('should swap eth for exact token', async()=>{

        tokenOut = await IERC20.at(WBTC);
        testUniswap = await TestUniswap.new();

        await testUniswap.swapEthForExactTokensTest(

            AMOUNT_OUT_MIN,
            tokenOut.address,
            TO,

            {
                from: WHALE,
                value: AMOUNT_IN
            }

        );

        console.log(`out ${await tokenOut.balanceOf(TO)}`);

    })

    
});