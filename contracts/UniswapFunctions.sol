// SPDX-License-Identifier: GPL-3.0

pragma solidity ^0.8.11;

import "@uniswap/v2-core/contracts/interfaces/IUniswapV2Factory.sol";
import "@uniswap/v2-periphery/contracts/interfaces/IUniswapV2Router02.sol";
import "@uniswap/v2-periphery/contracts/interfaces/IERC20.sol";
import "@uniswap/v2-core/contracts/interfaces/IUniswapV2Callee.sol";

contract UniswapFunctions {
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

    function swapTokensForTokensTest(
        address _tokenIn,
        address _tokenOut,
        uint256 _amountIn,
        uint256 _amountOutMin,
        address _to
    ) external {
        //transfer the tokenIn from msg.sender into this contract for the amount amountIn
        //after this function is called this contract will have the amountIn amount of _tokenIn
        IERC20(_tokenIn).transferFrom(msg.sender, address(this), _amountIn);
        //next this contract needs to evaluate uniswapV2Router to spend that token we do
        //that by calling approve on the tokenIn
        IERC20(_tokenIn).approve(UNISWAP_ROUTER_ADDRESS, _amountIn);

        address[] memory path;
        path = new address[](3);
        path[0] = _tokenIn;
        path[1] = WETH;
        path[2] = _tokenOut; //wbtc

        IUniswapV2Router01(UNISWAP_ROUTER_ADDRESS).swapExactTokensForTokens(
            _amountIn,
            _amountOutMin,
            path,
            _to,
            block.timestamp
        );
    }

    function swapTokensForExactTokensTest(
        address _tokenIn,
        address _tokenOut,
        uint256 _amountOut,
        uint256 _amountInMax,
        address _to
    ) external {
        IERC20(_tokenIn).transferFrom(msg.sender, address(this), _amountInMax);
        IERC20(_tokenIn).approve(UNISWAP_ROUTER_ADDRESS, _amountInMax);

        address[] memory path;
        path = new address[](3);
        path[0] = _tokenIn;
        path[1] = WETH;
        path[2] = _tokenOut; //wbtc

        IUniswapV2Router01(UNISWAP_ROUTER_ADDRESS).swapTokensForExactTokens(
            _amountOut,
            _amountInMax,
            path,
            _to,
            block.timestamp
        );
    }

    /////////////////////Tokens to Tokens Ends/////////////////////////////////////////

    function swapExactEthForTokensTest(
        uint256 _amountOutMin,
        address _tokenOut,
        address _to
    ) external payable {
        address[] memory path;
        path = new address[](2);
        path[0] = WETH;
        path[1] = _tokenOut;

        IUniswapV2Router01(UNISWAP_ROUTER_ADDRESS).swapExactETHForTokens{
            value: msg.value
        }(_amountOutMin, path, _to, block.timestamp);

        (bool success, ) = msg.sender.call{value: address(this).balance}("");
        require(success, "refund failed");
    }

    function swapTokensForExactEthTest(
        uint256 _amountOut,
        address _tokenIn,
        uint256 _amountInMax,
        address _to
    ) external {
        
        
        IERC20(_tokenIn).transferFrom(msg.sender, address(this), _amountInMax);
        //IERC20(_tokenIn).approve(address(this), _amountInMax);
        IERC20(_tokenIn).approve(UNISWAP_ROUTER_ADDRESS, _amountInMax);
        
        

        address[] memory path;
        path = new address[](2);
        path[0] = _tokenIn;
        path[1] = WETH;

        IUniswapV2Router01(UNISWAP_ROUTER_ADDRESS).swapTokensForExactETH(
            _amountOut,
            _amountInMax,
            path,
            _to,
            block.timestamp
        );
    }


    function swapExactTokensForETHTest(

        uint _amountIn,
        address _tokenIn,
        uint _amountOutMin,
        address _to

    ) external {

        
        IERC20(_tokenIn).transferFrom(msg.sender, address(this), _amountIn);
        //IERC20(_tokenIn).approve(address(this), _amountIn);
        IERC20(_tokenIn).approve(UNISWAP_ROUTER_ADDRESS, _amountIn);
        
        

        address[] memory path;
        path = new address[](2);
        path[0] = _tokenIn;
        path[1] = WETH;

        IUniswapV2Router01(UNISWAP_ROUTER_ADDRESS).swapExactTokensForETH(_amountIn, _amountOutMin, path, _to, block.timestamp);

    }
//swapExactEthForTokens
    function swapEthForExactTokensTest(
        uint256 _amountOut,
        address _tokenOut,
        address _to
    ) external payable {
        address[] memory path;
        path = new address[](2);
        path[0] = WETH;
        path[1] = _tokenOut;

        IUniswapV2Router01(UNISWAP_ROUTER_ADDRESS).swapETHForExactTokens{value: msg.value}
        (_amountOut, path, _to, block.timestamp);

        (bool success, ) = msg.sender.call{value: address(this).balance}("");
        require(success, "refund failed");
    }

}
