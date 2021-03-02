using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flight;

namespace Flight.BusinessModel
{
    class Model
    {
        Form1 form;

        FlyingObject obj;
        Atmosphere atm;

        double t;
        const double dt = 0.01;

        double k;

        public Model(Form1 form)
        {
            this.form = form;
            double[] mas = form.ReadData();
            obj = new FlyingObject(mas[0], mas[1], mas[2], mas[3], mas[4]);
            atm = new Atmosphere(obj);
        }

        public KeyValuePair<double, double> Start()
        {
            k = 0.5 * Atmosphere.C * obj.S * Atmosphere.rho / obj.m;

            obj.vx = obj.v0 * Math.Cos(obj.a * Math.PI / 180);
            obj.vy = obj.v0 * Math.Sin(obj.a * Math.PI / 180);

            t = 0;
            obj.x = 0;
            obj.y = obj.y0;

            KeyValuePair<double, double> pair = new KeyValuePair<double, double>(obj.x, obj.y);

            return pair;
        }

        public KeyValuePair<double, double> NextTick()
        {
            t += dt;
            obj.vx = obj.vx - k * obj.vx * Math.Sqrt(obj.vx * obj.vx + obj.vy * obj.vy) * dt;
            obj.vy = obj.vy - (Atmosphere.g + k * obj.vy * Math.Sqrt(obj.vx * obj.vx + obj.vy * obj.vy)) * dt;

            obj.x = obj.x + obj.vx * dt;
            obj.y = obj.y + obj.vy * dt;            

            KeyValuePair<double, double> pair = new KeyValuePair<double, double>(obj.x, obj.y);

            return pair;
        }
    }
}
