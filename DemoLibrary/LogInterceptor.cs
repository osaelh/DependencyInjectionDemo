using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class LogInterceptor : IInterceptor
    {
        private TextWriter @out;

        public LogInterceptor(TextWriter @out)
        {
            this.@out = @out;
        }

        public void Intercept(IInvocation invocation)
        {
            //This happens before the method call
            @out.WriteLine("Calling method {0} with parameters {1}... ",
            invocation.Method.Name,
            string.Join(", ", invocation.Arguments.Select(a => (a ?? "0").ToString()).ToArray()));

            //Actual method call begins
            invocation.Proceed();

            //This happens after a method call
            @out.WriteLine("Done: result was {0}.", invocation.ReturnValue);
        }
    }
}
