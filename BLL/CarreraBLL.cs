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
    public class CarreraBLL
    {
        public static bool Insertar( Carrera inseta)
        {
            bool paso = false;
            using (var contexto = new Contexto())
            {
                contexto.Carrera.Add(inseta);
                paso = contexto.SaveChanges() > 0;
            }
            return paso;
        }

       
        public static bool Editar(Carrera editar)
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
                var adicionales = contexto.Carrera.Find(id);

                if (adicionales != null)
                {
                    contexto.Carrera.Remove(adicionales); //remover la entidad
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
      
       
        public static bool Existe(Carrera te,int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            
             
            try
            {
                 encontrado = contexto.Carrera.Any(e => e.CarreraId== id);
                if(encontrado)
                {
                  
                  CarreraBLL.Editar(te);
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
                encontrado = contexto.Carrera.Any(e => e.CarreraId== id);
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
      
       public static List<Carrera> GetLista()
        {
            using (var contexto = new Contexto())
            {
                return contexto.Carrera.ToList();
            }
        }

         public static List<Carrera> GetList(Expression<Func<Carrera, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Carrera> lista = new List<Carrera>();
            try
            {
                lista = contexto.Carrera.Where(criterio).ToList();
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