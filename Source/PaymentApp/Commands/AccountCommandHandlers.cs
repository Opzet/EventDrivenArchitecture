using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public sealed class AccountCommandHandlers
{
    private readonly IEventSourcedRepository<Account> _repository; public AccountCommandHandlers(IEventSourcedRepository<Account> repository)
    {
        _repository = repository;
    }
    public async Task HandleAsync(OpenAccount command)
    {
        var account = Account.Open(command.AccountId, command.Balance);
        await _repository.SaveAsync(account);
    }
    public async Task HandleAsync(DepositToAccount command)
    {
        var account = await _repository.GetAsync(command.AccountId) ??
        throw new EntityNotFoundException(nameof(Account), command.AccountId); account.Deposit(command.Amount);
        await _repository.SaveAsync(account);
    }
    public async Task HandleAsync(WithdrawFromAccount command)
    {
        var account = await _repository.GetAsync(command.AccountId) ??
        throw new EntityNotFoundException(nameof(Account), command.AccountId); account.Withdraw(command.Amount);
        await _repository.SaveAsync(account);
    }
}
public sealed class OpenAccount
{
    public Guid AccountId { get; }
    public decimal Balance { get; }
    public OpenAccount(Guid accountId, decimal balance)
    {
        AccountId = accountId;
        Balance = balance;
    }
}
public sealed class DepositToAccount
{
    public Guid AccountId { get; }
    public decimal Amount { get; }
    public DepositToAccount(Guid accountId, decimal amount)
    {
        AccountId = accountId;
        Amount = amount;
    }
}
public sealed class WithdrawFromAccount
{
    public Guid AccountId { get; }
    public decimal Amount { get; }
    public WithdrawFromAccount(Guid accountId, decimal amount)
    {
        AccountId = accountId;
        Amount = amount;
    }
}