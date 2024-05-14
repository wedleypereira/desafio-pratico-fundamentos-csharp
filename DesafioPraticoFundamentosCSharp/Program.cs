using DesafioPraticoFundamentosCSharp.Exercicios;

namespace DesafioPraticoFundamentosCSharp;

class Program
{
    static void Main()
    {
        FluxoPrograma();
    }

    static void FluxoPrograma()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Digite a tecla correspondente e pressione ENTER para acessar um dos exercícios abaixo: ");
        Console.WriteLine("1 - Mensagem de boas vindas;");
        Console.WriteLine("2 - Exibir o nome completo do usuário;");
        Console.WriteLine("3 - Operações matemáticas com dois valores;");
        Console.WriteLine("4 - Contador de caracteres de uma frase;");
        Console.WriteLine("5 - Validador de placa veicular no padrão brasileiro até 2018;");
        Console.WriteLine("6 - Informa a data atual em algumas formas diferentes.");

        var inputUsuario = Console.ReadLine();

        switch (inputUsuario)
        {
            case "1":
                InputsUsuario.DigitarNome();
                break;
            case "2":
                InputsUsuario.DigitarNomeCompleto();
                break;
            case "3":
                OperacoesMatematicas.CalcularNumerosDouble();
                break;
            case "4":
                InputsUsuario.ContagemCaracteres();
                break;
            case "5":
                InputsUsuario.ConsultaPlacaVeicular();
                break;
            case "6":
                Data.ExibeDataAtual();
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("A tecla pressionada não corresponde a nenhum exercício cadastrado na base de dados.\n");
                break;
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nDeseja tentar novamente ou escolher outro exercício? S / N ");
        inputUsuario = Console.ReadLine();

        while(!string.IsNullOrWhiteSpace(inputUsuario) && inputUsuario.ToLower() != "s")
        {
            Console.WriteLine("\nPrograma encerrado...");
            return;
        }

        Console.Clear();
        FluxoPrograma();
    }
}
