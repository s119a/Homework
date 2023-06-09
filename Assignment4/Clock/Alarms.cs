using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public class Alarms
    {
        public event EventHandler<EventArgs> Tick;
        public event EventHandler<EventArgs> Alarm;
        private bool isRunning;
        private Timer timer;
        public DateTime alarmTime { get; set; }
        public void Start()
        {
            if (isRunning) return;
            isRunning = true;
            timer = new System.Threading.Timer(
                callback: (state) =>
                {
                    if (DateTime.Now >= alarmTime)
                    {
                        Alarm(this, new EventArgs("Ring!"));
                    }
                    else
                    {
                        Tick(this, new EventArgs("Tick Tock..."));
                    }
                },
                state: null,
                dueTime: 0,
                period: 1000
            );
        }
        public void Stop()
        {
            if (!isRunning) return;
            isRunning = false;
            timer.Dispose();
            timer = null;
        }
    }
}
