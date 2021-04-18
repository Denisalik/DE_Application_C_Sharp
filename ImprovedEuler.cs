using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DE_GUI
{
    public class ImprovedEuler:Grid, Method
    {
        public ImprovedEuler(double x0, double X, int N, double y0) : base(x0, X, N)
        {
            y[0] = y0;
            for (int i = 1; i < N; i++)
            {
                y[i] = y[i - 1] + base.h / 2 * (Func(x[i - 1], y[i - 1]) + Func(x[i], y[i-1] + base.h * Func(x[i-1],y[i-1])));
            }
        }
        public double Func(double x, double y)
        {
            return y / x + x * Math.Cos(x);
        }
    }
}
