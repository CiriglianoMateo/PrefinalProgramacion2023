using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProgramacion2023.Entidades
{
    public class Cuadrilatero
    {


        public int LadoA { set; get; }
        public int LadoB { set; get; }

        public Borde Borde { get; set; }
        public Relleno Relleno { get; set; }

        public int GetArea() => LadoA * LadoB;
        public int GetPerimetro() => 2 * LadoA + 2 * LadoB;

        public string cuadrado
        {
            get
            {
                return tipoCuadrado(LadoA, LadoB);
            }

        }

        private static string tipoCuadrado(int ladoA, int ladoB)
        {
            if (ladoA == ladoB)
            {
                return "Cuadrado";
            }
            else
            {
                return "Rectangulo";

            }


        }
    }
}
