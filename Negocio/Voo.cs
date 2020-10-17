using System;
using System.Collections.Generic;
using DataBase;

namespace Negocio
{
    class Voo : DataBase.ADb
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int nVoo { get; set; }
        public DateTime DTHrSaida { get; set; }
        public DateTime DtHrChegada { get; set; }
        public double VlAdulto { get; set; }
        public double VlCrianca { get; set; }
        public int QtdMaxima { get; set; }
        public int QtdOcupada { get; set; }

        [Colum(IsNotOnDataBase = true)]
        public bool SnReservado { get; set; }

        [Colum(IsNotOnDataBase = true)]
        public Cliente cliente { get; set; }
    }
}
