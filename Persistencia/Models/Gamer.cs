using System;
namespace Persistencia.Model
{
    public class Gamer 
    {
        public Gamer()
        {           
        }       
        public string Name { get; set; }
        public int Amount { get; set; }

        #region Auditable
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? UsuarioCreacion { get; set; }
        public int? UsuarioModificacion { get; set; }
        #endregion Auditable
    }
}