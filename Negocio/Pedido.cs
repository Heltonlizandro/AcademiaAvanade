﻿using System;
using DataBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Negocio
{
    [DataBase.Table(Name = "Pedidos")]
    public class Pedido : DataBase.DbPedido
    {
        [Colum(PrimaryKey = true)]
        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        [ForeignKey("Id_pessoa")]
        public int Id_Pessoa { get; set; }
        public string Id_Voo { get; set; }
        public int Id_Pagamento { get; set; }
        public DateTime Dt_Reserva { get; set; }
        public DateTime? Dt_Cancelado { get; set; }
        public string Status { get; set; }
        //public int Dias_Reservado { get; set; }
        public decimal Vl_Passagem { get; set; }
    }
}
