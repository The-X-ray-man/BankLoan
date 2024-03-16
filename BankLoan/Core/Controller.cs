using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Repositories.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private IRepository<ILoan> loans;
        private IRepository<IBank> banks;

        public Controller()
        {
            loans = new LoanRepository();
            banks = new BankRepository();
        }

        public string AddBank(string bankTypeName, string name)
        {
            //throw new NotImplementedException();
            if (bankTypeName != nameof(BranchBank) && bankTypeName != nameof(CentralBank)) throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
            if (bankTypeName == nameof(BranchBank)) banks.AddModel(new BranchBank(name));
            else banks.AddModel(new CentralBank(name));
            return string.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            //throw new NotImplementedException();
            if (clientTypeName != nameof(Student) && clientTypeName != nameof(Adult)) throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
            IBank selectedBank = banks.Models.FirstOrDefault(x => x.Name == bankName);
            if ((clientTypeName == nameof(Student) && selectedBank.GetType().Name != nameof(BranchBank))
                || (clientTypeName == nameof(Adult) && selectedBank.GetType().Name != nameof(CentralBank)))
            {
                return OutputMessages.UnsuitableBank;
            }
            if (clientTypeName == nameof(Student)) selectedBank.AddClient(new Student(clientName, id, income));
            else selectedBank.AddClient(new Adult(clientName, id, income));
            return string.Format(OutputMessages.LoanReturnedSuccessfully, clientTypeName, bankName);
        }

        public string AddLoan(string loanTypeName)
        {
            //throw new NotImplementedException();
            if (loanTypeName != nameof(MortgageLoan) && loanTypeName != nameof(StudentLoan)) throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);
            if (loanTypeName == nameof(MortgageLoan)) loans.AddModel(new MortgageLoan());
            else loans.AddModel(new StudentLoan());
            return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
        }

        public string FinalCalculation(string bankName)
        {
            throw new NotImplementedException();
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            //throw new NotImplementedException();
            ILoan loan;
            if (loanTypeName == nameof(StudentLoan)) loan = new StudentLoan();
            else loan = new MortgageLoan();
            if (!loans.RemoveModel(loan)) throw new ArgumentException(ExceptionMessages.MissingLoanFromType, nameof(loan));
            banks.Models.FirstOrDefault(x => x.Name == bankName).AddLoan(loan);
            return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
        }

        public string Statistics()
        {
            throw new NotImplementedException();
        }
    }
}
