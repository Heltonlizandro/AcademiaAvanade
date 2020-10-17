using System;
using DataBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Negocio
{
    [DataBase.Table(Name = "Pedidos_Voo")]
    public class PedidoVoo : DataBase.DbPedidoVoo
    {
        [Colum(PrimaryKey = true)]
        public int Id { get; set; }
        [ForeignKey("Id_pessoa")]
        public int Id_Pessoa { get; set; }
        public int Id_Voo { get; set; }
        public string Status { get; set; }
        public DateTime Dt_Reservado { get; set; }
        public DateTime? Dt_Cancelado { get; set; }
        public int Dias_Reservado { get; set; }
        public double Vl_Passagem { get; set; }
    }
}
