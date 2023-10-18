using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    class Program
    {
        //проверка на пустое поле (все клетки мертвы)
        public static bool AreAllDead(Life l)
        {
            int k = 0;
            for (int i = 0; i < l.N; i++)
                for (int j = 0; j < l.M; j++)
                    if (l.GetValue(i, j) == 0) k++;
            if (k == l.N * l.M) return true;
            else return false;
        }
        //вывод поля
        public static void ReadArr(Life l)
        {
            for (int i = 0; i < l.N; i++)
            {
                for (int j = 0; j < l.M; j++)
                    Console.Write(l.GetValue(i, j).ToString() + " ");
                Console.WriteLine();
            }
        }
        //заполнение поля в классическом режиме
        public static void SetArr(ref Life l)
        {
            Console.WriteLine("Введите число, которое будет инициализировать клетку <живой> или <мертвой>");
            Console.WriteLine("Каждое значение с новой строки");
            Console.WriteLine("1. Клетка <живая>");
            Console.WriteLine("2. Клетка <мертвая>");
            //создаем пустой массив поля
            l.CreateArr();

            for (int i = 0; i < l.N; i++)
            {
                for (int j = 0; j < l.M; j++)
                {
                    Console.WriteLine("Клетка i = " + i.ToString() + ", j = " + j.ToString());
                    int a = -1;
                    do
                    {
                        string str1 = Console.ReadLine();
                        //проверяем, является ли числом вводимые данные
                        if (int.TryParse(str1, out int number)) a = Convert.ToInt32(str1);
                    } while (a != 0 && a != 1);
                    //присваиваем значение ячейки поля
                    l.SetValue(i, j, a);
                }
            }
        }
        //меню игры - выбор режима, установка размерности поля
        public static int Menu(Life l)
        {
            Console.WriteLine("Выберите режим игры");
            Console.WriteLine("1. Автоматическая игра (первоначальная позиция <живых> клеток расставляется рандомно)");
            Console.WriteLine("2. Классическая игра (пользователь сам расставляет <живые> клетки)");

            int a = 0;
            do
            {
                //вводим номер режима
                string str1 = Console.ReadLine();
                //проверяем, является ли числом вводимые данные
                if (int.TryParse(str1, out int number)) a = Convert.ToInt32(str1);
            } while (a != 1 && a != 2);

            Console.WriteLine("Введите размерность поля N*M в одну строку");
            do
            {
                //обнуляем предыдущие результаты ввода (если одно из вводимых значений оказалось числом)
                l.N = 0;
                l.M = 0;
                //вводим размерность поля
                string[] str = Console.ReadLine().Split();
                //проверяем, является ли числом вводимые данные
                if (int.TryParse(str[0], out int number)) l.N = int.Parse(str[0]);
                if (int.TryParse(str[1], out int munber)) l.M = int.Parse(str[1]);
            } while (l.N == 0 || l.M == 0);

            return a;
        }
        static void Main(string[] args)
        {
            //поле
            Life lifeObj = new Life();

            switch (Menu(lifeObj))
            {
                //автоматическая игра
                case 1:
                    //заполняем поле рандомными клетками
                    lifeObj.RandomSetArr();
                    //выводим начальную позицию
                    Console.WriteLine("Поле:");
                    ReadArr(lifeObj);
                    //запускаем цикл проверок
                    do
                    {
                        lifeObj.Step();
                        //выводим результат шага
                        Console.WriteLine();
                        ReadArr(lifeObj);
                    } while (!AreAllDead(lifeObj));
                    break;
                //классическая игра
                case 2:
                    //заполняем поле
                    SetArr(ref lifeObj);
                    //выводим начальную позицию
                    Console.WriteLine("Поле:");
                    ReadArr(lifeObj);
                    //запускаем цикл проверок
                    do
                    {
                        lifeObj.Step();
                        //выводим результат шага
                        Console.WriteLine();
                        ReadArr(lifeObj);
                    } while (!AreAllDead(lifeObj));
                    break;
            }

            Console.ReadKey();
        }
    }
}
