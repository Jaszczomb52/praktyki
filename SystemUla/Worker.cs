using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUla
{
    class Worker
    {
        public string CurrentJob { get; }
        public int ShiftLefts { get; }

        private string[] jobsICanDo;
        private int shiftsToWork;
        private int shiftsWorked;
        
        public Worker(string[] jobs)
        {
            jobsICanDo = jobs;
        }

        private void DoThisJob()
        {

        }

        private void WorkOneShift()
        {

        }
    }
}
