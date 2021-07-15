using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUla
{
    class Worker : Bee
    {
        public string CurrentJob { private set; get; }
        public int ShiftsLeft { private set; get; }

        readonly private string[] jobsICanDo;
        private int shiftsToWork;
        private int shiftsWorked;
        
        public Worker(string[] jobs, double weightMg):base(weightMg)
        {
            jobsICanDo = jobs;
        }

        public bool DoThisJob(string job, int shift)
        {
            if(!String.IsNullOrEmpty(job))
            {
                for(int i = 0;i<jobsICanDo.Length;i++)
                {
                    if(jobsICanDo[i] == job)
                    {
                        shiftsToWork = shift;
                        CurrentJob = job;
                        shiftsWorked = 0;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool DidYouFinish()
        {
            if(!String.IsNullOrEmpty(CurrentJob ))
            {
                shiftsWorked++;
                ShiftsLeft = shiftsToWork - shiftsWorked;
                if(shiftsWorked>shiftsToWork)
                {
                    shiftsWorked = 0;
                    shiftsToWork = 0;
                    CurrentJob = "";
                    return true;
                }
            }
            return false;
        }

        public override double HoneyConsumptionRate()
        {
            if (shiftsToWork > 0)
                return base.HoneyConsumptionRate() + 0.65 * shiftsWorked;
            else
                return base.HoneyConsumptionRate();
        }
    }
}
