using System.Numerics;

namespace DesafioPraticoFundamentosCSharp.Exercicios;

public class InputsUsuario
{
    public static void DigitarNome()
    {
        string nome = string.Empty;

        Console.WriteLine("\nPor favor, digite seu nome: ");
        nome = Console.ReadLine();

        while(string.IsNullOrEmpty(nome) || nome.All(x => char.IsWhiteSpace(x)))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Campo de nome vazio.\n");
            Console.ForegroundColor = ConsoleColor.White;
            DigitarNome();
            return;
        }
        Console.WriteLine($"\nOlá, {nome}! Seja muito bem-vindo(a)!");
    }

    public static void DigitarNomeCompleto()
    {
        Console.WriteLine("\nPor favor, digite seu primeiro nome: ");
        string primeiroNome = Console.ReadLine();

        Console.WriteLine("Agora seu sobrenome: ");
        string sobreNome = Console.ReadLine();

        while (primeiroNome == string.Empty || sobreNome == string.Empty)
        {
            DigitarNomeCompleto();
            return;
        }

        string nomeCompleto = $"{primeiroNome} {sobreNome}";
        Console.WriteLine($"\nSeu nome completo é: {nomeCompleto}.");
    }

    public static void ContagemCaracteres()
    {
        string frase = string.Empty;

        Console.WriteLine("\nEscreva uma palavra ou frase que mostraremos quantas letras ela possui:");
        frase = Console.ReadLine();

        while (string.IsNullOrEmpty(frase) || frase.All(x => char.IsWhiteSpace(x)))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: valor informado não é uma palavra ou frase. Tente novamente!\n");
            Console.ForegroundColor = ConsoleColor.White;
            ContagemCaracteres();
            return;
        }

        string fraseSemEspaco = frase.Replace(" ", "");
        int contador = 0;

        for (int i = 0; i < fraseSemEspaco.Length; i++)
        {
            contador++;
        }

        string[] palavraOrFrase = frase.Trim().Split(" "[0]);
        string resultado = palavraOrFrase.Length > 1 ? "Frase" : "Palavra";
        Console.WriteLine($"\n{resultado} informada: \"{frase}\"");
        Console.WriteLine($"Possui {contador} letras.");
    }

    public static void ConsultaPlacaVeicular()
    {
        string placa = string.Empty;

        Console.WriteLine("\nDigite a placa de um veículo, após digitar iremos verificar se a placa segue o padrão brasileiro válido até 2018.");
        Console.WriteLine("Obs:\n -Não precisa usar o hífen para separar as letras e os números;");
        placa = Console.ReadLine().ToUpper();

        while (string.IsNullOrWhiteSpace(placa))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nError: placa informada no formato inválido. Tente novamente!\n");
            Console.ForegroundColor = ConsoleColor.White;
            ConsultaPlacaVeicular();
            return;
        }

        if(placa.Length != 7)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nError: placa informada não possui 7 caracteres alfanuméricos. Tente novamente!\n");
            Console.ForegroundColor = ConsoleColor.White;
            ConsultaPlacaVeicular();
            return;
        }

        bool isValid = ValidaPlaca(placa);
        string msg = isValid ? $"\nA placa {placa.ToUpper()} segue o padrão brasileiro válido até 2018." : $"\nA placa { placa.ToUpper()} não segue o formato válido até 2018.";
        Console.ForegroundColor = isValid ? ConsoleColor.Green : ConsoleColor.Red;
        Console.WriteLine(msg);
        Console.ForegroundColor = ConsoleColor.White;
    }

    static bool ValidaPlaca(string placa)
    {
        // Verifica se os primeiros três caracteres são letras maiúsculas
        for (int i = 0; i < 3; i++)
        {
            if (!Char.IsLetter(placa[i]) || !Char.IsUpper(placa[i]))
                return false;
        }

        // Verifica se os últimos quatro caracteres são dígitos
        for (int i = 3; i < 7; i++)
        {
            if (!Char.IsDigit(placa[i]))
                return false;
        }

        return true;
    }
}
