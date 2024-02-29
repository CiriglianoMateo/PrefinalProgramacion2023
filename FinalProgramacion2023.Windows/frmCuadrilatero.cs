using FinalProgramacion2023.Datos;
using FinalProgramacion2023.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FinalProgramacion2023.Windows
{
    public partial class frmCuadrilatero : Form
    {
        private Cuadrilatero cuadrilatero;
        private List<Borde> listaBordes = Enum.GetValues(typeof(Borde)).Cast<Borde>().ToList();

        public frmCuadrilatero()
        {
            InitializeComponent();
            CrearBordes();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (cuadrilatero != null )
            {
                base.OnLoad(e);
                if (cuadrilatero != null)
                {
                    txtLadoA.Text = cuadrilatero.LadoA.ToString();
                    txtLadoB.Text = cuadrilatero.LadoB.ToString();
                }

            }
            CargarComboColores();
        }

        private void CrearBordes()
        {
            int X = 60;
            int Y = 35;
            bool check = true;
            foreach (var itemborde in listaBordes)
            {
                RadioButton rb = new RadioButton
                {
                    Name = $"rbt{itemborde.ToString()}",
                    Text = itemborde.ToString(),
                    Location = new Point(X, Y),
                    Checked = check
                };
                groupBox1.Controls.Add(rb);
                Y += 34;
                check = false;
            }
        }

        private void CargarComboColores()
        {
            var listaRelleno = Enum.GetValues(typeof(Relleno)).Cast<Relleno>().ToList();
            cboRelleno.DataSource = listaRelleno;
            cboRelleno.SelectedIndex = 1;
        }

        public Cuadrilatero GetCuadrilatero()
        {
            return cuadrilatero;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (cuadrilatero == null) 
                {
                    cuadrilatero = new Cuadrilatero();
                }
                cuadrilatero = new Cuadrilatero();
                cuadrilatero.LadoA = int.Parse(txtLadoA.Text);
                cuadrilatero.LadoB = int.Parse(txtLadoB.Text);
                cuadrilatero.Relleno = (Relleno)cboRelleno.SelectedItem;
                cuadrilatero.Borde = ObtenerBorde();
                DialogResult = DialogResult.OK;
            }
        }

        private Borde ObtenerBorde()
        {
            foreach (var itemBorde in listaBordes)
            {
                var key = $"rbt{itemBorde.ToString()}";
                var rb = (RadioButton)groupBox1.Controls.Find(key, true)[0];
                if (rb.Checked)
                {
                    return itemBorde;
                }
            }
            return Borde.Lineal; // Valor por defecto
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (!int.TryParse(txtLadoA.Text, out int ladoA))
            {
                valido = false;
                errorProvider1.SetError(txtLadoA, "Lado no numérico!");
            }
            else if (ladoA <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtLadoA, "Lado no válido!");
            }

            if (!int.TryParse(txtLadoB.Text, out int ladoB))
            {
                valido = false;
                errorProvider1.SetError(txtLadoB, "Lado no numérico!");
            }
            else if (ladoB <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtLadoB, "Lado no válido!");
            }
            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void SetCuadrilatero(Cuadrilatero? cuadrilatero)
        {
            this.cuadrilatero = cuadrilatero;
        }
    }
}


