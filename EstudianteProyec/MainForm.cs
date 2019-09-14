using EstudianteProyec.UI.Consultas;
using EstudianteProyec.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstudianteProyec
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {//

        }

        private void RegistroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void RegistroEstudianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registro registroEstudiante = new Registro();
            registroEstudiante.MdiParent = this;
            registroEstudiante.Show();
        }

        private void RegistroInscripcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroIns registroIns = new RegistroIns();
            registroIns.MdiParent = this;
            registroIns.Show();
        }

        private void CosultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta consulta = new Consulta();
            consulta.MdiParent = this;
            consulta.Show();

        }
    }
}
