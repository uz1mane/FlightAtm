using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.BusinessModel
{
    class FlyingObject
    {
        public double a { get; private set; }
        public double v0 { get; private set; }
        public double y0 { get; private set; }
        public double S { get; private set; }
        public double m { get; private set; }

        public double x;
        public double y;
        public double vx;
        public double vy;

        public FlyingObject(double a, double v0, double y0, double m, double S)
        {
            this.a = a;
            this.v0 = v0;
            this.y0 = y0;
            this.S = S;
            this.m = m;            
        }
    }
}
