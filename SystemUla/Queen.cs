using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUla
{
    class Queen : Bee
    {
        readonly private Worker[] workers = new Worker[4];
        private int shiftNumber;

        public Queen(Worker[] workers, double weightMg) : base(weightMg)
        {
            this.workers = workers;
            shiftNumber = 0;
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

        public string WorkTheNextShift()
        {
            shiftNumber++;
            string report = "Raport zmiany nr " + shiftNumber + "\r\n";
            double honeyConsumption = 0;
            for(int i=0;i<workers.Length;i++)
            {
                if (workers[i].DidYouFinish())
                    report += "Robotnica nr " + (i + 1) + " zakończyła swoje zadanie\r\n";
                if (String.IsNullOrEmpty(workers[i].CurrentJob)) 
                    report += "Robotnica nr " + (i + 1) + " nie pracuje \r\n";
                else
                    if (workers[i].ShiftsLeft > 0)
                    report += "Robotnica nr " + (i + 1) + " robi " + workers[i].CurrentJob + " przez jeszcze " + workers[i].ShiftsLeft + " zmian/y\r\n";
                    else
                    report += "Robotnica nr " + (i + 1) + " zakończy " + workers[i].CurrentJob + " po tej zmianie \r\n";
                honeyConsumption += workers[i].HoneyConsumptionRate();
            }
            honeyConsumption += HoneyPerMg;
            report += "Całkowite spożycie miodu: " + honeyConsumption + " jednostek\r\n";
            return report;
        }
    }
}
