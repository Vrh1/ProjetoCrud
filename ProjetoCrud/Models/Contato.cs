using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoCrud.Models
{
    public class Contato
    {
        public int IdContato { get; set; }
        public string Nomes { get; set; }
        public string SobreNome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}