using Negocio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp

{
    class Program
    {
        static void Main(string[] args)
        {

            var consumo = new ConsumoAPI();
            //atualiza as cias aereas na base de dados pegando do json
            //teste.AtualizaCiasAereas();
            //atualiza os voos disponíveis na base de dados pegando do json
            //teste.AtualizaVoosDisponiveis();

            //carregar a lista de todos os voos disponíveis
            var listaVoosDisp = consumo.VoosDisponiveis();
            List<Voo> listaVooSelecionados = new List<Voo>();

            //alimentando a lista com os tres primeiros voos disponiveis
            for (int i = 0; i < 3; i++)
            {
                listaVooSelecionados.Add(listaVoosDisp[i]);
            }

            //atualizar na tela informando as pessoas que irão ingressar em cada voo selecionado
            //Para cada voo, preencher os dados da pessoa
            foreach (var vooCliente in listaVooSelecionados)
            {
                int i = 0;
                i++;

                switch (i)
                {
                    case 1: 
                        {
                            vooCliente.pessoa = new Pessoa();
                            vooCliente.pessoa.CPF = "02458745874";
                            vooCliente.pessoa.Nome = "Elizeu Helton Stewart";
                            vooCliente.pessoa.DtNascimento = DateTime.Now;

                            if (vooCliente.pessoa.ConsultarPessoaCPF(vooCliente.pessoa.CPF) != null)
                            {
                                vooCliente.pessoa.Alterar();
                            } else
                            {
                                vooCliente.pessoa.Salvar();
                            }

                            break;
                        }
                    case 2:
                        {
                            vooCliente.pessoa = new Pessoa();
                            vooCliente.pessoa.CPF = "38541546852";
                            vooCliente.pessoa.Nome = "Joao da Silva";
                            vooCliente.pessoa.DtNascimento = DateTime.Now;

                            if (vooCliente.pessoa.ConsultarPessoaCPF(vooCliente.pessoa.CPF) != null)
                            {
                                vooCliente.pessoa.Alterar();
                            }
                            else
                            {
                                vooCliente.pessoa.Salvar();
                            }

                            break;
                        }
                    case 3:
                        {
                            vooCliente.pessoa = new Pessoa();
                            vooCliente.pessoa.CPF = "94587215438";
                            vooCliente.pessoa.Nome = "Maria Jose da Silva";
                            vooCliente.pessoa.DtNascimento = DateTime.Now;

                            if (vooCliente.pessoa.ConsultarPessoaCPF(vooCliente.pessoa.CPF) != null)
                            {
                                vooCliente.pessoa.Alterar();
                            }
                            else
                            {
                                vooCliente.pessoa.Salvar();
                            }

                            break;
                        }

                    default:
                        break;
                }
            }
            
            //chamar o métido para registrar e validar as vagas disponiveis
            consumo.ReservarVoos(listaVooSelecionados);

            //pagamento da lista das reservas

            

            /*
try
{


//new PedidoVoo() { Id_Pessoa = 1, Id_Voo = 1, Status = "R", Dias_Reservado = 5, Dt_Reservado = DateTime.Now, Dt_Cancelado = null, Vl_Passagem = 100.00 }.Salvar();
//new PedidoVoo() { Id = 4, Id_Pessoa = 1, Id_Voo = 1, Status = "P", Dias_Reservado = 5, Dt_Reservado = DateTime.Now, Dt_Cancelado = DateTime.Now, Vl_Passagem = 100.00 }.Alterar();
//new Pedido() { Id = 4 }.Deletar();
var cliente = new Cliente() { }.Todos();

}
catch (Exception err)
{
Console.WriteLine(err.Message);
}

try
{
//new Pessoa() { Nome="Lana", CPF = "22233344433", Email="heltonlizandro@gmail.com"}.Salvar();
}
catch(Exception err)
{
Console.WriteLine(err.Message);
}

try
{
//    new Cliente() { Login = "Helton", Senha = "123" }.Salvar();
}
catch (Exception err)
{
Console.WriteLine(err.Message);
*/
        }


    }

}
