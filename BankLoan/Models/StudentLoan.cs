using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class StudentLoan : Loan, ILoan
    {
        private const double amount = 10000;
        private const int interestRate = 1;

        public StudentLoan() : base(interestRate, amount)
        {
        }
    }
}
