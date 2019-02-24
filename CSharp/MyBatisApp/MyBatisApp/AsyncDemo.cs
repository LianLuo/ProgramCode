
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyBatisApp
{
    public class AsyncDemo
    {
        public string Greeting(string name)
        {
            Thread.Sleep(5000);
            return "";
            //return $"Hello,{name}";
        }

        public Task<string> GreetingAsync(string name)
        {
            throw new Exception();
            //return Task.Run<string>(() => { return Greeting(name); });
        }
    }
}