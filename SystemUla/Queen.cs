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
        private int shiftNumber { get; set; }

        public Queen(Worker[] workers)
        {
            this.workers = workers;
        }

        public void AssignWork(string job, int shift)
        {
            for(int i=0;i<4;i++)
            {
                if (workers[i].DoThisJob(job,shift))
                {
                    break;
                }
            }
        }

        public void WorkTheNextShift()
        {

        }
    }
}
