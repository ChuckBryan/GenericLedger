namespace GenericLedger
{
    using System;
    using System.Collections.Generic;

    public class Ledger
    {
        private readonly IList<LedgerTransaction> _transactions;

        public Ledger()
        {
            _transactions = new List<LedgerTransaction>();
        }

        public IEnumerable<LedgerTransaction> Transactions => _transactions;

        public void AddDebit(string type, Decimal amount, string description = "")
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentNullException(nameof(type));
            }
                

            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be gerater than 0.");
            }

            var transaction = new LedgerTransaction(DateTime.Now, type,0, amount, description);

            _transactions.Add(transaction);
        }

        public void AddCredit(string type, Decimal amount, string decription = "")
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be gerater than 0.");
            }

            var transaction = new LedgerTransaction(DateTime.Now, type, amount, 0, decription);

            _transactions.Add(transaction);

        }
    }

    public class LedgerTransaction
    {

        public LedgerTransaction(DateTime dateTime, string type, decimal credit, decimal debit, string description = "")
        {
            DateTime = dateTime;
            Type = type;
            Credit = credit;
            Debit = debit;
            Description = description;
        }

        public DateTime DateTime { get; private set; }

        public string Type { get; private set; }

        public Decimal Credit { get; private set; }

        public Decimal Debit { get; private set; }

        public string Description { get; private set; }
    }
}