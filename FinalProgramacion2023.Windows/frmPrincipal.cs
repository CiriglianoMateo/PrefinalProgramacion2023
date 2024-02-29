using FinalProgramacion2023.Datos;
using FinalProgramacion2023.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace FinalProgramacion2023.Windows
{
    public partial class frmPrincipal : Form
    {
        private List<Cuadrilatero> lista;
        private RepositorioDatos repositorio = new RepositorioDatos();
        private List<Cuadrilatero> Cuadrilaterolista;
        bool filterOn = false;
        int intValor;

        public frmPrincipal()
        {
            InitializeComponent();
            txtCantidad.Text = repositorio.GetCantidad().ToString();
            Cuadrilaterolista = repositorio.GetLista();
        }

        private void ActualizarCantidadRegistros()
        {
            ;
            if (intValor > 0)
            {
                txtCantidad.Text = repositorio.GetCantidad(intValor).ToString();
            }
            else
            {
                txtCantidad.Text = repositorio.GetCantidad().ToString();
            }
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
            r.Cells[colTipo.Index].Value = cuadrilatero.cuadrado;
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
            Cuadrilaterolista = repositorio.GetLista();
            var r = ConstruirFila();
            SetearFila(r, cuadrilatero);
            AgregarFila(r);
            txtCantidad.Text = repositorio.GetCantidad().ToString();
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("¿Desea borrar el cuadrilátero?",
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
            Cuadrilaterolista = repositorio.GetLista();
            txtCantidad.Text = repositorio.GetCantidad().ToString();

            QuitarFila(filaSeleccionada);
            MessageBox.Show("Registro borrado", "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void QuitarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Remove(r);
        }

        private void tsbFiltrar_Click(object sender, EventArgs e)
        {
            var stringValor = Microsoft.VisualBasic.Interaction.InputBox(
                "Ingrese el valor del área a filtrar",
                "Filtrar por mayor o igual",
                "0", 400, 400);
            if (!int.TryParse(stringValor, out int intValor))
            {
                return;
            }
            if (intValor <= 0)
            {
                return;
            }
            
            MostrarDatosEnGrilla();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            CargarDatosComboColores();
            MostrarDatosEnGrilla();
        }

        private void CargarDatosComboColores()
        {
            var listaRelleno = Enum.GetValues(typeof(Relleno)).Cast<Relleno>().ToList();
            foreach (var itemRelleno in listaRelleno)
            {
                tsbColor.Items.Add(itemRelleno);
            }
            tsbColor.SelectedIndex = -1;
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var filaSeleccionada = dgvDatos.SelectedRows[0];
            Cuadrilatero cuadrilatero = (Cuadrilatero)filaSeleccionada.Tag;
            int ladoAnteriorA = cuadrilatero.LadoA;
            int ladoAnteriorB = cuadrilatero.LadoB;

            frmCuadrilatero frm = new frmCuadrilatero() { Text = "Editar Cuadrilatero" };
            frm.SetCuadrilatero(cuadrilatero);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            cuadrilatero = frm.GetCuadrilatero();
            SetearFila(filaSeleccionada, cuadrilatero);
            MessageBox.Show("Registro modificado", "Mensaje", MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }

        private void porAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!filterOn)
            {
                var strigValor = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el valor", "Filtar por mayor o igual", "0", 400, 400);
                if (!int.TryParse(strigValor, out int intvalor))
                {
                    return;
                }
                if (intvalor <= 0)
                {
                    return;
                }
                lista = repositorio.Filtrar(intvalor);
                MostrarDatosEnGrilla();
            }
            else
            {
                MessageBox.Show("Filtro Aplicado!!!\nDebe actualizar la grilla",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void tsbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!filterOn)
            {
                if (tsbColor.SelectedIndex == -1)
                {
                    return;
                }
                var colorFiltro = (Relleno)tsbColor.SelectedItem;
                lista = repositorio.Filtrar(colorFiltro);
                MostrarDatosEnGrilla();
                filterOn = true;
                tsbFiltrar.BackColor = Color.Orange;
            }
        }

        private void ascendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lista = repositorio.OrdenarAsc();
            MostrarDatosEnGrilla();
        }

        private void descendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lista = repositorio.OrdenarDesc();
            MostrarDatosEnGrilla();
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            Cuadrilaterolista = repositorio.GetLista();
            MostrarDatosEnGrilla();
            ActualizarCantidadRegistros();
        }
    }
}

