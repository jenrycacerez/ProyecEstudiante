using System;
using System.Windows.Forms;
using EstudianteProyec.BiLL;
using EstudianteProyec.BLL;
using EstudianteProyec.Entidades;


namespace EstudianteProyec.UI.Registros
{
    public partial class RegistroIns : Form
    {
        public RegistroIns()
        {
            InitializeComponent();
        }

        public void limpiar()
        {
            InscripcionId.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            EstudianteId.Value = 0;
            
            ComentarioTextBox.Text = string.Empty;
            
            Monto.Value = 0;
            Deposito.Value = 0;
            Balance.Value = 0;
            MyErrorProvider1.Clear();


            ///crear sexo con nombre  SEXOTextbox ese es el  nombre del boton
        }

        private void NumericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            InscripcionEstudiante insc = new InscripcionEstudiante();
            int.TryParse(InscripcionId.Text, out id);

            limpiar();

            insc = InscripcionBLL.Buscar(id);

            if (insc != null)
            {
                MessageBox.Show("Inscripcion Encontrada");
                LlenaClase(insc);

            }
            else
            {
                MessageBox.Show("Inscripcion no Encontada");
            }
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private InscripcionEstudiante LlenaClase()
        {
            InscripcionEstudiante insc = new InscripcionEstudiante();
            insc.InscripcionId = Convert.ToInt32 (insc.InscripcionId);
            insc.FechaIns = FechaDateTimePicker.Value;
            insc.EstudianteId = Convert.ToInt32(EstudianteId.Value);
            insc.Comentario = ComentarioTextBox.Text;
            insc.Monto = Convert.ToDecimal(Monto.Text);
            insc.Deposito = Convert.ToDecimal(Deposito.Text);
            insc.Balance = Convert.ToDecimal(Monto.Text) - Convert.ToDecimal(Deposito.Text);



            //estudiante.Telefono = this.TelefonoTextbox.Text; 

            return insc;
        }

        private InscripcionEstudiante LlenaClase(InscripcionEstudiante insc)
        {

            InscripcionId.Value = insc.InscripcionId;
            FechaDateTimePicker.Value = insc.FechaIns ;
            EstudianteId.Value = insc.EstudianteId;
            ComentarioTextBox.Text = insc.Comentario;
            Monto.Text = insc.Monto.ToString("N2");
            Deposito.Text = insc.Deposito.ToString("N2");
            Balance.Text = insc.Balance.ToString("N2");

            Balance.Value = Monto.Value - Deposito.Value;

            return insc;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            InscripcionEstudiante insc;
            bool paso = false;

            if (!Validar())
                return;

            insc = LlenaClase();
            

            //Determinar si es guardar o modificar
            if (InscripcionId.Value == 0)
            {
             
                paso = InscripcionBLL.Guardar(insc);
                Estudiante estudiante = new Estudiante();
                estudiante = EstudiantesBILL.Buscar(insc.EstudianteId);
                estudiante.Balance = estudiante.Balance + Monto.Value - Deposito.Value ;
                EstudiantesBILL.Modificar(estudiante);
                Balance.Value = Monto.Value - Deposito.Value;
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una persona que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //  insc.Balance = Monto.Value - decimal.Parse(Deposito.Value.ToString());

                InscripcionEstudiante  iestudiante = new InscripcionEstudiante();
                iestudiante = InscripcionBLL.Buscar(int.Parse(InscripcionId.Value.ToString()));

                decimal viejobalance = iestudiante.Balance;
                iestudiante.Comentario = ComentarioTextBox.Text;
                iestudiante.Monto = Convert.ToDecimal(Monto.Text);
                iestudiante.Deposito = Convert.ToDecimal(Deposito.Text);
                iestudiante.Balance = Convert.ToDecimal(Monto.Text) - Convert.ToDecimal(Deposito.Text);


                paso = InscripcionBLL.Modificar(iestudiante);
                
                Estudiante estudiante = new Estudiante();
                estudiante = EstudiantesBILL.Buscar(insc.EstudianteId);
                estudiante.Balance = estudiante.Balance  - viejobalance + iestudiante.Balance;
                EstudiantesBILL.Modificar(estudiante);

                Balance.Value = Monto.Value - Deposito.Value;

            }

            //Informar el resultado
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool ExisteEnLaBaseDeDatos()
        {
           InscripcionEstudiante insc = InscripcionBLL.Buscar((int)InscripcionId.Value);

            return (insc != null);
        }

        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(InscripcionId.Text))
            {
                MyErrorProvider1.SetError(InscripcionId, "El campo Direccion no puede estar vacio");
                InscripcionId.Focus();
                paso = false;
            }

           

            if (string.IsNullOrWhiteSpace(FechaDateTimePicker.Text))
            {
                MyErrorProvider1.SetError(FechaDateTimePicker, "El campo Fecha de nacimiento no puede estar vacio");
                FechaDateTimePicker.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(EstudianteId.Text))
            {
                MyErrorProvider1.SetError(EstudianteId, "El campo Direccion no puede estar vacio");
                EstudianteId.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(ComentarioTextBox.Text))
            {
                MyErrorProvider1.SetError(ComentarioTextBox, "El campo Email no puede estar vacio");
                ComentarioTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(Monto.Text))
            {
                MyErrorProvider1.SetError(Monto, "El campo Balance no puede estar vacio");
                Monto.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(Deposito.Text))
            {
                MyErrorProvider1.SetError(Deposito, "El campo Balance no puede estar vacio");
                Deposito.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(Balance.Text))
            {
                MyErrorProvider1.SetError(Balance, "El campo Balance no puede estar vacio");
                Balance.Focus();
                paso = false;
            }


            return paso;
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            MyErrorProvider1.Clear();
            int id;
            int.TryParse(EstudianteId.Text, out id);
            limpiar();
            if (EstudiantesBILL.Eliminar(id))
                MessageBox.Show("Eliminado");
            else
                MyErrorProvider1.SetError(EstudianteId, "No se puede eliminar una persona que no existe");
        }

        private void EstudianteId_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Monto_ValueChanged(object sender, EventArgs e)
        {

        }
    }

}
