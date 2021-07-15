using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUla
{
    class Worker
    {
        public string CurrentJob { set; get; }
        public int ShiftsLeft { set; get; }

        private string[] jobsICanDo;
        private int shiftsToWork;
        private int shiftsWorked;
        
        public Worker(string[] jobs)
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
    }
}
