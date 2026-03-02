using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_02_ScaDavid_Bingo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string ContinueGame;
            string GeneratedNumbers = "";
            int[] PlayerCorrects = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] CurrentRoundNumbers = new int[20];
            string[,] PlayerNumbers = new string[10, 5];
            string[] PlayerCorrectNumbers = new string[10];
            int iForNumGen = 0;
            string OneoffVar4DupeCheck = "";
            do
            {
                
                for (int i = 0; i < 10; i++) {
                    for (int j = 0; j < 5; j++)
                    {
                        GeneratedNumbers = "";
                        do
                        {
                            int TempNumber = rnd.Next(1, 76);
                            if (OneoffVar4DupeCheck.Contains(Convert.ToString(" "+TempNumber+" ")))
                            {
                                continue;
                            }
                            else
                            {
                                GeneratedNumbers +=" " + TempNumber + " ";
                                OneoffVar4DupeCheck +=" " + TempNumber + " ";
                                iForNumGen++;
                            }
                            
                        } while (iForNumGen < 5);
                        PlayerNumbers[i, j] = GeneratedNumbers;
                        iForNumGen = 0;
                        
                    }
                    OneoffVar4DupeCheck = " ";
                }
                iForNumGen = 0;
                do
                {
                    int TempNumber = rnd.Next(1, 76);
                    if (CurrentRoundNumbers.Contains(TempNumber))
                    {
                        continue;
                    }
                    else
                    {
                        CurrentRoundNumbers[iForNumGen] = TempNumber;
                        iForNumGen++;
                    }

                } while (iForNumGen <20);

                for(int i = 0; i < 20; i++)
                {
                    int NumToCheck = CurrentRoundNumbers[i];
                    for (int j = 0; j < 10; j++)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            if (PlayerNumbers[j, k].Contains(Convert.ToString(CurrentRoundNumbers[i])))
                            {
                                PlayerCorrects[j]++;
                                PlayerCorrectNumbers[j] += Convert.ToString(CurrentRoundNumbers[i]) + ", ";
                            }
                        }
                    }
                }
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"{i + 1} szamu jatekos helyes szamainak mennyisege:{PlayerCorrects[i]}");
                    Console.WriteLine($"{i+1} szamu jatekos helyes szamai: {PlayerCorrectNumbers[i]}");
                }




                Console.WriteLine("uj szimulacios kor inditasa?:[Y/n]");
                ContinueGame = Console.ReadLine();
            }
            while (ContinueGame != "n");
        }
    }
}
