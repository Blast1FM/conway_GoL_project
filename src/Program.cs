using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    public class Life
    {
        int n;
        int m;
        int[,] arr;
        public int N
        {
            get { return n; }
            set { n = value; }
        }
        public int M
        {
            get { return m; }
            set { m = value; }
        }
        public void SetArr()
        {
            arr = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    arr[i, j] = Convert.ToInt32(Console.ReadLine());
        }
        public void ReadArr()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(arr[i, j].ToString() + " ");
                Console.WriteLine("");
            }
        }
        public void RandomSetArr()
        {
            arr = new int[n, m];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    arr[i, j] = rnd.Next(0, 2);
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            //цикл проверок (рекурсия шагов игры)
            void Step(Life l)
            {

            }
            //меню игры - выбор режима, установка размерности поля
            int Menu(Life l)
            {
                Console.WriteLine("Выберите режим игры");
                Console.WriteLine("1. Автоматическая игра (первоначальная позиция <живых> клеток расставляется рандомно)");
                Console.WriteLine("2. Классическая игра (пользователь сам расставляет <живые> клетки)");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите размерность поля N*M, каждое число с новой строки");
                l.N = Convert.ToInt32(Console.ReadLine());
                l.M = Convert.ToInt32(Console.ReadLine());
                return a;
            }
            //поле
            Life lifeObj = new Life();

            switch (Menu(lifeObj))
            {
                //автоматическая игра
                case 1:
                    lifeObj.RandomSetArr();
                    Console.WriteLine("Поле:");
                    lifeObj.ReadArr();
                    Step(lifeObj);//запусткаем цикл проверок
                    break;
                //классическая игра
                case 2:
                    Console.WriteLine("Введите число, которое будет инициализировать клетку <живой> или <мертвой>");
                    Console.WriteLine("Каждое значение с новой строки");
                    Console.WriteLine("1. Клетка <живая>");
                    Console.WriteLine("2. Клетка <мертвая>");
                    lifeObj.SetArr();
                    Console.WriteLine("Поле:");
                    lifeObj.ReadArr();
                    Step(lifeObj);//запускаем цикл проверок
                    break;
            }

            Console.ReadKey();
        }
    }
}
