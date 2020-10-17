using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using DataBase;

namespace Negocio
{
    [Table(Name = "Clientes")]
    public class Cliente : DataBase.ADb
    {
        [Colum(PrimaryKey = true)]
        public int Id { get; set; }
        public string Login { get; set; }        
        public string Senha { get; set; }
        [Colum(IsNotOnDataBase = true)]
        public string CEP { get; set; }
    }
}
