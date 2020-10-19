using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using DataBase;

namespace Negocio
{
    [Table(Name = "Pagamentos")]
    public class Pagamento : DataBase.ADb
    {
        [Colum(PrimaryKey = true)]
        public int Id { get; set; }
        [Colum(Name = "ID_FORMA_PAGAMENTO")]
        public int IdFormaPagamento { get; set; }
        [Colum(Name = "DT_PAGAMENTO")]
        public DateTime DtPagamento { get; set; }
        [Colum(Name = "QTD_PARCELA")]
        public int QtdParcela { get; set; }
        [Colum(Name = "VL_PARCELA")]
        public double vLParcela { get; set; }
        [Colum(Name = "VL_TOTAL")]
        public double vLTotal { get; set; }

        public bool Valido()
        {
            return true;
        }
    }
}
