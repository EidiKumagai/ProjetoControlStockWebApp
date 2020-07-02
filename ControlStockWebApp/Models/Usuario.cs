using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStockWebApp.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId{ get; set; }
        [Required(ErrorMessage = "O login deve ser inserido.")]
        public string Login { get; set; }

        
        [Required(ErrorMessage = "A senha deve ser inserida.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
