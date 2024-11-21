
namespace ThreadPrioritys
{
    using System.Threading;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread threadA = new Thread(MyThreadClass.Thread1) { Name = "ThreadA", Priority = ThreadPriority.Highest };
            Thread threadB = new Thread(MyThreadClass.Thread2) { Name = "ThreadB", Priority = ThreadPriority.Normal };
            Thread threadC = new Thread(MyThreadClass.Thread1) { Name = "ThreadC", Priority = ThreadPriority.AboveNormal };
            Thread threadD = new Thread(MyThreadClass.Thread2) { Name = "ThreadD", Priority = ThreadPriority.BelowNormal };

            threadA.Start();
            threadB.Start();
            threadC.Start();
            threadD.Start();

            threadA.Join();
            threadB.Join();
            threadC.Join();
            threadD.Join();

            label1.Text = "-End of Thread-";

        }

        private void button1_Click(object sender, EventArgs e)
        {

            

            
        }
    }

    public static class MyThreadClass
    {
        public static void Thread1()
        {
            for (int i = 0; i < 2; i++)
            {
                Thread thread = Thread.CurrentThread;
                Console.WriteLine("Name of Thread: " + thread.Name + " Process = " + i);
                Thread.Sleep(500);
            }
            Console.WriteLine($"The thread {Thread.CurrentThread.ManagedThreadId} has exited with code 0 (0x0).");
        }

        public static void Thread2()
        {
            for (int i = 0; i < 6; i++)
            {
                Thread thread = Thread.CurrentThread;
                Console.WriteLine("Name of Thread: " + thread.Name + " Process = " + i);
                Thread.Sleep(1500); 
            }
            Console.WriteLine($"The thread {Thread.CurrentThread.ManagedThreadId} has exited with code 0 (0x0).");
        }
    }

}
