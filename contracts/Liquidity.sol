// SPDX-License-Identifier: GPL-3.0

pragma solidity ^0.8.11;

import "@uniswap/v2-core/contracts/interfaces/IUniswapV2Factory.sol";
import "@uniswap/v2-periphery/contracts/interfaces/IUniswapV2Router02.sol";
import "@uniswap/v2-periphery/contracts/interfaces/IERC20.sol";
import "@uniswap/v2-core/contracts/interfaces/IUniswapV2Callee.sol";

contract Liquidity {
    address internal constant UNISWAP_FACTORY_ADDRESS =
        0x5C69bEe701ef814a2B6a3EDD4B1652CB9cc5aA6f;

    address internal constant UNISWAP_ROUTER_ADDRESS =
        0x7a250d5630B4cF539739dF2C5dAcb4c659F2488D;

    IUniswapV2Router02 public uniswapRouter;
    IUniswapV2Factory public uniswapFactory;

    address private multiDaiKovan = 0x4F96Fe3b7A6Cf9725f59d353F723c1bDb64CA6Aa;

    address private constant WETH = 0xC02aaA39b223FE8D0A0e5C4F27eAD9083C756Cc2;

    constructor() {
        uniswapRouter = IUniswapV2Router02(UNISWAP_ROUTER_ADDRESS);
        uniswapFactory = IUniswapV2Factory(UNISWAP_FACTORY_ADDRESS);
    }

    event log(string message, uint256 value);

    function addLiquidity(
        address _tokenA,
        address _tokenB,
        uint256 _amountA,
        uint256 _amountB
    ) external {
        //transform the two tokens
        IERC20(_tokenA).transferFrom(msg.sender, address(this), _amountA);
        IERC20(_tokenB).transferFrom(msg.sender, address(this), _amountB);
        IERC20(_tokenA).approve(UNISWAP_ROUTER_ADDRESS, _amountA);
        IERC20(_tokenB).approve(UNISWAP_ROUTER_ADDRESS, _amountB);

        (
            uint256 amountA,
            uint256 amountB,
            uint256 liquidity
        ) = IUniswapV2Router01(UNISWAP_ROUTER_ADDRESS).addLiquidity(
                _tokenA,
                _tokenB,
                _amountA,
                _amountB,
                1,
                1,
                address(this),
                block.timestamp
            );

        emit log("Amount A", amountA);
        emit log("Amount B", amountB);
        emit log("liquidity", liquidity);
    }

    function removeLiquidity(address _tokenA, address _tokenB) external {
        //the first thing we will do is get the balance of liquidity tokens that this
        //contract holds So you need to get address of the contract that managed liquidity pool
        //tokens and tokenA and tokenB we do that by calling getPair
        //the pair contract managed all the trading of A and B and also managed mint and burn
        //of liquidity token
        address pair = IUniswapV2Factory(uniswapFactory).getPair(
            _tokenA,
            _tokenB
        );
        uint256 liquidity = IERC20(pair).balanceOf(address(this));
        //we are gonna burn all of our liquidity tokens and claim max amount
        //of tokenA and tokenB plus all trading fee so we are approving
        IERC20(pair).approve(UNISWAP_ROUTER_ADDRESS, liquidity);

        (uint256 amountA, uint256 amountB) = IUniswapV2Router01(
            UNISWAP_ROUTER_ADDRESS
        ).removeLiquidity(
                _tokenA,
                _tokenB,
                liquidity,
                1,
                1,
                address(this),
                block.timestamp
            );

        emit log("Amount A", amountA);
        emit log("Amount B", amountB);
    }
}
