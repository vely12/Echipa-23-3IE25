using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            AfiseazaMeniu();

            bool continua = true;
            while (continua)
            {
                Console.Write("\nAlege o opțiune (1-4): ");
                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        CalculatorSimplu();
                        break;
                    case "2":
                        ListaDeCarti();
                        break;
                    case "3":
                        JocGhiceste();
                        break;
                    case "4":
                        continua = false;
                        Console.WriteLine("\n✓ La revedere!");
                        break;
                    default:
                        Console.WriteLine("\n✗ Opțiune invalidă!");
                        break;
                }
            }
        }

        static void AfiseazaMeniu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║   APLICAȚIE CONSOLE INTERACTIVĂ    ║");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine("\n[1] Calculator simplu");
            Console.WriteLine("[2] Lista de cărți");
            Console.WriteLine("[3] Joc - Ghicește numărul");
            Console.WriteLine("[4] Ieșire");
        }

        static void CalculatorSimplu()
        {
            Console.WriteLine("\n--- CALCULATOR ---");
            Console.Write("Primul număr: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Operație (+, -, *, /): ");
            string op = Console.ReadLine();

            Console.Write("Al doilea număr: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            double rezultat = 0;
            bool valid = true;

            switch (op)
            {
                case "+": rezultat = num1 + num2; break;
                case "-": rezultat = num1 - num2; break;
                case "*": rezultat = num1 * num2; break;
                case "/":
                    if (num2 != 0) rezultat = num1 / num2;
                    else { Console.WriteLine("Eroare: Împărțire la 0!"); valid = false; }
                    break;
                default:
                    Console.WriteLine("Operație invalidă!");
                    valid = false;
                    break;
            }

            if (valid)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nRezultat: {num1} {op} {num2} = {rezultat}");
                Console.ResetColor();
            }
        }

        static void ListaDeCarti()
        {
            Console.WriteLine("\n--- BIBLIOTECA MEA ---");
            List<string> carti = new List<string>
            {
                "Amintiri din copilărie - Ion Creangă",
                "Luceafărul - Mihai Eminescu",
                "Moromeții - Marin Preda"
            };

            Console.WriteLine("\nCărți disponibile:");
            for (int i = 0; i < carti.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {carti[i]}");
            }

            Console.Write("\nAdaugă o carte nouă (sau ENTER pentru a sări): ");
            string carteNoua = Console.ReadLine();

            if (!string.IsNullOrEmpty(carteNoua))
            {
                carti.Add(carteNoua);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"✓ Carte adăugată! Total: {carti.Count} cărți");
                Console.ResetColor();
            }
        }

        static void JocGhiceste()
        {
            Console.WriteLine("\n--- GHICEȘTE NUMĂRUL ---");
            Random random = new Random();
            int numarSecret = random.Next(1, 101);
            int incercari = 0;

            Console.WriteLine("Am ales un număr între 1 și 100. Ghicește-l!");

            while (true)
            {
                Console.Write("\nÎncercarea ta: ");
                int ghicit = Convert.ToInt32(Console.ReadLine());
                incercari++;

                if (ghicit == numarSecret)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\n🎉 BRAVO! Ai ghicit în {incercari} încercări!");
                    Console.ResetColor();
                    break;
                }
                else if (ghicit < numarSecret)
                {
                    Console.WriteLine("↑ Mai mare!");
                }
                else
                {
                    Console.WriteLine("↓ Mai mic!");
                }
            }
        }
    }

}
