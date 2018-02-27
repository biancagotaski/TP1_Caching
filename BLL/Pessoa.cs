using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstApplication.Domain
{
    public class Pessoa
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public DateTime Nascimento { get; set; }

        public string Email { get; set; }

        public bool IsChecked { get; set; }

    }
}