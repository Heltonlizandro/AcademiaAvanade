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
            
            var teste = new ConsumoAPI();

            //teste.AtualizaCiasAereas();
            teste.AtualizaVoosDisponiveis();

            var listavoos = teste.VoosDisponiveis();

            //Voo voo = teste.VooById("5f874d41b3c8bd2ee8871aff");

            //Console.WriteLine("teste");

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
