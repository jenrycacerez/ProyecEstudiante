using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EstudianteProyec.BiLL;
using EstudianteProyec.DAL;
using EstudianteProyec.Entidades;



namespace EstudianteProyec.UI.Registros
{
    public partial class Registro : Form
    {
        private object estudianteBll;

        public Registro()
        {
            InitializeComponent();
        }
        public void limpiar()
        {
            EstudianteId.Value = 0;
            MatriculaTextBox.Text = string.Empty;
            NombreTextbox.Text = string.Empty;
            ApellidoTextbox.Text = string.Empty;
            CedulaTextbox.Text = string.Empty;
            TelefonoTextbox.Text = string.Empty;
            CelularTextbox.Text = string.Empty;
            EmailTextbox.Text = string.Empty;
            FechaNacimientoDateTimePicker.Value = DateTime.Now;
            SexoComboBox.Text = string.Empty;
            BalanceTextBox.Text = string.Empty;
            MyerrorProvider.Clear();

            ///crear sexo con nombre  SEXOTextbox ese es el  nombre del boton
        }


        private void Nuevobutton1_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private Estudiante LlenaClase()
        {
            Estudiante estudiante = new Estudiante();
            estudiante.EstudianteID = Convert.ToInt32(EstudianteId.Value);
            estudiante.Matricula = MatriculaTextBox.Text;
            estudiante.Nombre = NombreTextbox.Text;
            estudiante.Apellido = ApellidoTextbox.Text;
            estudiante.Cedula = CedulaTextbox.Text;
            estudiante.Telefono = TelefonoTextbox.Text;
            estudiante.Celular = CelularTextbox.Text;
            estudiante.Email = EmailTextbox.Text;
            estudiante.FechaNacimiento = FechaNacimientoDateTimePicker.Value;
            estudiante.Sexo = SexoComboBox.SelectedIndex;
            estudiante.Balance = Convert.ToDecimal(BalanceTextBox.Text);

           

            return estudiante;
        }

        private Estudiante LlenaClase(Estudiante estudiante)
        {

            EstudianteId.Value = estudiante.EstudianteID;
            MatriculaTextBox.Text = estudiante.Matricula;
            NombreTextbox.Text = estudiante.Nombre;
            ApellidoTextbox.Text = estudiante.Apellido;
            CedulaTextbox.Text = estudiante.Cedula;
            TelefonoTextbox.Text = estudiante.Telefono;
            if (estudiante.Celular != null)
            {
                CelularTextbox.Text = estudiante.Celular.ToString();
            }
            EmailTextbox.Text = estudiante.Email;
            FechaNacimientoDateTimePicker.Value = estudiante.FechaNacimiento;
            SexoComboBox.SelectedIndex = (int)estudiante.Sexo;
            BalanceTextBox.Text = estudiante.Balance.ToString("N2");

            //estudiante.Telefono = this.TelefonoTextbox.Text; 

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
            

            //Determinar si es guardar o modificar
            if (EstudianteId.Value == 0)
                paso = EstudiantesBILL.Guardar(estudiante);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una persona que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
              
              
         

                estudiante = new Estudiante();
                estudiante = EstudiantesBILL.Buscar(Convert.ToInt32(EstudianteId.Value));
                estudiante.Matricula = MatriculaTextBox.Text;
                estudiante.Nombre = NombreTextbox.Text;
                estudiante.Apellido = ApellidoTextbox.Text;
                estudiante.Cedula = CedulaTextbox.Text;
                estudiante.Telefono = TelefonoTextbox.Text;
                estudiante.Celular = CelularTextbox.Text;
                estudiante.Email = EmailTextbox.Text;
                estudiante.FechaNacimiento = FechaNacimientoDateTimePicker.Value;
                estudiante.Sexo = SexoComboBox.SelectedIndex;
                estudiante.Balance = Convert.ToDecimal(BalanceTextBox.Text);
             
                paso = EstudiantesBILL.Modificar(estudiante);
            }

            limpiar();
            //Informar el resultado
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Estudiante persona = EstudiantesBILL.Buscar((int)EstudianteId.Value);

            return (persona != null);
        }

        private bool Validar()
        {
            bool paso = true;
            MyerrorProvider.Clear();

            if (string.IsNullOrWhiteSpace(MatriculaTextBox.Text))
            {
                MyerrorProvider.SetError(MatriculaTextBox, "El campo Direccion no puede estar vacio");
                MatriculaTextBox.Focus();
                paso = false;
            }

            if (NombreTextbox.Text == string.Empty)
            {
                MyerrorProvider.SetError(NombreTextbox, "El campo Nombre no puede estar vacio");
                NombreTextbox.Focus();
                paso = false;
            }

            if (ApellidoTextbox.Text == string.Empty)
            {
                MyerrorProvider.SetError(ApellidoTextbox, "El campo Nombre no puede estar vacio");
                ApellidoTextbox.Focus();
                paso = false;
            }



            if (string.IsNullOrWhiteSpace(CedulaTextbox.Text.Replace("-", "")))
            {
                MyerrorProvider.SetError(CedulaTextbox, "El campo Cedula no puede estar vacio");
                CedulaTextbox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(TelefonoTextbox.Text.Replace("-", "")))
            {
                MyerrorProvider.SetError(TelefonoTextbox, "El campo Telefono no puede estar vacio");
                TelefonoTextbox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CelularTextbox.Text.Replace("-", "")))
            {
                MyerrorProvider.SetError(CelularTextbox, "El campo Celular no puede estar vacio");
                CelularTextbox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(EmailTextbox.Text))
            {
                MyerrorProvider.SetError(EmailTextbox, "El campo Email no puede estar vacio");
                EmailTextbox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(FechaNacimientoDateTimePicker.Text))
            {
                MyerrorProvider.SetError(FechaNacimientoDateTimePicker, "El campo Fecha de nacimiento no puede estar vacio");
                FechaNacimientoDateTimePicker.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(SexoComboBox.Text))
            {
                MyerrorProvider.SetError(SexoComboBox, "El campo Sexo no puede estar vacio");
                SexoComboBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(BalanceTextBox.Text))
            {
                MyerrorProvider.SetError(BalanceTextBox, "El campo Balance no puede estar vacio");
                BalanceTextBox.Focus();
                paso = false;
            }


            return paso;
        }

        private void Buscarbutton1_Click(object sender, EventArgs e)
        {
            int id;
            Estudiante estudiante = new Estudiante();
            int.TryParse(EstudianteId.Text, out id);

            limpiar();

            estudiante = EstudiantesBILL.Buscar(id);

            if (estudiante != null)
            {
                MessageBox.Show("Persona Encontrada");
                LlenaClase(estudiante);
            }
            else
            {
                MessageBox.Show("Persona no Encontada");
            }
        }

        private void Eliminarbutton2_Click(object sender, EventArgs e)
        {
            MyerrorProvider.Clear();
            int id;
            int.TryParse(EstudianteId.Text, out id);
            limpiar();
            if (EstudiantesBILL.Eliminar(id))
                MessageBox.Show("Eliminado");
            else
                MyerrorProvider.SetError(EstudianteId, "No se puede eliminar una persona que no existe");
        }
    }
}
