using Negocio;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                //new PedidoVoo() { Id_Pessoa = 1, Id_Voo = 1, Status = "R", Dias_Reservado = 5, Dt_Reservado = DateTime.Now, Dt_Cancelado = null, Vl_Passagem = 100.00 }.Salvar();
                //new PedidoVoo() { Id = 4, Id_Pessoa = 1, Id_Voo = 1, Status = "P", Dias_Reservado = 5, Dt_Reservado = DateTime.Now, Dt_Cancelado = DateTime.Now, Vl_Passagem = 100.00 }.Alterar();
                new PedidoVoo() { Id = 4 }.Deletar();
                
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
            }
        }
    }
}
