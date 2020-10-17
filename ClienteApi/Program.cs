using System;


namespace ClienteApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Acessando a API de voos, aguarde um momento...");

            var repositorio = new VooRepositorio();

            var voosTask = repositorio.GetVooAsync();

            voosTask.ContinueWith(voosTask =>
            {
                var voos = task.Result;
                foreach (var v in voos)
                    WriteLine(v.ToString());

                Environment.Exit(0);
            },
            TaskContinuationOptions.OnlyOnRanToCompletion
            );

            Console.ReadLine();

        }
    }
}

