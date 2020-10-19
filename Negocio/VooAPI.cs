using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Negocio
{
    public class VooAPI
    {
        //[BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CodigoEmpresa { get; set; }
        public string Empresa { get; set; }
        public string NumeroVoo { get; set; }
        public string Equipamento { get; set; }
        public string Segunda { get; set; }
        public string Terca { get; set; }
        public string Quarta { get; set; }
        public string Quinta { get; set; }
        public string Sexta { get; set; }
        public string Sabado { get; set; }
        public string Domingo { get; set; }
        public string QuantidadeAssentos { get; set; }
        public string NSiros { get; set; }
        public string SituacaoSiros { get; set; }
        public string DataRegistro { get; set; }
        public string InicioOperacao { get; set; }
        public string FimOperacao { get; set; }
        public string NaturezaOperacao { get; set; }
        public string NEtapa { get; set; }
        public string CodigoOrigem { get; set; }
        public string AeroportoOrigem { get; set; }
        public string CodigoDestino { get; set; }
        public string AeroportoDestino { get; set; }
        public string HorarioPartida { get; set; }
        public string HorarioChegada { get; set; }
        public string TipoServico { get; set; }
        public string ObjetoTransporte { get; set; }
        public string Codeshare { get; set; }
        public string QuantidadeOcupado { get; set; }
    }
}
