using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private List<ILoan> loans;
        private List<IClient> clients;
        private string name;

        public string Name 
        { 
            get => name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                name = value;
            }
        }
        public int Capacity { get; private set; }

        protected Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            clients = new List<IClient>();
            loans = new List<ILoan>();
        }

        public IReadOnlyCollection<ILoan> Loans { get => loans; }
        public IReadOnlyCollection<IClient> Clients { get => clients; }
        public double SumRates()
        {
            double sumRates = 0;
            foreach (var loan in loans) sumRates += loan.InterestRate;
            return sumRates;
        }
        public void AddLoan(ILoan loan)
        {
            loans.Add(loan);
        }
        public void AddClient(IClient client)
        {
            if (clients.Count >= Capacity) throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            clients.Add(client);
        }
        public void RemoveClient(IClient client)
        {
            clients.Remove(client);
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Name}, Type: {GetType().Name}");
            if (clients.Count > 0) sb.AppendLine("Clients: " + string.Join(", ", clients.Select(x => x.Name)));
            else sb.AppendLine("Clients: none");
            sb.AppendLine($"Loans: {loans.Count}, Sum of Rates: {SumRates()}");
            return sb.ToString().TrimEnd();
        }
    }
}
