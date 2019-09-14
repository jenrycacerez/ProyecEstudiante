using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstudianteProyec.Entidades;
using System.Data.Entity;
using  EstudianteProyec.DAL.Scripts;
using System.Linq.Expressions;

namespace EstudianteProyec.BLL
{
    class InscripcionBLL
    {
        public static bool Guardar(InscripcionEstudiante Insc)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.InscripcionEstudiante.Add(Insc) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;

        }

        public static bool Modificar(InscripcionEstudiante insc)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(insc).State = EntityState.Modified;
                
                paso = (db.SaveChanges() > 0);
            }

            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;


        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.InscripcionEstudiante.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;

                paso = (db.SaveChanges() > 0);
            }

            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;

        }

        public static InscripcionEstudiante Buscar(int id)
        {
            Contexto db = new Contexto();
            InscripcionEstudiante insc = new InscripcionEstudiante();
            try
            {
                insc = db.InscripcionEstudiante.FirstOrDefault(p => p.InscripcionId == id);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return insc;

        }

        public static List<InscripcionEstudiante> GetList(Expression<Func<InscripcionEstudiante, bool>> insc)
        {
            List<InscripcionEstudiante> Lista = new List<InscripcionEstudiante>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.InscripcionEstudiante.Where(insc).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;


        }

        public static List<InscripcionEstudiante> Getlist(Expression<Func<InscripcionEstudiante, bool>> Insc)
        {
            List<InscripcionEstudiante> Lista = new List<InscripcionEstudiante>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.InscripcionEstudiante.Where(Insc).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;

        }
    }
}