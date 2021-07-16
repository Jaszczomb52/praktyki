using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Dom
{
    class Outside : Location
    {
        private bool hot;
        public Outside(string name, bool hot, Ellipse waypoint):base(name, waypoint)
        {
            this.hot = hot;
        }

        public override string Description
        {
            get
            {
                string NewDescription = base.Description;
                if(hot)
                {
                    NewDescription += "Tutaj jest bardzo gorąco.";
                }
                return NewDescription;
            }
        }
    }
}
