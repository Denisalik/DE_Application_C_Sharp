using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DE_GUI
{
    public class ExactSolution : Grid
    {
        public ExactSolution(double x0, double X, int N, double y0) : base(x0, X, N)
        {
            double constant = y0 / x0 - Math.Sin(x0);
            y[0] = y0;
            for (int i = 1; i < N; i++) y[i] = x[i] * Math.Sin(x[i]) + x[i] * constant;
        }
    }
}
