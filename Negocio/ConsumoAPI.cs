using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
    class ConsumoAPI : DataBase.ADb
    {
        public List<Voo> VoosDisponiveis(Voo filtroVoo)
        {
            /*buscar os voos disponiveis passando como parametro os dados do objeto filtroVoo
             * e alimentar uma lista a ser mostrada na tela inicial com filtro*/
            return null;
        }
            
        public void ReservarVoos(List<Voo> listaVoo)
        {
            //1-Reservar o voo na CIA aerea utilizando API
            //2-Atualizar a PEDIDOS_VOO com as informações do voo reservado

            foreach (var vooCli in listaVoo)
            {
                //1-reservar pela API
                //2-registrar na base PEDIDOS_VOO

                new PedidoVoo() { Id = 4, Id_Pessoa = 1, Id_Voo = 1, Status = "P", Dias_Reservado = 5, Dt_Reservado = DateTime.Now, Dt_Cancelado = DateTime.Now, Vl_Passagem = 100.00 }.ReservaVagaVooCliente(vooCli);

            }
        }     
            
    }
}
