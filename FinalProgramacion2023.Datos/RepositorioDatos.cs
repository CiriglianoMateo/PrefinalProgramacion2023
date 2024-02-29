using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FinalProgramacion2023.Entidades;

namespace FinalProgramacion2023.Datos
{
    public class RepositorioDatos
    {
        private readonly string _archivo = Environment.CurrentDirectory + "\\Cuadrilatero.txt";


        private List<Cuadrilatero> listaCuadrilateros;

        public RepositorioDatos()
        {
            listaCuadrilateros = new List<Cuadrilatero>();
            LeerDatosArchivo();
        }

        private void LeerDatosArchivo()
        {
            if (File.Exists(_archivo))
            {
                var lector = new StreamReader(_archivo);
                
                    while (!lector.EndOfStream)
                    {
                        string lineaLeida = lector.ReadLine();
                        Cuadrilatero cuadrilatero = ConstruirCuadrilatero(lineaLeida);
                        listaCuadrilateros.Add(cuadrilatero);
                    }
                    lector.Close();
            }
        }
        public List<Cuadrilatero> GetLista() => listaCuadrilateros;

       

    private Cuadrilatero ConstruirCuadrilatero(string lineaLeida)
        {
            var campos = lineaLeida.Split("|");
            var LadoACuadrilatero = int.Parse(campos[0]);
            var LadoBCuadrilatero = int.Parse(campos[1]);
            var bordeCuadrilatero = (Borde)int.Parse(campos[2]);
            var Rellenocuadrilatero = (Relleno)int.Parse(campos[3]);

            return new Cuadrilatero
            {
                LadoA = LadoACuadrilatero,
                LadoB = LadoBCuadrilatero,
                Borde = bordeCuadrilatero,
                Relleno = Rellenocuadrilatero
            };
        }

        public void Agregar(Cuadrilatero cuadrilatero)
        {
            using (var escritor = new StreamWriter(_archivo, true))
            {
                string lineaEscribir = ConstruirLinea(cuadrilatero);
                escritor.WriteLine(lineaEscribir);
            }
            listaCuadrilateros.Add(cuadrilatero);
        }

        private string ConstruirLinea(Cuadrilatero cuadrilatero)
        {
            return $"{cuadrilatero.LadoA}|{cuadrilatero.LadoB}|{cuadrilatero.Borde.GetHashCode()}|{cuadrilatero.Relleno.GetHashCode()}";
        }

        public int GetCantidad(int valorFiltro = 0)
        {
            if (valorFiltro > 0)
            {
                return listaCuadrilateros.Count(c => c.LadoA >= valorFiltro || c.LadoB >= valorFiltro);
            }
            else
            {
                return listaCuadrilateros.Count;
            }
        }

        public void Borrar(Cuadrilatero cuadrilatero)
        {
            listaCuadrilateros.Remove(cuadrilatero);
            ActualizarArchivo();
        }

        private void ActualizarArchivo()
        {
            File.WriteAllLines(_archivo, listaCuadrilateros.Select(ConstruirLinea));
        }

        public List<Cuadrilatero> Filtrar(int intvalor)
        {
            return listaCuadrilateros
                .Where(c=>c.GetArea() >= intvalor)
                .ToList();
        }

        public List<Cuadrilatero> Filtrar(Relleno colorFiltro)
        {
            return listaCuadrilateros.Where(C=>C.Relleno == colorFiltro).ToList();
        }

        public List<Cuadrilatero> OrdenarAsc()
        {
            return listaCuadrilateros.OrderBy(c=>c.GetPerimetro()).ToList();
        }

        public List<Cuadrilatero> OrdenarDesc()
        {
            return listaCuadrilateros.OrderByDescending(C=>C.GetPerimetro()).ToList();
        }
    }
}



