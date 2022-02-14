using Autofac.Extras.DynamicProxy;
using System.Collections.Generic;

namespace DemoLibrary.Utilities
{
    [Intercept("Log_calls")]
    public interface IDataAccess
    {
        void LoadData();
        void SaveData(string name);
        IEnumerable<string> GetListOfStates();
    }
}