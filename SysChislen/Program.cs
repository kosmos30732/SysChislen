using System.Numerics;

namespace SysChislen
{
    class Program
    {
        static void Main(string[] args)
        {
            //ввод сс первого числа
            Console.WriteLine("Введите систему счисления первого числа");
            string ss1 = Console.ReadLine();
            int cc1;

            //проверка числа сс на корректность
            if (!Int32.TryParse(ss1, out cc1))
            {
                Console.WriteLine("Не возможно преобразовать введенное число, содержит недопустимые символы");
                return;
            }
            if (cc1>36)
            {
                Console.WriteLine("Не доступна большая система счисления чем 36");
                return;
            }
            if (cc1 <= 1)
            {
                Console.WriteLine("Cистема счисления меньше или равна 1");
                return;
            }

            //ввод первого числа
            Console.WriteLine("Введите первое число");
            string str1 = Console.ReadLine();

            //проверка первого числа на корректность согласно введенной сс
            for (int i = 0; i < str1.Length; i++)
            {
                //корректность символов в числе
                if ((str1[i]>='0' && str1[i]<='9') || (str1[i]>='A' && str1[i]<='Z') || (str1[i] >= 'a' && str1[i] <= 'z'))
                {
                    if (str1[i] >= '0' && str1[i] <= '9')
                    {
                        //проверка что разряд может принадлежать этой сс
                        if (str1[i] - '0' >= cc1)
                        {
                            Console.WriteLine("Число не принадлежит данной системе счисления");
                            return;
                        }
                    }
                    else if (str1[i] >= 'A' && str1[i] <= 'Z')
                    {
                        //проверка что разряд может принадлежать этой сс
                        if (str1[i]-'A'+10>=cc1)
                        {
                            Console.WriteLine("Число не принадлежит данной системе счисления");
                            return;
                        }
                    }
                    else
                    {
                        //проверка что разряд может принадлежать этой сс
                        if (str1[i] - 'a' + 10 >= cc1)
                        {
                            Console.WriteLine("Число не принадлежит данной системе счисления");
                            return;
                        }
                    }                    
                }
                else
                {
                    Console.WriteLine("Введеноe число содержит недопустимые символы");
                    return;
                }
            }

            //куда запишем число в 10 сс
            BigInteger num1 = 0;

            //частный случай если сс 1 числа равна 10
            if (cc1==10)
            {
                num1 = BigInteger.Parse(str1);
            }
            else
            //переводим первое число в 10 сс
            {
                BigInteger bazis = cc1;
                for (int i = 0; i < str1.Length; i++)
                {
                    if (str1[i] >= '0' && str1[i] <= '9')
                    {
                        num1 += BigInteger.Pow(bazis, str1.Length - i - 1) * (str1[i] - '0');
                    }
                    else if (str1[i] >= 'A' && str1[i] <= 'Z')
                    {
                        num1 += BigInteger.Pow(bazis, str1.Length - i - 1) * (str1[i] - 'A' + 10);
                    }
                    else
                    {
                        num1 += BigInteger.Pow(bazis, str1.Length - i - 1) * (str1[i] - 'a' + 10);
                    }
                }
            }


            //считывание сс в которую нужно перевести
            Console.WriteLine("Введите систему счисления в которую нужно перевести число");
            string ss2 = Console.ReadLine();
            int cc2;

            //проверка числа сс на корректность
            if (!Int32.TryParse(ss2, out cc2))
            {
                Console.WriteLine("Не возможно преобразовать введенное число, содержит недопустимые символы");
                return;
            }
            if (cc2 > 36)
            {
                Console.WriteLine("Не доступна большая система счисления чем 36");
                return;
            }
            if (cc2 <= 1)
            {
                Console.WriteLine("Cистема счисления меньше или равна 1");
                return;
            }

            //частные случаи
            //если сс равны
            if (cc2==cc1)
            {
                Console.WriteLine("Число " + str1 + " в сс " + cc1 + " равно числу " + str1 + " в сс " + cc1);
                return;
            }
            //если сс в которую нужно перевести это 10 сс
            if (cc2==10)
            {
                Console.WriteLine("Число " + str1 + " в сс " + cc1 + " равно числу " + num1 + " в сс 10");
                return;
            }

            
            BigInteger bIcc2 = cc2;

            //место куда запишется число которое получится при переводе в указаную сс
            string str2 ="";

            //перевод числа в указаную сс
            while (true)
            {
                int num = Int32.Parse((num1 % bIcc2).ToString());
                if (num<=9)
                {
                    str2 = Convert.ToString(num) + str2;
                }
                else
                {
                    num -= 10;
                    str2 = Convert.ToChar('A' + num) + str2;
                }
                num1 /= bIcc2;
                if (num1.IsZero)
                {
                    break;
                }
            }

            Console.WriteLine("Число " + str1 + " в сс " + cc1 + " равно числу " + str2 + " в сс " + cc2);
        }
    }
}