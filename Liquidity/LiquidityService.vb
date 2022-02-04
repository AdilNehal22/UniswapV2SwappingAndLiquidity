Imports System
Imports System.Threading.Tasks
Imports System.Collections.Generic
Imports System.Numerics
Imports Nethereum.Hex.HexTypes
Imports Nethereum.ABI.FunctionEncoding.Attributes
Imports Nethereum.Web3
Imports Nethereum.RPC.Eth.DTOs
Imports Nethereum.Contracts.CQS
Imports Nethereum.Contracts.ContractHandlers
Imports Nethereum.Contracts
Imports System.Threading
Imports UniswapV2.Contracts.Liquidity.ContractDefinition
Namespace UniswapV2.Contracts.Liquidity


    Public Partial Class LiquidityService
    
    
        Public Shared Function DeployContractAndWaitForReceiptAsync(ByVal web3 As Nethereum.Web3.Web3, ByVal liquidityDeployment As LiquidityDeployment, ByVal Optional cancellationTokenSource As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return web3.Eth.GetContractDeploymentHandler(Of LiquidityDeployment)().SendRequestAndWaitForReceiptAsync(liquidityDeployment, cancellationTokenSource)
        
        End Function
         Public Shared Function DeployContractAsync(ByVal web3 As Nethereum.Web3.Web3, ByVal liquidityDeployment As LiquidityDeployment) As Task(Of String)
        
            Return web3.Eth.GetContractDeploymentHandler(Of LiquidityDeployment)().SendRequestAsync(liquidityDeployment)
        
        End Function
        Public Shared Async Function DeployContractAndGetServiceAsync(ByVal web3 As Nethereum.Web3.Web3, ByVal liquidityDeployment As LiquidityDeployment, ByVal Optional cancellationTokenSource As CancellationTokenSource = Nothing) As Task(Of LiquidityService)
        
            Dim receipt = Await DeployContractAndWaitForReceiptAsync(web3, liquidityDeployment, cancellationTokenSource)
            Return New LiquidityService(web3, receipt.ContractAddress)
        
        End Function
    
        Protected Property Web3 As Nethereum.Web3.Web3
        
        Public Property ContractHandler As ContractHandler
        
        Public Sub New(ByVal web3 As Nethereum.Web3.Web3, ByVal contractAddress As String)
            Web3 = web3
            ContractHandler = web3.Eth.GetContractHandler(contractAddress)
        End Sub
    
        Public Function AddLiquidityRequestAsync(ByVal addLiquidityFunction As AddLiquidityFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of AddLiquidityFunction)(addLiquidityFunction)
        
        End Function

        Public Function AddLiquidityRequestAndWaitForReceiptAsync(ByVal addLiquidityFunction As AddLiquidityFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of AddLiquidityFunction)(addLiquidityFunction, cancellationToken)
        
        End Function

        
        Public Function AddLiquidityRequestAsync(ByVal [tokenA] As String, ByVal [tokenB] As String, ByVal [amountA] As BigInteger, ByVal [amountB] As BigInteger) As Task(Of String)
        
            Dim addLiquidityFunction = New AddLiquidityFunction()
                addLiquidityFunction.TokenA = [tokenA]
                addLiquidityFunction.TokenB = [tokenB]
                addLiquidityFunction.AmountA = [amountA]
                addLiquidityFunction.AmountB = [amountB]
            
            Return ContractHandler.SendRequestAsync(Of AddLiquidityFunction)(addLiquidityFunction)
        
        End Function

        
        Public Function AddLiquidityRequestAndWaitForReceiptAsync(ByVal [tokenA] As String, ByVal [tokenB] As String, ByVal [amountA] As BigInteger, ByVal [amountB] As BigInteger, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim addLiquidityFunction = New AddLiquidityFunction()
                addLiquidityFunction.TokenA = [tokenA]
                addLiquidityFunction.TokenB = [tokenB]
                addLiquidityFunction.AmountA = [amountA]
                addLiquidityFunction.AmountB = [amountB]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of AddLiquidityFunction)(addLiquidityFunction, cancellationToken)
        
        End Function
        Public Function UniswapFactoryQueryAsync(ByVal uniswapFactoryFunction As UniswapFactoryFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Return ContractHandler.QueryAsync(Of UniswapFactoryFunction, String)(uniswapFactoryFunction, blockParameter)
        
        End Function

        
        Public Function UniswapFactoryQueryAsync(ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            return ContractHandler.QueryAsync(Of UniswapFactoryFunction, String)(Nothing, blockParameter)
        
        End Function



        Public Function UniswapRouterQueryAsync(ByVal uniswapRouterFunction As UniswapRouterFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Return ContractHandler.QueryAsync(Of UniswapRouterFunction, String)(uniswapRouterFunction, blockParameter)
        
        End Function

        
        Public Function UniswapRouterQueryAsync(ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            return ContractHandler.QueryAsync(Of UniswapRouterFunction, String)(Nothing, blockParameter)
        
        End Function



    
    End Class

End Namespace
