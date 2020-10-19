using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace DataBase
{
    public abstract class DbPedido : ADb
    {
        public override int Salvar()
        {
            if (ReservaVagaVooCliente())
            {
                return base.Salvar();
            }
            return 0;
        }

        public override void Alterar()
        {
            base.Alterar();
        }

        public override void Deletar()
        {
            base.Deletar();
        }

        public override List<ADb> Todos()
        {
            return base.Todos();
        }        

        public bool ReservaVagaVooCliente() //ADb dbVoo
        {
            //Chamar a API que busca e atualiza a vaga para o cliente solicitante
            return true;
        }
    }
}
