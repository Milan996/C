using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingServis
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] vozila = { "ns125uj", "bg256hi", "ns558ok" };

            string unos;

            do
            {
                Console.WriteLine("***Parking servis***\n");

                Console.WriteLine("1. Provera registracija");
                Console.WriteLine("2. Izlaz");

                Console.WriteLine("\nIzaberite opciju:");
                unos = Console.ReadLine();

                int opcija;

                try
                {
                    opcija = int.Parse(unos);
                }
                catch
                {
                    Console.WriteLine("\nNevalidan unos, pokusajte ponovo.\n\n");
                    continue;
                }

                switch (opcija)
                {
                    case 1:
                        {
                            Console.WriteLine("\nUnesite rgistarsku oznaku:");

                            string regOznaka = Console.ReadLine();

                            bool validnaRegOznaka = ProveriValidnostRegistracije(regOznaka);

                            if (validnaRegOznaka)
                            {
                                bool uplacenParking = ProveriRegistraciju(regOznaka, vozila);

                                if (uplacenParking)
                                {
                                    Console.WriteLine("\nParking je uplacen za datu registarsku oznaku.\n");
                                }
                                else
                                {
                                    Console.WriteLine("\nParking nije uplacen za datu registarsku oznaku.\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nRegistarska oznaka nije u validnom formatu.\n");
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("\nRad zavrsen.");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\nOpcija nije podrzana, pokusajte ponovo.\n\n");
                            break;
                        }
                }
            }
            while (unos != "2");

            Console.ReadLine();
        }

        private static bool ProveriValidnostRegistracije(string regOznaka)
        {
            if (regOznaka.Length == 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool ProveriRegistraciju(string registracija, string[] vozila)
        {
            for (int i = 0; i < vozila.Length; i++)
            {
                if (registracija == vozila[i])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
