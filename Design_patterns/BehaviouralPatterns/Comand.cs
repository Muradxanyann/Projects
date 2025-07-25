using System.Data.Common;
using System.IO.Pipelines;
using System.Security.Claims;

namespace BehaviouralTask2
{
    class BankAccount
    {
        public string Name { get; private set; }
        public int Balance { get; private set; }
        public BankAccount(string name, int balance)
        {
            Name = name;
            Balance = balance;
        }
        public void Deposit(int amount)
        {
            Console.WriteLine($"Deposited {amount} to John. New balance: {Balance + amount}");
            Balance += amount;
        }
        public bool Withdraw(int amount)
        {
            if (Balance < amount)
            {
                Console.WriteLine($"Withdrawal failed for {Name}. Insufficient funds.");
                return false;
            }
            Balance -= amount;
            return true;
        }

        public void Transfer(BankAccount account, int amount)
        {
            if (this.Balance < amount)
            {
                Console.WriteLine($"Transfer failed for {Name}. Insufficient funds.");
                return;
            }
            this.Balance -= amount;
            account.Balance += amount;
        }
    }

    interface ITransactionCommand
    {
        void Execute();
        void Undo();
    }

    interface ICommandResult
    {
        bool Succeeded { get; }
    }

    class DepositCommand : ITransactionCommand
    {
        private readonly BankAccount _account;
        private readonly int _amount;

        public DepositCommand(BankAccount account, int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Invalid argument");
            _account = account;
            _amount = amount;
        }
        public void Execute()
        {
            _account.Deposit(_amount);
        }

        public void Undo()
        {
            Console.WriteLine($"Undo: Deposit operation canceled, balance is {_account.Balance - _amount} now");
            _account.Withdraw(_amount);
        }
    }
    class WithdrawCommand : ITransactionCommand, ICommandResult
    {
        private bool _succeeded;
        private readonly BankAccount _account;
        private readonly int _amount;

        public bool Succeeded => _succeeded;

        public WithdrawCommand(BankAccount account, int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Invalid argument");
            _account = account;
            _amount = amount;
        }
        public void Execute()
        {
            _succeeded = _account.Withdraw(_amount);
        }
        public void Undo()
        {
            if (_succeeded)
            {
                Console.WriteLine($"Reversed withdrawal of {_amount}. Balance is now: {_account.Balance + _amount}");
                _account.Deposit(_amount);
            }
        }
    }

    class TransferCommand : ITransactionCommand
    {
        private readonly BankAccount _account;
        private readonly BankAccount _account2;
        private readonly int _amount;
        public TransferCommand(BankAccount account, BankAccount account2, int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Invalid argument");
            if (account == null || account2 == null)
                throw new ArgumentException("Invalid account");
            _account = account;
            _account2 = account2;
            _amount = amount;
        }
        public void Execute()
        {
            _account.Transfer(_account2, _amount);
        }

        public void Undo()
        {
            Console.WriteLine($"Undo transfer of {_amount} from {_account.Name} to {_account2.Name}");
            _account2.Withdraw(_amount);
            _account.Deposit(_amount);
        }
    }

    class TransactionInvoker
    {
        private readonly Stack<ITransactionCommand> stack = new();
        public void ExecuteCommand(ITransactionCommand cmd)
        {
            cmd.Execute();
            if (cmd is ICommandResult res && res.Succeeded)
                stack.Push(cmd);
        }
        public void UndoLast()
        {
            if (stack.Count > 0)
            {
                var cmd = stack.Pop();
                cmd.Undo();
            }
        }
    }


}