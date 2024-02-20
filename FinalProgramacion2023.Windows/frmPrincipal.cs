using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProgramacion2023.Datos;
using FinalProgramacion2023.Entidades;
using FinalProgramacion2023.Windows;
{

}

namespace FinalProgramacion2023.Windows
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }
        RepositorioDatos repositorio = new RepositorioDatos();
        List<Cuadrilatero> Cuadrilaterolista;
        private void frmCuadrilateroLoad(object sender, EventArgs e)
        {
            Cuadrilaterolista = repositorio.GetLista();
            MostrarDatosEnGrilla();

        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var cuadrilatero in Cuadrilaterolista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, cuadrilatero);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Cuadrilatero cuadrilatero)
        {
            r.Cells[colLadoA.Index].Value = cuadrilatero.LadoA;
            r.Cells[colLadoB.Index].Value = cuadrilatero.LadoB;
            r.Cells[colBorde.Index].Value = cuadrilatero.Borde;
            r.Cells[colRelleno.Index].Value = cuadrilatero.Relleno;
            r.Cells[colArea.Index].Value = cuadrilatero.GetArea();
            r.Cells[colPerimetro.Index].Value = cuadrilatero.GetPerimetro();

            r.Tag = cuadrilatero;
        }

        private DataGridViewRow ConstruirFila()
        {
            var r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmCuadrilatero frm = new frmCuadrilatero() { Text = "Nuevo formulario" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            Cuadrilatero cuadrilatero = frm.GetCuadrilatero();
            repositorio.Agregar(cuadrilatero);
            var r = ConstruirFila();
            SetearFila(r, cuadrilatero);
            AgregarFila(r);
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("¿Desea borrar el cuadrilatero?",
                "Confirmar baja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) 
            {
                return;
            }
            var filaSeleccionada = dgvDatos.SelectedRows[0];
            Cuadrilatero cuadrilatero = filaSeleccionada.Tag as Cuadrilatero;
            repositorio.Borrar(cuadrilatero);

            QuitarFila(filaSeleccionada);
            MessageBox.Show("Registro borrado", "Mensaje", MessageBoxButtons.OK,
    MessageBoxIcon.Information);
        }

        private void QuitarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Remove(r);
        }
    }
}
