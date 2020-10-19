using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace DataBase
{
    public abstract class DbPessoa : ADb
    {
        public override int Salvar()
        {
            return base.Salvar();
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

        public ADb ConsultarPessoaCPF(string cpf)
        {
            TableAttribute tableAttribute = this.GetType().GetCustomAttribute<TableAttribute>();
            string nomeTabela = tableAttribute != null && !string.IsNullOrEmpty(tableAttribute.Name) ? tableAttribute.Name : this.GetType().Name;
            string queryString = $"SELECT * FROM PESSAOS where CPF = '{cpf}';";

            using (SqlConnection connection = new SqlConnection(STRING_CNN))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var newAbb = (ADb)Activator.CreateInstance(this.GetType());

                while (reader.Read())
                {

                    foreach (var p in this.GetType().GetProperties())
                    {
                        ColumAttribute columAttribute = p.GetCustomAttribute<ColumAttribute>();
                        if (columAttribute != null && columAttribute.IsNotOnDataBase) continue;

                        string nomeColunaTabela = columAttribute != null && !string.IsNullOrEmpty(columAttribute.Name) ? columAttribute.Name : p.Name;

                        if (p.GetValue(this) == null) continue;

                        //if ((reader[nomeColunaTabela] == DBNull.Value) || (columAttribute.PrimaryKey))  continue;

                        p.SetValue(newAbb, reader[nomeColunaTabela]);
                    }
                }

                reader.Close();
                connection.Close();

                return newAbb;
            }
        }
    }
}
