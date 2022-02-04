# UniswapV2SwappingAndLiquidity
With the help of https://docs.uniswap.org/protocol/V2/reference/smart-contracts/router-02 docs, I've implemented the the six swapping functions and two adding
and removing liquidity functions. 

Also I've tested them. 

I request you if you find any mistake or issue please don't forget to email me at adilnehal80@gmail.com

plus after cloning the repo, you would have to forking your mainnet for this... just type the....

ganache-cli -f https://mainnet.infura.io/v3/my infura project id -u 0x742d35Cc6634C0532925a3b844Bc454e4438f44e on terminal.
and then run node getSomeEth.js, don't fotget to switch to your localhost network on metamask before doing all this. 

After running the forking cammond stop it.. and then run...

source .env //for loading the .env variables(in ubuntu)

 npx ganache-cli \
 --fork https://mainnet.infura.io/v3/$WEB3_INFURA_PROJECT_ID \
 --unlock $WETH_WHALE \
 --unlock $DAI_WHALE \
 --unlock $USDC_WHALE \
 --unlock $USDT_WHALE \
 --unlock $WBTC_WHALE \
 --networkId 999
 
 and in next terminal run 
 npx truffle test --network mainnet_fork test/FILE_NAME
 
 CORRECT ME WHEN YOU FIND THE ERROR, MISTAKE, OR BUG.
