using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace async_test
{
    class Program
    {
        static void Main(string[] args)
        {

            Task.Run(async () => await new Runner().Run());

            
            Console.ReadLine();
        }
    }

    public class Runner{
        public async Task Run(){
            Console.WriteLine("Start");

            var handler = new Handler();
            List<int> processIds = Enumerable.Range(1,10).ToList();

            await Task.WhenAll(processIds.Select(s => Task.Run(() => handler.Handle(s))));

            // var tasks = new List<Task>();
            // foreach(var pid in processIds){
            //     tasks.Add(handler.Handle(pid));
            // }

            // Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Stop");
            //await Task.Run(() => Parallel.ForEach(processIds, async pid => await handler.Handle(pid)));

            // foreach(int pid in processIds){
            //     await handler.Handle(pid);
            // }
        }
    }

    public class Handler{
        public async Task Handle(int process) {
            await Task.Delay(1000);
            Console.WriteLine($"Completed: {process}");
        }
    }
}
