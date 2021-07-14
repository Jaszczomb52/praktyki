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
        public int ShiftLefts { set; get; }

        private string[] jobsICanDo;
        private int shiftsToWork;
        private int shiftsWorked = 0;
        
        public Worker(string[] jobs)
        {
            jobsICanDo = jobs;
        }

        public bool DoThisJob(string job, int shift)
        {
            for(int i = 0;i<2;i++)
            {
                if(jobsICanDo[i] == job)
                {
                    shiftsToWork = shift;
                    CurrentJob = job;
                    return true;
                }
            }
            return false;
        }

        public void WorkOneShift()
        {

        }
    }
}
