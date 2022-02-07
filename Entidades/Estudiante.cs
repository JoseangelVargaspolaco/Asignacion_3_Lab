using System;
using System.Windows.Input;
using System.ComponentModel.DataAnnotations;

namespace trabajo_3.Entidades
{
    public class Estudiante
    {
        [Key]
        public int EstudianteId { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public int CarreraId { get; set; }

        public Estudiante(int estudianteId, string? nombre, string? email, int carreraId)
        {
            this.EstudianteId = estudianteId;
            this.CarreraId = carreraId;
            this.Nombre = nombre;
            this.Email = email;
        }
    }
}


