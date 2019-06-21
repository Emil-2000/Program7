using System;
using System.Collections.Generic;


namespace Program7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество аргументов функции:");
            // количество аргументов функции
            int ArgumentN = CheckInput(true, true);

            List<bool> Arguments = new List<bool>();
            // ввод аргументов функции
            for (int i = 0; i < ArgumentN; i++)
            {
                Console.WriteLine("Введите " + (i + 1) + " аргумент функции:");
                int Ar = CheckInput(true, false, true);
                if (Ar == 1)
                    Arguments.Add(true);
                else
                    Arguments.Add(false);

            }
            // расчет функции
            //Console.Write("Введите значение функции:");
            //int Znach = CheckInput(true, false, true);
            bool result = Function(Arguments);
            //if (Znach == 1)
            //    result = true;
            //else
            //    result = false;

            if (CheckZero(Arguments, result))
                Console.WriteLine("Функция относится к первому типу замкнутого класса - сохраняет ноль ");
            if (CheckOne(Arguments, result))
                Console.WriteLine("Функция относится к второму типу замкнутого класса - сохраняет единицу ");
            Console.ReadLine();

        }

        /// <summary>
        /// Исследуемая Булева функция
        /// </summary>
        /// <param name="Arguments"></param>
        /// <returns></returns>
        static bool Function(List<bool> Arguments)
        {
            bool result = false;
            foreach (bool Item in Arguments)
            {
                if (!Item)
                    continue;
                else
                {
                    return true;
                }
            }
            return result;
        }

        /// <summary>
        /// Проверка на 1-й тип функции (сохранение нуля)
        /// </summary>
        /// <param name="Arguments"></param>
        /// <param name="Resultat"></param>
        /// <returns></returns>
        static bool CheckZero(List<bool> Arguments, bool Resultat)
        {
            // флаг того, что все элементы нулевые
            bool Zero = true;
            // проверяем все значанеия функции на ноль
            foreach (bool Item in Arguments)
            {
                if (Item == false)
                    continue;
                else
                {
                    // если есть хоть одно истинное значение 
                    Zero = false;
                    break;
                }
            }
            if (Zero && !Resultat)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Проверяет на принадлежность к второму типу (сохраняющей 1)
        /// </summary>
        /// <param name="Arguments"></param>
        /// <param name="Resultat"></param>
        /// <returns></returns>
        static bool CheckOne(List<bool> Arguments, bool Resultat)
        {
            bool OnlyOne = true;

            foreach (bool Item in Arguments)
            {
                if (Item)
                    continue;
                else
                {
                    OnlyOne = false;
                    break;
                }
            }

            if (OnlyOne && Resultat)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Метод ответственный за контроль ввода целых значений с клавиатуры
        /// </summary>
        /// <param name="OnlyPositive">Проверять на положительные значения</param>
        /// <param name="ExceptZero">Проверять на ноль</param>
        /// <returns></returns>
        public static int CheckInput(bool OnlyPositive = false, bool ExceptZero = false, bool OnlyOne = false)
        {
            int resultat = 0;
            bool ok = false;
            do
            {
                string InputetString = Console.ReadLine();
                try
                {
                    resultat = Convert.ToInt32(InputetString);
                    ok = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка ввода!!! Необходимо ввести целое число!!!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Повторите ввод");
                    ok = false;
                }
                if (ok == true)
                {
                    // проверим условия заданные в параметрах метода
                    if (OnlyPositive)
                    {
                        if (resultat < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка !!! Необходимо ввести целое положительное значение!!!");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Повторите ввод");
                            ok = false;
                        }
                    }
                    if (ExceptZero)
                    {
                        if (resultat == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка !!! Значение не должно равняться нулю!!!");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Повторите ввод");
                            ok = false;
                        }
                    }
                    if (OnlyOne)
                    {
                        if (resultat != 0 && resultat != 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка !!! Значение должно быть либо 0 либо 1");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Повторите ввод");
                            ok = false;
                        }
                    }
                }
            } while (ok == false);
            return resultat;
        }



    }
}
