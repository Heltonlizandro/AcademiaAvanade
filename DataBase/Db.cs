using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace DataBase
{
    public class Db : IDbs
    {
        private const string STRING_CNN = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=PROJETO_AVANADE;Data Source=DESKTOP-E7ICRAI\SQLEXPRESS";

        public ADb ConsultaById(ADb aDb, string id)
        {

            TableAttribute tableAttribute = aDb.GetType().GetCustomAttribute<TableAttribute>();
            string nomeTabela = tableAttribute != null && !string.IsNullOrEmpty(tableAttribute.Name) ? tableAttribute.Name : aDb.GetType().Name;
            string queryString = $"SELECT * FROM {nomeTabela} where id = '{id}';";

            using (SqlConnection connection = new SqlConnection(STRING_CNN))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var newAbb = (ADb)Activator.CreateInstance(aDb.GetType());

                while (reader.Read())
                {

                    foreach (var p in aDb.GetType().GetProperties())
                    {
                        ColumAttribute columAttribute = p.GetCustomAttribute<ColumAttribute>();
                        if (columAttribute != null && columAttribute.IsNotOnDataBase) continue;

                        string nomeColunaTabela = columAttribute != null && !string.IsNullOrEmpty(columAttribute.Name) ? columAttribute.Name : p.Name;
                        
                        if (p.GetValue(aDb) == null) continue;

                        //if ((reader[nomeColunaTabela] == DBNull.Value) || (columAttribute.PrimaryKey))  continue;

                        p.SetValue(newAbb, reader[nomeColunaTabela]);

                    }
                }

                reader.Close();
                connection.Close();

                return newAbb;
            }
        }
        public List<ADb> Todos(ADb aDb)
        {
            TableAttribute tableAttribute = aDb.GetType().GetCustomAttribute<TableAttribute>();
            string nomeTabela = tableAttribute != null && !string.IsNullOrEmpty(tableAttribute.Name) ? tableAttribute.Name : aDb.GetType().Name;
            string queryString = $"SELECT * FROM {nomeTabela};";

            using (SqlConnection connection = new SqlConnection(STRING_CNN))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();

                var adbs = new List<ADb>();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var newAbb = (ADb)Activator.CreateInstance(aDb.GetType());
                    foreach (var p in aDb.GetType().GetProperties())
                    {
                        ColumAttribute columAttribute = p.GetCustomAttribute<ColumAttribute>();
                        if (columAttribute != null && columAttribute.IsNotOnDataBase) continue;

                        string nomeColunaTabela = columAttribute != null && !string.IsNullOrEmpty(columAttribute.Name) ? columAttribute.Name : p.Name;

                        if (reader[nomeColunaTabela] == DBNull.Value) continue;

                        p.SetValue(newAbb, reader[nomeColunaTabela]);
                    }

                    adbs.Add(newAbb);
                }

                reader.Close();
                connection.Close();

                return adbs;
            }
        }

        public int Salvar(ADb aDb)
        {
            using (SqlConnection connection = new SqlConnection(STRING_CNN))
            {
                try
                {
                    //var chavePk = ""; 
                    var colunas = new List<string>();
                    var valores = new List<object>();
                    foreach (var p in aDb.GetType().GetProperties())
                    {
                        ColumAttribute columAttribute = p.GetCustomAttribute<ColumAttribute>();
                        if (p.GetValue(aDb) == null) continue;
                        if (columAttribute != null /*&& (columAttribute.PrimaryKey*/ || columAttribute.IsNotOnDataBase) continue;

                        string nomeColunaTabela = columAttribute != null && !string.IsNullOrEmpty(columAttribute.Name) ? columAttribute.Name : p.Name;
                        colunas.Add(nomeColunaTabela);
                        valores.Add(p.GetValue(aDb));
                    }

                    var parans = new List<string>();
                    foreach (var coluna in colunas)
                    {
                        parans.Add($"@{coluna}");
                    }
                    string parametros = string.Join(",", parans.ToArray());
                    string colunasJoin = string.Join(",", colunas.ToArray());

                    TableAttribute tableAttribute = aDb.GetType().GetCustomAttribute<TableAttribute>();
                    string nomeTabela = tableAttribute != null && !string.IsNullOrEmpty(tableAttribute.Name) ? tableAttribute.Name : aDb.GetType().Name;

                    string queryString = $"insert into {nomeTabela} ({colunasJoin}) values({parametros})";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.CommandType = CommandType.Text;

                    for (var i = 0; i < colunas.Count; i++)
                    {
                        var nomeColuna = colunas[i];
                        var valorColuna = valores[i];
                        command.Parameters.Add($"@{nomeColuna}", GetDbType(valorColuna));
                        command.Parameters[$"@{nomeColuna}"].Value = valorColuna;
                    }

                    connection.Open();

                    return command.ExecuteNonQuery();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return 0;
        }

        public void Alterar(ADb aDb)
        {
            using (SqlConnection connection = new SqlConnection(STRING_CNN))
            {
                try
                {
                    var chavePk = "";
                    var colunas = new List<string>();
                    var valores = new List<object>();
                    var parans = new List<string>();

                    foreach (var p in aDb.GetType().GetProperties())
                    {
                        ColumAttribute columAttribute = p.GetCustomAttribute<ColumAttribute>();
                        if (p.GetValue(aDb) == null) continue;

                        //Atribui o valor da chave para o filtro
                        if ((columAttribute != null) && (columAttribute.PrimaryKey))
                        {
                            string nomeColunaPk = columAttribute != null && !string.IsNullOrEmpty(columAttribute.Name) ? columAttribute.Name : p.Name;
                            chavePk = nomeColunaPk + "=" + p.GetValue(aDb);
                            continue;
                        }

                        if (columAttribute != null && (columAttribute.PrimaryKey || columAttribute.IsNotOnDataBase)) continue;

                        string nomeColunaTabela = columAttribute != null && !string.IsNullOrEmpty(columAttribute.Name) ? columAttribute.Name : p.Name;
                        colunas.Add(nomeColunaTabela);
                        valores.Add(p.GetValue(aDb));

                        parans.Add($"{nomeColunaTabela} = @{nomeColunaTabela}"); //= {p.GetValue(aDb)}
                    }

                    string parametros = string.Join(",", parans.ToArray());

                    TableAttribute tableAttribute = aDb.GetType().GetCustomAttribute<TableAttribute>();

                    string nomeTabela = tableAttribute != null && !string.IsNullOrEmpty(tableAttribute.Name) ? tableAttribute.Name : GetType().Name;

                    string queryString = $"update {nomeTabela} set {parametros} where ({chavePk})";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.CommandType = CommandType.Text;

                    for (var i = 0; i < colunas.Count; i++)
                    {
                        var nomeColuna = colunas[i];
                        var valorColuna = valores[i];
                        command.Parameters.Add($"@{nomeColuna}", GetDbType(valorColuna));
                        command.Parameters[$"@{nomeColuna}"].Value = valorColuna;
                    }

                    connection.Open();

                    command.ExecuteNonQuery();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Deletar(ADb aDb)
        {
            using (SqlConnection connection = new SqlConnection(STRING_CNN))
            {
                try
                {
                    var chavePk = "";
                    var parans = new List<string>();

                    foreach (var p in aDb.GetType().GetProperties())
                    {
                        ColumAttribute columAttribute = p.GetCustomAttribute<ColumAttribute>();
                        if (p.GetValue(aDb) == null) continue;

                        //Atribui o valor da chave para o filtro
                        if ((columAttribute != null) && (columAttribute.PrimaryKey))
                        {
                            string nomeColunaPk = columAttribute != null && !string.IsNullOrEmpty(columAttribute.Name) ? columAttribute.Name : p.Name;
                            chavePk = nomeColunaPk + "=" + p.GetValue(aDb);
                        }
                        else
                        {
                            continue;
                        }

                        string nomeColunaTabela = columAttribute != null && !string.IsNullOrEmpty(columAttribute.Name) ? columAttribute.Name : p.Name;
                        //parans.Add($"{nomeColunaTabela} = @{nomeColunaTabela}"); //= {p.GetValue(aDb)}
                    }

                    //string parametros = string.Join(",", parans.ToArray());

                    TableAttribute tableAttribute = aDb.GetType().GetCustomAttribute<TableAttribute>();

                    string nomeTabela = tableAttribute != null && !string.IsNullOrEmpty(tableAttribute.Name) ? tableAttribute.Name : GetType().Name;

                    string queryString = $"Delete {nomeTabela} where ({chavePk})";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.CommandType = CommandType.Text;

                    connection.Open();

                    command.ExecuteNonQuery();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
