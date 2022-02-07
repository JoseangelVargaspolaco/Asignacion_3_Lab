using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System;
using trabajo_3.Entidades;
using trabajo_3.DAL;
namespace trabajo_3.BLL
{
    public class EstudianteBLL
    {
        public static bool Insertar( Estudiante inseta)
        {
            bool paso = false;
            using (var contexto = new Contexto())
            {
                contexto.Estudiante.Add(inseta);
                paso = contexto.SaveChanges() > 0;
            }
            return paso;
        }

       
        public static bool Editar( Estudiante editar)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //marcar la entidad como modificada para que el contexto sepa como proceder
                contexto.Entry(editar).State = EntityState.Modified;
               paso = contexto.SaveChanges() > 0;
               

             
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool m = false;

            Contexto contexto = new Contexto();

            try
            {
                //buscar la entidad que se desea eliminar
                var adicionales = contexto.Estudiante.Find(id);

                if (adicionales != null)
                {
                    contexto.Estudiante.Remove(adicionales); //remover la entidad
                    m= contexto.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return m;
        }
      
       
        public static bool Existe(Estudiante te,int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            
             
            try
            {
                 encontrado = contexto.Estudiante.Any(e => e.EstudianteId== id);
                if(encontrado)
                {
                  
                  EstudianteBLL.Editar(te);
                }
               
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
         public static bool Existes(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Estudiante.Any(e => e.EstudianteId== id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
           public static List< Estudiante> GetLista()
        {
            using (var contexto = new Contexto())
            {
                return contexto.Estudiante.ToList();
            }
        }

         public static List<Estudiante> GetList(Expression<Func<Estudiante, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Estudiante> lista = new List<Estudiante>();
            try
            {
                lista = contexto.Estudiante.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
        
    }
    

}
      