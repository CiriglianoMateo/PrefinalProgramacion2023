using FinalProgramacion2023.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProgramacion2023.Datos;

namespace FinalProgramacion2023.Datos
{
    public class RepositorioDatos
    {
        private readonly string _Archivo = Environment.CurrentDirectory + "\\cuadrilatero.txt";
        private List<Cuadrilatero> cuadrilateros;
        public RepositorioDatos() 
        {
            cuadrilateros = new List<Cuadrilatero>();
            LeerDatosArchivo();
        }

        private void LeerDatosArchivo()
        {
            if (File.Exists(_Archivo))
            {
                using (var lector = new StreamReader(_Archivo))
                {
                    while (!lector.EndOfStream)
                    {
                        var lineaLeida = lector.ReadLine();
                        var cuadrilatero = construirCuadrilatero(lineaLeida);
                        cuadrilateros.Add((Cuadrilatero)cuadrilatero);
                    }
                }
            }
        }
        public List<Cuadrilatero> GetLista() => cuadrilateros;
        private object construirCuadrilatero(string? lineaLeida)
        {
            var campos = lineaLeida.Split("|");
            var LadoACuadrilatero = int.Parse(campos[0]);
            var LadoBCuadrilatero = int.Parse(campos[1]);
            var bordeCuadrilatero = (Borde)int.Parse(campos[2]);
            var rellenoCuadrilatero = (Relleno)int.Parse(campos[3]);
            return new Cuadrilatero
            {
                LadoA = LadoACuadrilatero,
                Borde = bordeCuadrilatero,
                Relleno = rellenoCuadrilatero,

            };
        }
        public void Agregar(Cuadrilatero cuadrilatero)
        {
            using (var escribir = new StreamWriter(_Archivo, true))
            {
                string lineaEscribir = construirLinea(cuadrilatero);
                escribir.WriteLine(lineaEscribir);
            }
        }

        private string construirLinea(Cuadrilatero cuadrilatero)
        {
            return $"{cuadrilatero.LadoB}|{cuadrilatero.Borde.GetHashCode()}|{cuadrilatero.Relleno.GetHashCode()}";
        }
        public void Borrar(Cuadrilatero cuadrilatero)
        {

        }
    }
}

