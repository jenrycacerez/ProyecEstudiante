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
using EstudianteProyec.Entidades;



namespace EstudianteProyec.UI.Consultas
{
    public partial class Consulta : Form
    {
        public object EstudianteBill { get; private set; }

        public Consulta()
        {
            InitializeComponent();
        }

        private void Consulta_Load(object sender, EventArgs e)
        {

        }

        private void ConsultaButton_Click(object sender, EventArgs e)
        {
            var listado = new List<Estudiante>();
            
            if(CriterioTextBox.Text.Trim().Length > 0)
            {
                switch(FiltrarComboBox.SelectedIndex)
                {
                    case 0://todo
                        listado = EstudiantesBILL.GetList(p => true);
                        break;

                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = EstudiantesBILL.GetList(p => p.EstudianteID == id);
                        break;

                    case 2://Matricula
                        listado = EstudiantesBILL.GetList(p => p.Matricula.Contains(CriterioTextBox.Text));
                        break;

                    case 3://Nombre
                        listado = EstudiantesBILL.GetList(p => p.Nombre.Contains(CriterioTextBox.Text));
                        break;

                    case 4://Apellido
                        listado = EstudiantesBILL.GetList(p => p.Apellido.Contains(CriterioTextBox.Text));
                        break;

                    case 5://Cedula
                        listado = EstudiantesBILL.GetList(p => p.Cedula.Contains(CriterioTextBox.Text));
                        break;

                    case 6://Telefono
                        listado = EstudiantesBILL.GetList(p => p.Telefono.Contains(CriterioTextBox.Text));
                        break;

                    case 7://Celular
                        listado = EstudiantesBILL.GetList(p => p.Celular.ToString().Contains(CriterioTextBox.Text));
                        break;

                    case 8://Email
                        listado = EstudiantesBILL.GetList(p => p.Email.Contains(CriterioTextBox.Text));
                        break;


                    case 9://Sexo
                        int intse = 0;
                        if (CriterioTextBox.Text.ToString().ToLower().Contains("masculino"))
                        {
                             intse = 0;

                        }
                        else intse = 1;

                        listado = EstudiantesBILL.GetList(p => p.Sexo == intse);
                        break;

                    case 10://Balance
                        listado = EstudiantesBILL.GetList(p => p.Balance.ToString().Contains(CriterioTextBox.Text));
                        break;




                }

                listado = listado.Where(c => c.FechaNacimiento.Date >= DesdeDateTimePicker.Value.Date && c.FechaNacimiento.Date <= HastaDateTimePicker.Value.Date).ToList();
            }
            else
            {
                listado = EstudiantesBILL.GetList(p => true);
            }

            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = listado;



        

            
        }
    }
}

