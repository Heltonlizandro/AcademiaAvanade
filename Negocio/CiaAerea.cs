using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using DataBase;

namespace Negocio
{
    [Table(Name = "Cias_Aereas")]
    public class CiaAerea : DataBase.ADb
    {
        [Colum(PrimaryKey = true)]
        public string Id { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        [Colum(Name = "NACIONAL_ESTRANGEIRA")]        
        public string Nacionalidade { get; set; }

        //[Validation(Presence = true)]
        //[Colum(IsNotOnDataBase = true)]
    }
}
