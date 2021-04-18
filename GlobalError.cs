using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DE_GUI
{
    public class GlobalError : GlobalErrorInterface
    {
        public double[] maxError_euler { get; }
        public double[] maxError_ie { get; }
        public double[] maxError_rk { get; }
        public int[] arrayN { get; }
        
        int n0;
        int N;
        double x0;
        double X;
        double y0;
        public GlobalError(double x0, double X, double y0, int n0, int N, bool euler, bool ie, bool rk)
        {
            this.n0 = n0;
            this.N = N;
            this.X = X;
            this.x0 = x0;
            this.y0 = y0;
            arrayN = new int[N - n0];
            maxError_euler = new double[N - n0];
            maxError_ie = new double[N - n0];
            maxError_rk = new double[N - n0];
            for (int i = 0; i < N - n0; i++)
            {
                maxError_euler[i] = 0;
                maxError_ie[i] = 0;
                maxError_rk[i] = 0;
            }
            for (int n = n0; n < N; n++)
            {
                arrayN[n - n0] = n;
            }
            if(euler)UpdateEuler();
            if(ie)UpdateIe();
            if(rk) UpdateRk();
        }
        public void UpdateEuler()
        {
            for (int n = n0; n < N; n++)
            {
                ExactSolution es_local = new ExactSolution(x0, X, n, y0);
                Euler euler_local = new Euler(x0, X, n, y0);
                double[] euler_error = new TrunkError(es_local.y, euler_local.y, n).error;
                for (int i = 0; i < n; i++)
                {
                    if (euler_error[i] > maxError_euler[n - n0]) maxError_euler[n - n0] = euler_error[i];
                }
            }
        }
        public void UpdateIe()
        {
            for (int n = n0; n < N; n++)
            {
                ExactSolution es_local = new ExactSolution(x0, X, n, y0);
                ImprovedEuler ie_local = new ImprovedEuler(x0, X, n, y0);
                double[] ie_error = new TrunkError(es_local.y, ie_local.y, n).error;
                for (int i = 0; i < n; i++)
                {
                    if (ie_error[i] > maxError_ie[n - n0]) maxError_ie[n - n0] = ie_error[i];
                }
            }
        }
        public void UpdateRk()
        {
            for (int n = n0; n < N; n++)
            {
                ExactSolution es_local = new ExactSolution(x0, X, n, y0);
                RungeKutta rk_local = new RungeKutta(x0, X, n, y0);
                double[] rk_error = new TrunkError(es_local.y, rk_local.y, n).error;
                for (int i = 0; i < n; i++)
                {
                    if (rk_error[i] > maxError_rk[n - n0]) maxError_rk[n - n0] = rk_error[i];
                }
            }
        }
    }
}
