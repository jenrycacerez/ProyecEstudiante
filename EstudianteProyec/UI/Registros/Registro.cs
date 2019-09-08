using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EstudianteProyec.DAL;




namespace EstudianteProyec.UI.Registros
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }
        public void limpiar()
        {
            EstudianteId.evalue = 0;
            Matricula.Textbox.text = string.Empty;
            NombreTextbox.Text = string.Empty;
            ApellidoTextbox.Text = string.Empty;
            CedulaTextbox.Text = string.Empty;
            TelefonoTextbox.Text = string.Empty;
            CelularTextbox.Text = string.Empty;
            EmailTextbox.Text = string.Empty;
            FechaNacimientoDateTimePicker.Value = DateTime.Now;



        }


        private void Nuevobutton1_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private Estudiante LlenaClase()
        {
            Estudiante estudiante = new Estudiante();
            estudiante.PersonaId = Convert.ToInt32(IDNumericUpDown.Value);
            estudiante.Nombre = NombreTextBox.Text;
            estudiante.Cedula = CedulamaskedTextBox.Text;
            estudiante.Direccion = DireccionTextBox.Text;
            estudiante.FechaNacimiento = FechaNacimientoDateTimePicker.Value;

            estudiante.Telefonos = this.Detalle;

            return estudiante;
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Guardarbutton3_Click(object sender, EventArgs e)
        {
            Estudiante estudiante;
            bool paso = false;

            if (!Validar())
                return;

            estudiante = LlenaClase();
            Limpiar();

            //Determinar si es guardar o modificar
            if (IDNumericUpDown.Value == 0)
                paso = EstudianteBll.Guardar(estudiante);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una persona que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = estudianteBll.Modificar(estudiante);
            }

            //Informar el resultado
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Estudiante persona = EstudianteBll.Buscar((int)IDNumericUpDown.Value);

            return (persona != null);
        }

        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (NombreTextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(NombreTextBox, "El campo Nombre no puede estar vacio");
                NombreTextBox.Focus();
                paso = false;
            }

            if (ApellidoTextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(ApellidoTextBox, "El campo Nombre no puede estar vacio");
                ApellidoTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(MatriculaTextBox.Text))
            {
                MyErrorProvider.SetError(MatriculaTextBox, "El campo Direccion no puede estar vacio");
                MatriculaTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CedulamaskedTextBox.Text.Replace("-", "")))
            {
                MyErrorProvider.SetError(CedulamaskedTextBox, "El campo Cedula no puede estar vacio");
                CedulamaskedTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CelularmaskedTextBox.Text.Replace("-", "")))
            {
                MyErrorProvider.SetError(CelularmaskedTextBox, "El campo Celular no puede estar vacio");
                CelularmaskedTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(SexomaskedTextBox.Text.Replace("-", "")))
            {
                MyErrorProvider.SetError(SexomaskedTextBox, "El campo sexo no puede estar vacio");
                SexomaskedTextBox.Focus();
                paso = false;
            }

            if (this.Detalle.Count == 0)
            {
                MyErrorProvider.SetError(detalleDataGridView, "Debe agregar algun telefono");
                TelefonomaskedTextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private void Buscarbutton1_Click(object sender, EventArgs e)
        {
            int id;
            Estudiante estudiante = new Estudiante();
            int.TryParse(IDNumericUpDown.Text, out id);

            Limpiar();

            estudiante = EstudianteBll.Buscar(id);

            if (estudiante != null)
            {
                MessageBox.Show("Persona Encontrada");
                LlenaCampo(estudiante);
            }
            else
            {
                MessageBox.Show("Persona no Encontada");
            }
        }

        private void Eliminarbutton2_Click(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();
            int id;
            int.TryParse(IDNumericUpDown.Text, out id);
            Limpiar();
            if (PersonasBll.Eliminar(id))
                MessageBox.Show("Eliminado");
            else
                MyErrorProvider.SetError(IDNumericUpDown, "No se puede eliminar una persona que no existe");
        }
    }
}
