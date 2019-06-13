using NPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inventario.Negocio.POCO
{
    [TableName("Categoria")]
    [PrimaryKey("Id")]

    public class Categoria
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }
}
