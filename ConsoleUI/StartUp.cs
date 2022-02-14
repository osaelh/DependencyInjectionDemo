using Autofac;
using DemoLibrary;
using DemoLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class StartUp : IStartUp
    {
        private readonly IBusinessLogic _businessLogic;

        public StartUp(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }

        public void Run()
        {
            _businessLogic.ProcessData();
        }

    }
}
