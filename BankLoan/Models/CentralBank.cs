﻿using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    internal class CentralBank : Bank, IBank
    {
        public CentralBank(string name) : base(name, 50)
        {
        }
    }
}
