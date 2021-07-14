using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUla
{
    class Queen
    {
        private Worker[] workers = new Worker[4];
        private int shiftNumber = 0;

        public Queen(Worker[] workers)
        {
            this.workers = workers;
            shiftNumber = 1;
        }

        public bool AssignWork(string job, int shift)
        {
            for(int i=0;i<workers.Length;i++)
            {
                if (workers[i].DoThisJob(job,shift))
                {
                    return true;
                }
            }
            return false;
        }

        public string WorkTheNextShift(int shift)
        {
            shiftNumber++;
            string report = "Raport zmiany nr " + shift + "\r\n";
            for(int i=0;i<workers.Length;i++)
            {
                if (workers[i].DidYouFinish())
                    report += "Robotnica nr " + (i + 1) + " zakończyła swoje zadanie\r\n";
                if (String.IsNullOrEmpty(workers[i].CurrentJob)) 
                    report += "Robotnica nr " + (i + 1) + " nie pracuje \r\n";
                else
                    if (workers[i].ShiftLefts > 0)
                    report += "Robotnica nr " + (i + 1) + " robi " + workers[i].CurrentJob + " przez jeszcze " + workers[i].ShiftLefts + " zmian/y\r\n";
                else
                    report += "Robotnica nr " + (i + 1) + " zakończy " + workers[i].CurrentJob + " po tej zmianie \r\n";
            }
            return report;
        }
    }
}
