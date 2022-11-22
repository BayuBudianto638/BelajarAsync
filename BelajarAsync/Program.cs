//namespace BelajarAsync
//{
//    class Program
//    {
//        declare empty class for demo purpose only
//        internal class Bacon { }
//        internal class Coffee { }
//        internal class Egg { }
//        internal class Juice { }
//        internal class Toast { }

//        static async Task Main(string[] args)
//        {
//            //var cup = await PourCoffeeAsync();
//            var cup = PourCoffeeAsync();
//            Console.WriteLine("coffee is ready");

//            ////var eggs = await FryEggsAsync(2);
//            var eggs = FryEggsAsync(2);
//            Console.WriteLine("eggs are ready");

//            //var bacon = await FryBaconAsync(3);
//            var bacon = FryBaconAsync(3);
//            Console.WriteLine("bacon is ready");

//            var toast = await MakeToastBreadAsync(2);
//            //var toast = MakeToastBreadAsync(2);

//           // Menunggu semua Task yg diassign untuk menyelesaikan eksekusi nya
//            Task.WaitAll(cup, eggs, bacon, toast);

//            //Toast toast = await ToastBreadAsync(2);
//            //await ApplyButterAsync(toast);
//            //await ApplyJamAsync(toast);
//            //Console.WriteLine("toast is ready");

//            Juice oj = await PourOJAsync();
//            Console.WriteLine("oj is ready");
//            Console.WriteLine("Breakfast is ready!");
//        }

//        private static async Task<Juice> PourOJAsync()
//        {
//            Thread.Sleep(5000);
//            Console.WriteLine("Pouring orange juice");
//            return await Task.Run(() => new Juice());
//        }

//        private static async Task ApplyJamAsync(Toast toast) =>
//            Console.WriteLine("Putting jam on the toast");

//        private static async Task ApplyButterAsync(Toast toast) =>
//            Console.WriteLine("Putting butter on the toast");

//        private static async Task<Toast> MakeToastBreadAsync(int number)
//        {
//            Thread.Sleep(5000);
//            var toast = await ToastBreadAsync(number);
//            await ApplyButterAsync(toast);
//            await ApplyJamAsync(toast);

//            return toast;
//        }

//        private static async Task<Toast> ToastBreadAsync(int slices)
//        {
//            for (int slice = 0; slice < slices; slice++)
//            {
//                Console.WriteLine("Putting a slice of bread in the toaster");
//            }
//            Console.WriteLine("Start toasting...");
//            Task.Delay(3000).Wait();
//            Console.WriteLine("Remove toast from toaster");

//            return await Task.Run(() => new Toast());
//        }

//        private static async Task<Bacon> FryBaconAsync(int slices)
//        {
//            Console.WriteLine($"putting {slices} slices of bacon in the pan");
//            Console.WriteLine("cooking first side of bacon...");
//            Task.Delay(3000).Wait();
//            for (int slice = 0; slice < slices; slice++)
//            {
//                Console.WriteLine("flipping a slice of bacon");
//            }
//            Console.WriteLine("cooking the second side of bacon...");
//            Task.Delay(3000).Wait();
//            Console.WriteLine("Put bacon on plate");

//            return await Task.Run(() => new Bacon());
//        }

//        private static async Task<Egg> FryEggsAsync(int howMany)
//        {
//            Console.WriteLine("Warming the egg pan...");
//            Task.Delay(3000).Wait();
//            Console.WriteLine($"cracking {howMany} eggs");
//            Console.WriteLine("cooking the eggs ...");
//            Task.Delay(3000).Wait();
//            Console.WriteLine("Put eggs on plate");

//            return await Task.Run(() => new Egg());
//        }

//        private static async Task PourCoffeeAsync()
//        {
//            Console.WriteLine("Pouring coffee");
//            return await Task.Run(() => new Coffee());

//            await Task.Run(() =>
//            {
//                Console.WriteLine("Pouring coffee");
//            });
//        }
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        // Demo synchronous: Method akan di baca 1 per 1 oleh compiler dan di eksekusi secara berurutan.
//        // Demo Asynchronous: Method akan di baca sekaligus oleh Task dan compiler akan membuat thread
//        // untuk setiap Task yg di handle
//        DemoAsync();
//    }

//    public static void DemoAsync()
//    {
//        var watch = new System.Diagnostics.Stopwatch();
//        watch.Start();
//        StartTask();
//        TaskTwo();
//        TaskOne();

//        watch.Stop();

//        Console.Write($"Execution time is : {watch.ElapsedMilliseconds} ms");
//    }

//    public static void StartTask()
//    {
//        Thread.Sleep(8000);
//        Console.WriteLine("Task Started");
//    }

//    public static void TaskTwo()
//    {
//        Thread.Sleep(3000);
//        Console.WriteLine("Task Two");
//    }

//    public static void TaskOne()
//    {
//        Thread.Sleep(2000);
//        Console.WriteLine("Task One");
//    }
//}

public class EnigmaCamp
{
    static void Main()
    {
        // Demo synchronous: Method akan di baca 1 per 1 oleh compiler dan di eksekusi secara berurutan.
        // Demo Asynchronous: Method akan di baca sekaligus oleh Task dan compiler akan membuat thread
        // untuk setiap Task yg di handle
        // async, await dan Task
        // Task <--- Kerjaan yg terdiri dari banyak thread
        DemoAsync();
        Console.ReadLine(); 
    }

    public static async void DemoAsync()
    {
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        var task1 = StartTask();
        await task1; // tunggu, sampai yg ini selesai

        var task2 = TaskTwo(); // execute
        var task3 = TaskOne(); // execute

        Task.WaitAll(task1, task2, task3); // bikin thread sebanyak 3 thread

        watch.Stop();

        Console.Write($"Execution time is : {watch.ElapsedMilliseconds} ms");
    }

    public static async Task StartTask()
    {
        await Task.Run(() =>
        {
            Thread.Sleep(8000);
            Console.WriteLine("Task Started");
        });
    }

    public static async Task TaskTwo()
    {
        await Task.Run(() =>
        {
            Thread.Sleep(3000);
            Console.WriteLine("Task Two");
        });
    }

    public static async Task TaskOne()
    {
        await Task.Run(() =>
        {
            Thread.Sleep(2000);
            Console.WriteLine("Task One");
        });
    }
}