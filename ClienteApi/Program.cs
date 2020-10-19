using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace ClienteApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Acessando a API de voos, aguarde um momento...");

            var repositorio = new VooRepositorioAPI();

            var voosTask = repositorio.GetVooAsync();

            voosTask.ContinueWith(voosTask =>
            {
                var voos = voosTask.Result;
                foreach (var v in voos)
                    Console.WriteLine(v.ToString());

                Environment.Exit(0);
            },
            TaskContinuationOptions.OnlyOnRanToCompletion
            );

            Console.WriteLine();

        }
    }
}

