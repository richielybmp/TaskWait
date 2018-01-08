using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int>[] minhasTasks = new Task<int>[3];
            minhasTasks[0] = Task.Run(() => { Thread.Sleep(5000); return 0; });
            minhasTasks[1] = Task.Run(() => { Thread.Sleep(1000); return 1; });
            minhasTasks[2] = Task.Run(() => { Thread.Sleep(3000); return 2; });

            while (minhasTasks.Length > 0)
            {
                var index = Task.WaitAny(minhasTasks);
                Task<int> task_finalizada = minhasTasks[index];

                Console.WriteLine(task_finalizada.Result);

                var task_temp = minhasTasks.ToList();
                task_temp.RemoveAt(index);
                minhasTasks = task_temp.ToArray();
            }
        }

        //static void Main(string[] args)
        //{
        //    //Task task = new Task(minhaTarefa);
        //    //Task task = Task.Factory.StartNew(minhaTarefa);
        //    //Task task = Task.Run(new Action(minhaTarefa));

        //    //Task<int> task = new Task<int>(minhaTarefa);
        //    //Task<int> task = Task<int>.Factory.StartNew(minhaTarefa);
        //    Task<int> task = Task.Run<int>(new Func<int>(minhaTarefa));
        //    Task<string> task_string = Task.Run(() => { return "retorno"; });
        //    //task.Start();
        //    var x = task.Result;
        //    var y = task_string.Result;
        //    //task.Wait();
        //    Console.WriteLine("teste");
        //}

        //public static int minhaTarefa()
        //{
        //    for (int x = 0; x < 10; x++)
        //    {
        //        Console.WriteLine("{0}", x);
        //    }
        //    return 10;
        //}
    }
}
