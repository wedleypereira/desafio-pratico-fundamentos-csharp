using System.Globalization;

namespace DesafioPraticoFundamentosCSharp.Exercicios;

public class Data
{
    public static void ExibeDataAtual()
    {
        DateTime dataHoje = DateTime.Now;
        Console.WriteLine("\nData completa: " + dataHoje.ToString("F", new CultureInfo("pt-BR")));
        Console.WriteLine("Apenas a data: " + dataHoje.ToString("dd/MM/yyyy" ,new CultureInfo("pt-BR")));
        Console.WriteLine("Apenas a hora: " + dataHoje.ToString("HH:mm:ss" ,new CultureInfo("pt-BR")));
        Console.WriteLine("Data com o mês por extenso: " + dataHoje.ToString("dd/MMMM/yyyy" ,new CultureInfo("pt-BR")));
    }
}
