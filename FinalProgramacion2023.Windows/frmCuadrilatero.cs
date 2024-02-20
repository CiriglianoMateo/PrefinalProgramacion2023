using FinalProgramacion2023.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace FinalProgramacion2023.Windows
{
    public partial class frmCuadrilatero : Form
    {
        public frmCuadrilatero()
        {
            InitializeComponent();
        }
        private Cuadrilatero cuadrilatero;
        List<Borde> listaBordes = Enum.GetValues(typeof(Borde)).Cast<Borde>().ToList();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarComboColores();
            CrearBordes();
        }

        private void CrearBordes()
        {

            int X = 19;
            int Y = 39;

            bool check = true;
            var listaBorde = Enum.GetValues(typeof(Borde)).Cast<Borde>().ToList();
            foreach (var itemborde in listaBorde)
            {
                RadioButton rb = new RadioButton
                {
                    Name = $"rbt{itemborde.ToString()}",
                    Text = itemborde.ToString(),
                    Location = new Point(X, Y),
                    Checked = check
                };
                groupBox1.Controls.Add(rb);
                Y += 38;
                check = false;
            }

        }

        private void CargarComboColores()
        {
            var listaRelleno = Enum.GetValues(typeof(Relleno))
            .Cast<Relleno>().ToList();
            cboRelleno.DataSource = listaRelleno;
            cboRelleno.SelectedIndex = 1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        public Cuadrilatero GetCuadrilatero()
        {
            return cuadrilatero;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                cuadrilatero = new Cuadrilatero();
                cuadrilatero.LadoB = int.Parse(txtLadoB.Text);
                cuadrilatero.LadoA = int.Parse(txtLadoA.Text);
                cuadrilatero.Relleno = (Relleno)cboRelleno.SelectedItem;
                cuadrilatero.Borde = ObtenerBorde();

                DialogResult = DialogResult.OK;
            }
        }

        private Borde ObtenerBorde()
        {
            Borde tipo = 0;
            foreach (var itemBorde in listaBordes)
            {
                var key = $"rbt{itemBorde.ToString()}";
                var rb = (RadioButton)groupBox1.Controls.Find(key, true)[0];
                if (rb.Checked)
                {
                    tipo = itemBorde;
                    break;
                }
            }
            return tipo;
        }

        private bool validarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (!int.TryParse(txtLadoA.Text, out int baseRect))
            {
                valido = false;
                errorProvider1.SetError(txtLadoA, "Lado no numerico!");
            }
            else if (baseRect <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtLadoB, "Lado no válida!!!");
            }
            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

