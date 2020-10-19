using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using DataBase;

namespace Negocio
{
    [Table(Name = "Pessoas")]
    public class Pessoa : DataBase.ADb
    {
        [Colum(PrimaryKey = true)]
        public int Id { get; set; }
        [Validation(Presence = true)]
        public string Nome { get; set; }        
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        [Colum(Name = "DT_NASCIMENTO")] 
        public DateTime DtNascimento { get; set; }
        public string Fone { get; set; }

        [Colum(IsNotOnDataBase = true)]
        public string CEP { get; set; }

        public bool Valido()
        {
            return true;
        }

    }
}
