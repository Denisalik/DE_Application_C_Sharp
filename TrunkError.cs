using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DE_GUI
{
    public class TrunkError
    {
        public double[] error { get; }
        public TrunkError(double[] exact, double[] appr, int N)
        {
            error = new double[N];
            for(int i=0; i < N; i++)
            {
                error[i] = Math.Abs(exact[i] - appr[i]);
            }
        }
    }
}
