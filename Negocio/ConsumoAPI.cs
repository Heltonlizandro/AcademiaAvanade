using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;

namespace Negocio
{
    public class ConsumoAPI : DataBase.ADb
    {
        //private static int idClienteLogado;
        //VooRepositorioAPI repositorio;
        //Task<VooAPI> vooAPI;

        public ConsumoAPI()
        {
            /*repositorio = new VooRepositorioAPI();
            var voosTask = repositorio.GetVooAsync();
            for (var i = 0; i < voosTask.Result.Count; i++)
            {
                Console.WriteLine("teste");
            }           

             voosTask.ContinueWith(task =>
             {
                 var voos = task.Result;               

                 foreach (var v in voos)
                     WriteLine(v.Id);

                 Environment.Exit(0);
             },
             TaskContinuationOptions.OnlyOnRanToCompletion
             );

             ReadLine();*/
        }

        public void AtualizaVoosDisponiveis()
        {
            VooRepositorioAPI repositVoos = new VooRepositorioAPI();

            var voosTask = repositVoos.GetVooAsync();
            List<Voo> listaRetorno = new List<Voo>();

            foreach (var v in voosTask.Result)
            {
                var voosDisp = new Voo();

                voosDisp.Id = v.Id;
                voosDisp.CodEmpresa = v.CodigoEmpresa;
                voosDisp.Empresa = v.Empresa;
                voosDisp.nVoo = v.NumeroVoo;
                voosDisp.QtdMaxima = int.Parse(v.QuantidadeAssentos);
                voosDisp.QtdOcupada = int.Parse(v.QuantidadeOcupado);
                voosDisp.CodOrigem = v.CodigoOrigem;
                voosDisp.DescOrigem = v.AeroportoOrigem;
                voosDisp.CodDestino = v.CodigoDestino;
                voosDisp.DescDestino = v.AeroportoDestino;
                voosDisp.HoraPartida = v.HorarioPartida;
                voosDisp.VlAdulto = 100.00M;
                voosDisp.VlCrianca = 50.00M;
                voosDisp.InicioOperacao = DateTime.Parse(v.InicioOperacao);
                voosDisp.FimOperacao = DateTime.Parse(v.FimOperacao);

                Voo vooValidacao = (Voo)voosDisp.ConsultaById(voosDisp.Id);

                if (string.IsNullOrEmpty(vooValidacao.Id))
                {
                    voosDisp.Salvar();
                }
            }
        }

        public void AtualizaCiasAereas()
        {
            VooRepositorioAPI repositCias = new VooRepositorioAPI();

            var ciasTask = repositCias.GetCiaAsync();
            List<CiaAerea> listaRetorno = new List<CiaAerea>();

            foreach (var v in ciasTask.Result)
            {
                var ciaDisp = new CiaAerea()
                {
                    Id = v.Id,
                    Sigla = v.siglaOACI,
                    Nome = v.NomeEmpresa,
                    Nacionalidade = v.NacionalEstrangeira
                };

                CiaAerea ciaValidacao = (CiaAerea)ciaDisp.ConsultaById(ciaDisp.Id);

                if (string.IsNullOrEmpty(ciaValidacao.Id))
                {
                    ciaDisp.Salvar();
                }
            }
        }

        public List<Voo> VoosDisponiveis()
        {
            VooRepositorioAPI repositorio;
            repositorio = new VooRepositorioAPI();
            var voosTask = repositorio.GetVooAsync();
            List<Voo> listaRetorno = new List<Voo>();

            foreach (var v in voosTask.Result)
            {
                var vooDisp = new Voo();

                vooDisp.Id = v.Id;

                if (Int32.TryParse(v.QuantidadeAssentos, out int j)) { vooDisp.QtdMaxima = j; }

                if (Int32.TryParse(v.QuantidadeOcupado, out int a)) { vooDisp.QtdOcupada = a; }

                vooDisp.nVoo = v.NumeroVoo;

                listaRetorno.Add(vooDisp);
            }

            return listaRetorno;
        }

        public Voo VooById(string id)
        {
            VooRepositorioAPI repositorio;
            repositorio = new VooRepositorioAPI();
            var voosTask = repositorio.GetVooAsyncById(id);
            var vooDisp = new Voo();

            voosTask.ContinueWith(task =>
            {
                vooDisp.Id = voosTask.Result.Id;
                //WriteLine(v.Id);

                Environment.Exit(0);
            },
           TaskContinuationOptions.OnlyOnRanToCompletion
           );

            Console.WriteLine(voosTask.Result.Id);
            //vooDisp.Id = voosTask.Result.Id;
            //vooDisp.CodEmpresa = voosTask.Result.CodigoEmpresa;
            /*vooDisp.Empresa = voosTask.Result.Empresa;
            vooDisp.nVoo = voosTask.Result.NumeroVoo;
            if (Int32.TryParse(voosTask.Result.QuantidadeAssentos, out int j)) { vooDisp.QtdMaxima = j; }
            if (Int32.TryParse(voosTask.Result.QuantidadeOcupado, out int a)) { vooDisp.QtdOcupada = a; }
            vooDisp.CodOrigem = voosTask.Result.CodigoOrigem;
            vooDisp.DescOrigem = voosTask.Result.AeroportoOrigem;
            vooDisp.CodDestino = voosTask.Result.CodigoDestino;
            vooDisp.DescDestino = voosTask.Result.AeroportoDestino;
            vooDisp.HoraPartida = voosTask.Result.HorarioPartida;
            vooDisp.VlAdulto = 100.00M;
            vooDisp.VlCrianca = 50.00M;
            vooDisp.InicioOperacao = DateTime.Parse(voosTask.Result.InicioOperacao);
            vooDisp.FimOperacao = DateTime.Parse(voosTask.Result.FimOperacao);*/


            return vooDisp;
        }

        /*public void ReservarVoos(List<Voo> listaVoo)
        {
            //1-Reservar o voo na CIA aerea utilizando API
            //2-Atualizar a PEDIDOS_VOO com as informações do voo reservado

            foreach (var vooCli in listaVoo)
            {
                //1-reservar pela API
                //2-registrar na base PEDIDOS_VOO

                new Pedido()
                {
                    Id_Pessoa = vooCli.pessoa.Id,
                    Id_Cliente = idClienteLogado,
                    Id_Voo = vooCli.Id,
                    Status = "R",
                    Dt_Reserva = DateTime.Now,
                    Dt_Cancelado = null,
                    Vl_Passagem = 100.00
                }.Salvar();
            }
        }*/

        /*public void CancelarReserva(List<Voo> listaVoo)
        {
            foreach (var vooCli in listaVoo)
            {

            }
        }*/

        /*public void RegistrarPagamento(List<Voo> listaVoo)
        {
            foreach (var vooCli in listaVoo)
            {
                //1-Chamar API e alimentar as informacoes de pagamento

                //2-Confirmar pagamento do Voo e Cliente

                var pagamento = new Pagamento();

                //pagamento.Id = 4;
                pagamento.IdFormaPagamento = 1;
                pagamento.DtPagamento = DateTime.Now;
                pagamento.QtdParcela = 1;
                pagamento.vLParcela = vooCli.vlVoo;
                pagamento.vLTotal = 100.00;
                var IdPagamento = pagamento.Salvar();

                new Pedido() { Id = vooCli.Id, Id_Pagamento = IdPagamento }.Alterar();
            }
        }*/
    }
}
