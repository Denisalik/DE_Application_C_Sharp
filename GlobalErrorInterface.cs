using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DE_GUI
{
    interface GlobalErrorInterface
    {
        double[] maxError_euler { get; }
        double[] maxError_ie { get; }
        double[] maxError_rk { get; }
        int[] arrayN { get; }
        void UpdateIe();

        void UpdateEuler();
        void UpdateRk();
    }
}
