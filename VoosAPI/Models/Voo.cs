using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoosAPI.Models
{
    public class Voo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Cod_Empresa")]
        public string CodigoEmpresa { get; set; }

        [BsonElement("Empresa")]
        public string Empresa { get; set; }

        [BsonElement("N_Voo")]
        public string NumeroVoo { get; set; }

        [BsonElement("Equip")]
        public string Equipamento { get; set; }

        [BsonElement("Seg")]
        public string Segunda { get; set; }

        [BsonElement("Ter")]
        public string Terca { get; set; }

        [BsonElement("Qua")]
        public string Quarta { get; set; }

        [BsonElement("Qui")]
        public string Quinta { get; set; }

        [BsonElement("Sex")]
        public string Sexta { get; set; }

        [BsonElement("Sab")]
        public string Sabado { get; set; }

        [BsonElement("Dom")]
        public string Domingo { get; set; }

        [BsonElement("Quant_Assentos")]
        public string QuantidadeAssentos { get; set; }
        
        [BsonElement("N_SIROS")]
        public string NSiros { get; set; }
        
        [BsonElement("Situacao_SIROS")]
        public string SituacaoSiros { get; set; }
        
        [BsonElement("Data_Registro")]
        public string DataRegistro { get; set; }
        
        [BsonElement("Inicio_Operacao")]
        public string InicioOperacao { get; set; }

        [BsonElement("Fim_Operacao")]
        public string FimOperacao { get; set; }

        [BsonElement("Natureza_Operacao")]
        public string NaturezaOperacao { get; set; }

        [BsonElement("N_Etapa")]
        public string NEtapa { get; set; }

        [BsonElement("Cod_Origem")]
        public string CodigoOrigem { get; set; }

        [BsonElement("Arpt_Origem")]
        public string AeroportoOrigem { get; set; }

        [BsonElement("Cod_Destino")]
        public string CodigoDestino { get; set; }

        [BsonElement("Arpt_Destino")]
        public string AeroportoDestino { get; set; }

        [BsonElement("Horario_Partida")]
        public string HorarioPartida { get; set; }

        [BsonElement("Horario_Chegada")]
        public string HorarioChegada { get; set; }

        [BsonElement("Tipo_Servico")]
        public string TipoServico { get; set; }

        [BsonElement("Objeto_Transporte")]
        public string ObjetoTransporte { get; set; }

        [BsonElement("Codeshare")]
        public string Codeshare { get; set; }

        [BsonElement("Qtd_ocupado")]
        public string QuantidadeOcupado { get; set; }

    }
}
