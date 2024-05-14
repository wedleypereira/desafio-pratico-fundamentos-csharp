using System.Globalization;

namespace DesafioPraticoFundamentosCSharp.Exercicios;

public class OperacoesMatematicas
{
    public static void CalcularNumerosDouble()
    {
        List<string> inputUser = new List<string>();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nInsira dois valores para receber a \"SOMA\", \"SUBTRAÇÃO\", \"MULTIPLICAÇÃO\", \"DIVISÃO\" e a \"MÉDIA\" entre esses dois números.");
        Console.WriteLine("Observações: \n- Use a apenas uma vírgula ou um ponto como separador decimal; \n- Caso seja um número de milhar, não é necessário usar o ponto;\n");
        Console.WriteLine("Insira o primeiro número: ");
        inputUser.Add(Console.ReadLine());

        Console.WriteLine("Insira o segundo número: ");
        inputUser.Add(Console.ReadLine());

        while (string.IsNullOrEmpty(inputUser[0]) || string.IsNullOrEmpty(inputUser[1]) || 
               inputUser[0].Any(x => Char.IsWhiteSpace(x)) || inputUser[1].Any(x => Char.IsWhiteSpace(x)))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nEntrada inválida. Foi identificado valores vazios ou com espaços nos números inseridos!\nExemplo de número válido: \"5,75\";\n");
            CalcularNumerosDouble();
            return;
        }

        bool numeroValido = false;
        List<double> numerosParsed = new List<double>();

        inputUser.ForEach(x => 
        {
            Console.ForegroundColor = ConsoleColor.Red;

            (numeroValido, double numero) = ValidaNumero(x);
            if (!numeroValido) 
            { 
                Console.WriteLine($"\nO seguinte valor informado \"{x}\" não é válido como número. Leia as observações e tente novamente.\n");
                return;
            }
            else
            {
                numerosParsed.Add(numero);
            }
        });

        while (numerosParsed.Count != 2)
        {
            CalcularNumerosDouble();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Green;

        double soma = Soma(numerosParsed[0], numerosParsed[1]);
        Console.WriteLine($"\nO resultado da SOMA dos dois valores é: {FormataResultado(soma)}");

        double subtracao = Subtracao(numerosParsed[0], numerosParsed[1]);
        Console.WriteLine($"O resultado da SUBTRAÇÃO dos dois valores é: {FormataResultado(subtracao)}");

        double multiplicacao = Multiplicacao(numerosParsed[0], numerosParsed[1]);
        Console.WriteLine($"O resultado da MULTIPLICAÇÃO dos dois valores é: {FormataResultado(multiplicacao)}");

        (string msgNumEquals0, double? divisao) = Divisao(numerosParsed[0], numerosParsed[1]);
        var resultado = divisao == null ? msgNumEquals0 : FormataResultado((double)divisao);
        Console.WriteLine($"O resultado da DIVISÃO dos dois valores é: {resultado}");

        double media = Media(numerosParsed[0], numerosParsed[1]);
        Console.WriteLine($"O resultado da MÉDIA dos dois valores é: {FormataResultado(media)}");

        Console.ForegroundColor = ConsoleColor.White;
    }

    static double Soma(double num1, double num2) => num1 + num2;
    static double Subtracao(double num1, double num2) => num1 - num2;
    static double Multiplicacao(double num1, double num2) => num1 * num2;
    static (string mensagem, double? resultadoDivisao) Divisao(double num1, double num2)
    {
        if (num2 == 0) return ("Não é possível dividir por 0.", null);
        else return (string.Empty, num1 / num2);
    }
    static double Media(double num1, double num2) => (num1 + num2) / 2;

    static (bool eNumeroValido, double resultadoInput) ValidaNumero(string numero)
    {
        bool parsed = Double.TryParse(numero, NumberStyles.Number, numero.Contains(',') ? new CultureInfo("pt-BR") : CultureInfo.InvariantCulture, out double number);

        if (!parsed)
            return (false, number);

        return (true, number);
    }

    static string FormataResultado(double numero)
    {
        string numeroFormatado = numero % 1 == 0 ? numero.ToString("0") : numero.ToString("0.00");
        return numeroFormatado;
    }
}
