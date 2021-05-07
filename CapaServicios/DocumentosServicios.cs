using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
using System.Threading;

namespace CapaServicios
{
    public class DocumentosServicios
    {
        // logica de secuencia

        private static int secuencia = 0;

        public int Secuencia()
        {
            return Interlocked.Increment(ref secuencia);
        }
    }
}
