using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CashRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    //Console.WriteLine(line);
                    if (string.IsNullOrEmpty(line))
                        continue;
                    string[] splits = line.Split(';');
                    decimal purchasePrice = Convert.ToDecimal(splits[0]);
                    decimal cashTendered = Convert.ToDecimal(splits[1]);
                    if (cashTendered < purchasePrice)
                    {
                        Console.WriteLine("ERROR");
                        continue;
                    }
                    if (cashTendered == purchasePrice)
                    {
                        Console.WriteLine("ZERO");
                        continue;
                    }
                    decimal change = cashTendered - purchasePrice;
                    int hundreds = (int)change / 100;
                    change = change - (hundreds * 100);
                    for (int i = 1; i <= hundreds; i++)
                    {
                        Console.Write("ONE HUNDRED");
                        if (i < hundreds)
                            Console.Write(",");
                    }
                    if (change > 0 && hundreds > 0)
                        Console.Write(',');
                    int fifties = (int)change / 50;
                    change = change - (fifties * 50);
                    for (int i = 1; i <= fifties; i++)
                    {
                        Console.Write("FIFTY");
                        if (i < fifties)
                            Console.Write(",");
                    }
                    if (change > 0 && fifties > 0)
                        Console.Write(',');
                    int twenties = (int)change / 20;
                    change = change - (twenties * 20);
                    for (int i = 1; i <= twenties; i++)
                    {
                        Console.Write("TWENTY");
                        if (i < twenties)
                            Console.Write(",");
                    }
                    if (change > 0 && twenties > 0)
                        Console.Write(',');
                    int tens = (int)change / 10;
                    change = change - (tens * 10);
                    for (int i = 1; i <= tens; i++)
                    {
                        Console.Write("TEN");
                        if (i < tens)
                            Console.Write(",");
                    }
                    if (change > 0 && tens > 0)
                        Console.Write(',');
                    int fives = (int)change / 5;
                    change = change - (fives * 5);
                    for (int i = 1; i <= fives; i++)
                    {
                        Console.Write("FIVE");
                        if (i < fives)
                            Console.Write(",");
                    }
                    if (change > 0 && fives > 0)
                        Console.Write(',');
                    int twos = (int)change / 2;
                    change = change - (twos * 2);
                    for (int i = 1; i <= twos; i++)
                    {
                        Console.Write("TWO");
                        if (i < twos)
                            Console.Write(",");
                    }
                    if (change > 0 && twos > 0)
                        Console.Write(',');
                    int singles = (int)change;
                    change = change - singles;
                    for (int i = 1; i <= singles; i++)
                    {
                        Console.Write("ONE");
                        if (i < singles)
                            Console.Write(",");
                    }
                    if (change > 0 && singles > 0)
                        Console.Write(',');

                    // promote change to integer ammount
                    change = change * 100;
                    int halfDollars = (int)change / 50;
                    change = change - (halfDollars * 50);
                    for (int i = 1; i <= halfDollars; i++)
                    {
                        Console.Write("HALF DOLLAR");
                        if (i < halfDollars)
                            Console.Write(",");
                    }
                    if (change > 0 && halfDollars > 0)
                        Console.Write(',');
                    int quarters = (int)change / 25;
                    change = change - (quarters * 25);
                    for (int i = 1; i <= quarters; i++)
                    {
                        Console.Write("QUARTER");
                        if (i < quarters)
                            Console.Write(",");
                    }
                    if (change > 0 && quarters > 0)
                        Console.Write(',');
                    int dimes = (int)change / 10;
                    change = change - (dimes * 10);
                    for (int i = 1; i <= dimes; i++)
                    {
                        Console.Write("DIME");
                        if (i < dimes)
                            Console.Write(",");
                    }
                    if (change > 0 && dimes > 0)
                        Console.Write(',');
                    int nickels = (int)change / 5;
                    change = change - (nickels * 5);
                    for (int i = 1; i <= nickels; i++)
                    {
                        Console.Write("NICKEL");
                        if (i < nickels)
                            Console.Write(",");
                    }
                    if (change > 0 && nickels > 0)
                        Console.Write(',');
                    int pennies = (int)change;
                    for (int i = 1; i <= pennies; i++)
                    {
                        Console.Write("PENNY");
                        if (i < pennies)
                            Console.Write(",");
                    }
                    Console.WriteLine();
                }
            //Console.ReadLine();
        }
    }
}
