using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DE_GUI
{
    public class Grid
    {
        public double[] x { get; }
        public double[] y { get; }
        public int N;
        public double h;
        public Grid(double x0, double X, int N) {
            x = new double[N];
            y = new double[N];
            h = (X - x0) / N;
            x[0] = x0;
            for (int i = 1; i < N; i++) x[i] = x[i - 1] + h;
        }
    }
}
