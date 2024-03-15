using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public abstract class Client
    {
        protected Client(string name, string id, int interest, double income)
        {
            Name = name;
            Id = id;
            Interest = interest;
            Income = income;
        }

        public string Name 
        { 
            get => Name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException(ExceptionMessages.ClientNameNullOrWhitespace);
                Name = value;
            }
        }
        public string Id
        {
            get => Name;
            private set
            {
                if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException(ExceptionMessages.ClientIdNullOrWhitespace);
                Name = value;
            }
        }
        public int Interest {  get; protected set; }
        public double Income
        {
            get => Income;
            private set
            {
                if (value <= 0) throw new ArgumentException(ExceptionMessages.ClientIncomeBelowZero);
                Income = value;
            }
        }
        public abstract void IncreaseInterest();
    }
}
