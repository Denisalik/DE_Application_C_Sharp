using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DE_GUI
{
    public class RungeKutta:Grid,Method
    {
        public double[] k1;
        public double[] k2;
        public double[] k3;
        public double[] k4;
        public RungeKutta(double x0, double X, int N, double y0) : base(x0, X, N)
        {
            y[0] = y0;
            k1 = new double[N];
            k2 = new double[N];
            k3 = new double[N];
            k4 = new double[N];
            for (int i = 1; i < N; i++)
            {
                k1[i - 1] = Func(x[i - 1], y[i - 1]);
                k2[i - 1] = Func(x[i - 1] + base.h / 2, y[i - 1] + base.h / 2 * k1[i - 1]);
                k3[i - 1] = Func(x[i - 1] + base.h / 2, y[i - 1] + base.h / 2 * k2[i - 1]);
                k4[i - 1] = Func(x[i - 1] + base.h, y[i - 1] + base.h * k3[i - 1]);
                y[i] = y[i - 1] + base.h / 6 * (k1[i - 1] + 2 * k2[i - 1] + 2 * k3[i - 1] + k4[i - 1]);
            }
        }
        public double Func(double x, double y)
        {
            return y / x + x * Math.Cos(x);
        }
    }
}
