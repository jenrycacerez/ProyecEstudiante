using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity; 
using EstudianteProyec.Entidades;
using System.Linq.Expressions;
using EstudianteProyec.DAL;
using EstudianteProyec.DAL.Scripts;


namespace EstudianteProyec.BLL
{
    public class EstudiantesBILL
    {
        public static bool Guardar(Estudiante estudiante)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Estudiante.Add(estudiante) != null)
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

        public static bool Modificar(Estudiante estudiante)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(estudiante).State = EntityState.Modified;
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
                var eliminar = db.Estudiante.Find(id);
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

        public static Estudiante Buscar(int id)
        {
            Contexto db = new Contexto();
            Estudiante estudiante = new Estudiante();
            try
            {
                estudiante = db.Estudiante.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return estudiante;
            
        }
        public static List<Estudiante> GetList(Expression<Func<Estudiante, bool>> estudiante)
        {
            List<Estudiante> Lista = new List<Estudiante>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.Estudiante.Where(estudiante).ToList();
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

        public static List<Estudiante>Getlist(Expression<Func<Estudiante, bool>> estudiante)
        {
            List<Estudiante> Lista = new List<Estudiante>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.Estudiante.Where(estudiante).ToList();
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

       

    

