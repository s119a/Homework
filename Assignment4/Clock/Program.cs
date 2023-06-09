using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clock
{
    class Program {
        static void Main(string[] args)
        {
            var alarm = new Alarms();

            alarm.Tick += (sender, e) => Console.WriteLine(e.Message);
            alarm.Alarm += (sender, e) => Console.WriteLine(e.Message);

            Console.WriteLine("设置闹钟");
            int n = Convert.ToInt32(Console.ReadLine());
            alarm.alarmTime = DateTime.Now.AddSeconds(n);
            alarm.Start();
            Console.ReadKey();
            alarm.Stop();
        }
    }
}
