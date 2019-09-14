using Microsoft.VisualStudio.TestTools.UnitTesting;
using EstudianteProyec.BiLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstudianteProyec.Entidades;

namespace EstudianteProyec.BiLL.Tests
{
    [TestClass()]
    public class EstudiantesBILLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Estudiante estudiante = new Estudiante();
            estudiante.EstudianteID = 0;
            estudiante.Cedula = "5667865685";
            paso = EstudiantesBILL.Guardar(estudiante);




            Assert.AreEqual(paso, true);

        }

        [TestMethod()]
        public void ModificarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarTest()
        {

            Assert.Fail();
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetlistTest()
        {
            Assert.Fail();
        }
    }
}