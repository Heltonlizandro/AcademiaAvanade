using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;

namespace Negocio
{
    public class ConsumoAPI : DataBase.ADb
    {
        public static int idClienteLogado;
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

        public VooAPI VooById(string id)
        {
            VooRepositorioAPI repositorio;
            repositorio = new VooRepositorioAPI();
            var voosTask = repositorio.GetVooAsyncById(id);
            var vooDisp = new VooAPI();

            voosTask.ContinueWith(task =>
            {
                vooDisp.Id = voosTask.Result.Id;
                vooDisp.InicioOperacao = voosTask.Result.InicioOperacao;
                vooDisp.Empresa = voosTask.Result.Empresa;
                vooDisp.NumeroVoo = voosTask.Result.NumeroVoo;
                vooDisp.QuantidadeAssentos = voosTask.Result.QuantidadeAssentos;
                vooDisp.QuantidadeOcupado = voosTask.Result.QuantidadeOcupado;
                vooDisp.CodigoOrigem = voosTask.Result.CodigoOrigem;
                vooDisp.AeroportoOrigem = voosTask.Result.AeroportoOrigem;
                vooDisp.CodigoDestino = voosTask.Result.CodigoDestino;
                vooDisp.AeroportoDestino = voosTask.Result.AeroportoDestino;
                vooDisp.HorarioPartida = voosTask.Result.HorarioPartida;
                //vooDisp.VlAdulto = 100.00M;
                //vooDisp.VlCrianca = 50.00M;
                vooDisp.InicioOperacao = voosTask.Result.InicioOperacao;
                vooDisp.FimOperacao = voosTask.Result.FimOperacao;
                Environment.Exit(0);
            },
           TaskContinuationOptions.OnlyOnRanToCompletion
           );

            return vooDisp;
        }


        public bool ReservaVooAPI(string id)
        {
            VooAPI voo = VooById(id);

            if (voo != null && int.Parse(voo.QuantidadeAssentos) < int.Parse(voo.QuantidadeOcupado))
            {
                var i = int.Parse(voo.QuantidadeOcupado) + 1;
                voo.QuantidadeOcupado = i.ToString();
                VooRepositorioAPI repositorio;
                repositorio = new VooRepositorioAPI();
                var voosTask = repositorio.PutVooAsyncById(voo.Id);

                return true;
            }

            return false;
        }

        public void ReservarVoos(List<Voo> listaVoo)
        {
            foreach (var vooCli in listaVoo)
            {
                //1-Reservar o voo na CIA aerea utilizando API
                if (ReservaVooAPI(vooCli.Id))
                {
                    //2-Atualizar a PEDIDOS com as informações do voo reservado
                    new Pedido()
                    {
                        Id_Pessoa = vooCli.pessoa.Id,
                        Id_Cliente = idClienteLogado,
                        Id_Voo = vooCli.Id,
                        Status = "R",
                        Dt_Reserva = DateTime.Now,
                        Dt_Cancelado = null,
                        Vl_Passagem = vooCli.vlVoo
                    }.Salvar();
                }
            }
        }

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
