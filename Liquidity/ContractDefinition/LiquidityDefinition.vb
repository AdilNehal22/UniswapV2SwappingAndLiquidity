Imports System
Imports System.Threading.Tasks
Imports System.Collections.Generic
Imports System.Numerics
Imports Nethereum.Hex.HexTypes
Imports Nethereum.ABI.FunctionEncoding.Attributes
Imports Nethereum.Web3
Imports Nethereum.RPC.Eth.DTOs
Imports Nethereum.Contracts.CQS
Imports Nethereum.Contracts
Imports System.Threading
Namespace UniswapV2.Contracts.Liquidity.ContractDefinition

    
    
    Public Partial Class LiquidityDeployment
     Inherits LiquidityDeploymentBase
    
        Public Sub New()
            MyBase.New(DEFAULT_BYTECODE)
        End Sub
        
        Public Sub New(ByVal byteCode As String)
            MyBase.New(byteCode)
        End Sub
    
    End Class

    Public Class LiquidityDeploymentBase 
            Inherits ContractDeploymentMessage
        
        Public Shared DEFAULT_BYTECODE As String = "6080604052600280546001600160a01b031916734f96fe3b7a6cf9725f59d353f723c1bdb64ca6aa17905534801561003657600080fd5b50600080546001600160a01b0319908116737a250d5630b4cf539739df2c5dacb4c659f2488d1790915560018054909116735c69bee701ef814a2b6a3edd4b1652cb9cc5aa6f1790556105478061008e6000396000f3fe608060405234801561001057600080fd5b50600436106100415760003560e01c8063735de9f7146100465780638bdb2afa14610075578063cf6c62ea14610088575b600080fd5b600054610059906001600160a01b031681565b6040516001600160a01b03909116815260200160405180910390f35b600154610059906001600160a01b031681565b61009b610096366004610478565b61009d565b005b6040516323b872dd60e01b8152336004820152306024820152604481018390526001600160a01b038516906323b872dd906064016020604051808303816000875af11580156100f0573d6000803e3d6000fd5b505050506040513d601f19601f8201168201806040525081019061011491906104ba565b506040516323b872dd60e01b8152336004820152306024820152604481018290526001600160a01b038416906323b872dd906064016020604051808303816000875af1158015610168573d6000803e3d6000fd5b505050506040513d601f19601f8201168201806040525081019061018c91906104ba565b5060405163095ea7b360e01b8152737a250d5630b4cf539739df2c5dacb4c659f2488d6004820152602481018390526001600160a01b0385169063095ea7b3906044016020604051808303816000875af11580156101ee573d6000803e3d6000fd5b505050506040513d601f19601f8201168201806040525081019061021291906104ba565b5060405163095ea7b360e01b8152737a250d5630b4cf539739df2c5dacb4c659f2488d6004820152602481018290526001600160a01b0384169063095ea7b3906044016020604051808303816000875af1158015610274573d6000803e3d6000fd5b505050506040513d601f19601f8201168201806040525081019061029891906104ba565b5060405162e8e33760e81b81526001600160a01b03808616600483015284166024820152604481018390526064810182905260016084820181905260a48201523060c48201524260e482015260009081908190737a250d5630b4cf539739df2c5dacb4c659f2488d9063e8e3370090610104016060604051808303816000875af115801561032a573d6000803e3d6000fd5b505050506040513d601f19601f8201168201806040525081019061034e91906104e3565b9250925092507fb60e72ccf6d57ab53eb84d7e94a9545806ed7f93c4d5673f11a64f03471e584e836040516103a89190604080825260089082015267416d6f756e74204160c01b6060820152602081019190915260800190565b60405180910390a1604080518181526008818301526720b6b7bab73a102160c11b60608201526020810184905290517fb60e72ccf6d57ab53eb84d7e94a9545806ed7f93c4d5673f11a64f03471e584e9181900360800190a160408051818152600981830152686c697175696469747960b81b60608201526020810183905290517fb60e72ccf6d57ab53eb84d7e94a9545806ed7f93c4d5673f11a64f03471e584e9181900360800190a150505050505050565b80356001600160a01b038116811461047357600080fd5b919050565b6000806000806080858703121561048e57600080fd5b6104978561045c565b93506104a56020860161045c565b93969395505050506040820135916060013590565b6000602082840312156104cc57600080fd5b815180151581146104dc57600080fd5b9392505050565b6000806000606084860312156104f857600080fd5b835192506020840151915060408401519050925092509256fea26469706673582212200ca7a908fa933b68d9d031be104dcc4814db18705d673bbd1e8c24e4d162e84864736f6c634300080b0033"
        
        Public Sub New()
            MyBase.New(DEFAULT_BYTECODE)
        End Sub
        
        Public Sub New(ByVal byteCode As String)
            MyBase.New(byteCode)
        End Sub
        

    
    End Class    
    
    Public Partial Class AddLiquidityFunction
        Inherits AddLiquidityFunctionBase
    End Class

        <[Function]("addLiquidity")>
    Public Class AddLiquidityFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("address", "_tokenA", 1)>
        Public Overridable Property [TokenA] As String
        <[Parameter]("address", "_tokenB", 2)>
        Public Overridable Property [TokenB] As String
        <[Parameter]("uint256", "_amountA", 3)>
        Public Overridable Property [AmountA] As BigInteger
        <[Parameter]("uint256", "_amountB", 4)>
        Public Overridable Property [AmountB] As BigInteger
    
    End Class
    
    
    Public Partial Class UniswapFactoryFunction
        Inherits UniswapFactoryFunctionBase
    End Class

        <[Function]("uniswapFactory", "address")>
    Public Class UniswapFactoryFunctionBase
        Inherits FunctionMessage
    

    
    End Class
    
    
    Public Partial Class UniswapRouterFunction
        Inherits UniswapRouterFunctionBase
    End Class

        <[Function]("uniswapRouter", "address")>
    Public Class UniswapRouterFunctionBase
        Inherits FunctionMessage
    

    
    End Class
    
    
    Public Partial Class LogEventDTO
        Inherits LogEventDTOBase
    End Class

    <[Event]("log")>
    Public Class LogEventDTOBase
        Implements IEventDTO
        
        <[Parameter]("string", "message", 1, false)>
        Public Overridable Property [Message] As String
        <[Parameter]("uint256", "value", 2, false)>
        Public Overridable Property [Value] As BigInteger
    
    End Class    
    
    
    
    Public Partial Class UniswapFactoryOutputDTO
        Inherits UniswapFactoryOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class UniswapFactoryOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("address", "", 1)>
        Public Overridable Property [ReturnValue1] As String
    
    End Class    
    
    Public Partial Class UniswapRouterOutputDTO
        Inherits UniswapRouterOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class UniswapRouterOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("address", "", 1)>
        Public Overridable Property [ReturnValue1] As String
    
    End Class
End Namespace
