using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Utilities
{
    public class DataAccess : IDataAccess
    {
        public void LoadData()
        {
            Console.WriteLine("Loading Data");
        }

        public void SaveData(string name)
        {
            Console.WriteLine($"Saving { name }");
        }

        public IEnumerable<string> GetListOfStates()
        {
            return new List<string> { "State 1", "State 2", "State 3", "State 4" };
        }
    }
}
