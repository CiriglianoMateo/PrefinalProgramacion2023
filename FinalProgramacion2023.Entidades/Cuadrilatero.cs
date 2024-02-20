using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProgramacion2023.Entidades
{
    public class Cuadrilatero
    {
        public int LadoA { get; set; }
        public int LadoB { get; set; }  
        public Borde Borde { get; set; }
        public Relleno Relleno { get; set; }

        public void Add(Cuadrilatero cuadrilatero)
        {
            throw new NotImplementedException();
        }

        public double GetArea() => LadoA * LadoB;
        public double GetPerimetro() => 2 * LadoA + 2 * LadoB;
    }
}
