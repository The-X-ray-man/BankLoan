using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class MortgageLoan : Loan, ILoan
    {
        private const double amount = 50000;
        private const int interestRate = 3;

        public MortgageLoan() : base(interestRate, amount)
        {
        }
    }
}
