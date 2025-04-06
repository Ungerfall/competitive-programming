#!/usr/bin/env dotnet-script

#define DEBUG
#r "nuget: Dumpify, 0.6.6"
#nullable enable

using System.Text.RegularExpressions;
using Dumpify;

record class Transaction(string From, string To, decimal Amount);
record class Balance(decimal Part1Amount, decimal Part2Amount, decimal Part3Amount, Debt Debt);
record class DebtRecord(decimal RepayAmount, string Owner);
class Debt
{
    private readonly LinkedList<DebtRecord> queue = [];
    private readonly Dictionary<string, Balance> balances;

    public Debt(Dictionary<string, Balance> balances)
    {
        this.balances = balances;
    }

    public decimal TotalDebt => queue.Sum(x => x.RepayAmount);

    public void Add(decimal amount, string owner)
    {
        Debug.Assert(amount > 0);
        queue.AddFirst(new DebtRecord(amount, owner));
    }

    public decimal Repay(decimal amount)
    {
        while (amount > 0 && queue.Count > 0)
        {
            (decimal repayAmount, string owner) = Dequeue();
            decimal repayThisCycle = Math.Min(amount, repayAmount);
            amount -= repayThisCycle;
            repayAmount -= repayThisCycle;
            decimal amountAfterRepayment = balances[owner].Debt.Repay(repayThisCycle);
            Balance ownerBalance = balances[owner];
            balances[owner] = ownerBalance with { Part3Amount = ownerBalance.Part3Amount + amountAfterRepayment };

            if (repayAmount > 0)
            {
                queue.AddLast(new DebtRecord(repayAmount, owner));
            }
        }

        return amount;

        DebtRecord Dequeue()
        {
            DebtRecord debt = queue.Last();
            queue.RemoveLast();
            return debt;
        }
    }

    public override string ToString()
    {
        return string.Join(";", queue.Select(x => x.ToString()));
    }
}

Dictionary<string, Balance> balances = [];
string? line = null;
decimal totalNetWorth = 0m;
while ((line = Console.ReadLine()) is not null)
{
    string[] parts = line.Split("HAS");
    if (parts.Length != 2)
    {
        break;
    }

    string name = parts[0].Trim();
    decimal amount = decimal.Parse(parts[1].Trim());
    balances[name] = new(amount, amount, amount, new Debt(balances)); ;
    totalNetWorth += amount;
}

List<Transaction> transactions = [];
Regex transactionPattern = new(@"^FROM (.+) TO (.+) AMT (\d+)$");
while ((line = Console.ReadLine()) is not null)
{
    Match m = transactionPattern.Match(line);
    string from = m.Groups[1].Value;
    string to = m.Groups[2].Value;
    decimal amount = decimal.Parse(m.Groups[3].Value);
    transactions.Add(new(from, to, amount));
}

foreach ((string from, string to, decimal amount) in transactions)
{
    if (!balances.TryGetValue(from, out Balance? balanceFrom))
    {
        continue;
    }

    if (!balances.TryGetValue(to, out Balance? balanceTo))
    {
        continue;
    }

    decimal available = Math.Min(balanceFrom.Part3Amount, amount);
    decimal debt = -1 * (balanceFrom.Part3Amount - amount);
    decimal limited = Math.Min(balanceFrom.Part2Amount, amount);
    balances[from] = balanceFrom with
    {
        Part1Amount = balanceFrom.Part1Amount - amount,
        Part2Amount = balanceFrom.Part2Amount - limited,
        Part3Amount = balanceFrom.Part3Amount - available,
    };
    if (debt > 0)
    {
        balanceFrom.Debt.Add(debt, to);
    }

    decimal amountAfterRepayment = balanceTo.Debt.Repay(available);
    balances[to] = balances[to] with
    {
        Part1Amount = balances[to].Part1Amount + amount,
        Part2Amount = balances[to].Part2Amount + limited,
        Part3Amount = balances[to].Part3Amount + amountAfterRepayment,
    };
    balances.Select(x => $"{x.Key}:{x.Value.Part3Amount}:{x.Value.Debt.ToString()}").Dump();
    decimal part3Total = balances.Sum(x => x.Value.Part3Amount);
    decimal totalDebt = balances.Sum(x => x.Value.Debt.TotalDebt);
    (part3Total, totalNetWorth, totalDebt, $"{from} -> {to} {amount}").ToString().Dump();
    Debug.Assert(totalNetWorth == part3Total);
}

decimal top3 = balances
  .Select(x => x.Value.Part1Amount)
  .OrderByDescending(x => x)
  .Take(3)
  .Sum();
decimal top3Limited = balances
  .Select(x => x.Value.Part2Amount)
  .OrderByDescending(x => x)
  .Take(3)
  .Sum();
decimal top3WithRepayments = balances
  .Select(x => x.Value.Part3Amount)
  .OrderByDescending(x => x)
  .Take(3)
  .Sum();

top3.Dump();
top3Limited.Dump();
top3WithRepayments.Dump();

