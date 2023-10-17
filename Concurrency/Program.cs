using System.Diagnostics;
using static System.Console;


static void DoWork()
{
    WriteLine("Doing the work...");
    Thread.Sleep(1000);
    WriteLine("done");
}

var watch = Stopwatch.StartNew();

var t1 = new Thread(DoWork);
var t2 = new Thread(DoWork);


// start both threads
t1.Start();
t2.Start();

// wait for both threads completed
t1.Join();
t2.Join();


watch.Stop();
WriteLine($"It took {watch.Elapsed.Seconds} second(s) to complete.");