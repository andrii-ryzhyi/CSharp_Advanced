using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public delegate int WorkPerformedHandler(int hours, WorkType workType);
    public class Worker
    {
        public event WorkPerformedHandler WorkPerformed;
        public event EventHandler WorkCompleted;
        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                OnWorkPerformed(i + 1, workType);
            }
            OnWorkCompleted();
            //Raise event
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            (WorkPerformed as WorkPerformedHandler)?.Invoke(hours, workType);
        }

        protected virtual void OnWorkCompleted()
        {
            (WorkCompleted as EventHandler)?.Invoke(this, EventArgs.Empty);
        }
    }
}
