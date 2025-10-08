using System;
using System.Collections.Generic;
using System.Threading;

class SleepSortProgram
{
    static List<int> resultado = new List<int>();

    static void Main()
    {
        Console.WriteLine("=== SLEEP SORT SIMPLES ===");
        Console.WriteLine("Digite numeros ex: (5 7 12 3):");
        Console.Write("Exemplo: 3 1 4 2\nSua lista: ");

        string texto = Console.ReadLine();
        string[] numerosTexto = texto.Split(' ');

        int[] numeros = new int[numerosTexto.Length];

        for (int i = 0; i < numerosTexto.Length; i++)
        {
            numeros[i] = int.Parse(numerosTexto[i]);
        }

        Console.WriteLine("\nIniciando...");
        Console.Write("Original: ");
        MostrarLista(numeros);

        OrdenarComSleep(numeros);

        // Espera o maior numero + 2 segundos extra
        int maior = EncontrarMaior(numeros);
        Thread.Sleep((maior + 2) * 1000);

        Console.Write("Ordenada: ");
        MostrarLista(resultado.ToArray());

        Console.WriteLine("Fim!");
    }

    static void OrdenarComSleep(int[] nums)
    {
        resultado.Clear();

        foreach (int num in nums)
        {
            Thread novaThread = new Thread(() => AdicionarComSleep(num));
            novaThread.Start();
        }
    }

    static void AdicionarComSleep(int numero)
    {
        Console.WriteLine("Numero " + numero + " dormindo...");
        Thread.Sleep(numero * 1000);
        resultado.Add(numero);
        Console.WriteLine("Numero " + numero + " pronto!");
    }

    static int EncontrarMaior(int[] nums)
    {
        int maior = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > maior) maior = nums[i];
        }
        return maior;
    }

    static void MostrarLista(int[] lista)
    {
        foreach (int num in lista)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}