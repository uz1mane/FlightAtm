using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.BusinessModel
{
    class Atmosphere
    {
        public const double g = 9.81;
        public const double C = 0.15;
        public const double rho = 1.29;

        FlyingObject obj;

        public Atmosphere(FlyingObject obj)
        {
            this.obj = obj;
        }
        
    }
}
