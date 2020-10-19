using System;
using System.Collections.Generic;
using DataBase;

namespace Negocio
{
    [Table(Name = "Voos")]
    public class Voo : DataBase.ADb
    {
        [Colum(PrimaryKey = true)]
        public string Id { get; set; }
        [Colum(Name = "COD_EMPRESA")]
        public string CodEmpresa { get; set; }
        public string Empresa { get; set; }
        [Colum(Name = "N_VOO")]
        public string nVoo { get; set; }
        [Colum(Name = "QUANT_ASSENTOS")]
        public int QtdMaxima { get; set; }
        [Colum(Name = "QUANT_OCUPADOS")]
        public int QtdOcupada { get; set; }
        [Colum(Name = "COD_ORIGEM")]
        public string CodOrigem { get; set; }
        [Colum(Name = "DESC_ORIGEM")]
        public string DescOrigem { get; set; }
        [Colum(Name = "COD_DESTINO")]
        public string CodDestino { get; set; }
        [Colum(Name = "DESC_DESTINO")]
        public string DescDestino { get; set; }
        [Colum(Name = "HORA_PARTIDA")]
        public string HoraPartida { get; set; }
        [Colum(Name = "VL_ADULTO")]
        public decimal VlAdulto { get; set; }
        [Colum(Name = "VL_CRIANCA")]
        public decimal VlCrianca { get; set; }
        [Colum(Name = "INICIO_OPERACAO")]
        public DateTime InicioOperacao { get; set; }
        [Colum(Name = "FIM_OPERACAO")]
        public DateTime FimOperacao { get; set; }


        [Colum(IsNotOnDataBase = true)]
        public bool SnReservado { get; set; }

        [Colum(IsNotOnDataBase = true)]
        public decimal vlVoo
        {
            get
            {
                if (pessoa != null)
                {
                    return (DateTime.Now.Year - pessoa.DtNascimento.Year) > 12 ? VlAdulto : VlCrianca;
                }
                else { return 0; }
            }
        }

        [Colum(IsNotOnDataBase = true)]
        public Pessoa pessoa { get; set; }
    }
}
