using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace twolist
{
    class Program
    {
        static DoubleLinkList random(int N)
        {
            DoubleLinkList A = new DoubleLinkList();
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                int g = rnd.Next(0, 10);
                A.AddBegin(g);
            }
            return A;
        }
        /// <summary>
        /// Вывод листа
        /// </summary>
        /// <param name="Q"></param>
        /// <returns></returns>
        static DoubleLinkList conclusion(DoubleLinkList Q)
        {

            Console.WriteLine("Наш лист");
            Q.Output();
            return Q;
        }
        /// <summary>
        /// Поиск по значению элемента
        /// </summary>
        /// <param name="Q"></param>
        /// <returns></returns>
        static DoubleLinkList SearchByItemValue(DoubleLinkList Q)
        {
            Console.WriteLine("Введите значение для поиска");
            int k;
            string s = Console.ReadLine();
            if (int.TryParse(s, out k))
            {
                Console.WriteLine("Поищем");
                if (Q.Find(k) !=-1)
                {
                    Console.WriteLine("Нашел");
                }
                else Console.WriteLine("Такого элемента нет");
            }
            else Console.WriteLine("Error!");
            return Q;
        }
        /// <summary>
        /// Поиск по номеру 
        /// </summary>
        /// <param name="Q"></param>
        /// <returns></returns>
        static DoubleLinkList SearchByNumber(DoubleLinkList Q)
        {

            Console.WriteLine("Введите значение для поиска");
            int k;
            string s = Console.ReadLine();
            if (int.TryParse(s, out k))
                Q.Search(k);
            else Console.WriteLine("Error!");
            return Q;
        }
        /// <summary>
        /// Добавление до заданного
        /// </summary>
        /// <param name="Q"></param>
        /// <returns></returns>
        static DoubleLinkList AddTo(DoubleLinkList Q)
        {
            Console.WriteLine("Введите значение позиции до которой будет вставлен элемент");
            int k;
            string s = Console.ReadLine();
            if (int.TryParse(s, out k))
            {
                int p = 0;
                Console.WriteLine("Введите число для вставки");
                string s1 = Console.ReadLine();
                if (int.TryParse(s1, out p))
                {
                    Q.Addbefore(k, p);
                    Console.WriteLine();
                    Q.Output();
                }
                else Console.WriteLine("Неверное значение!");

            }
            else Console.WriteLine("Error!");
            return Q;
        }
        /// <summary>
        /// Добавление элемента после заданного
        /// </summary>
        /// <param name="Q"></param>
        /// <returns></returns>
        static DoubleLinkList AddAfter(DoubleLinkList Q)
        {
            Console.WriteLine("Введите значение позиции после которой будет вставлен элемент");
            int k;
            string s = Console.ReadLine();
            if (int.TryParse(s, out k))
            {
                int p = 0;
                Console.WriteLine("Введите число для вставки");
                string s1 = Console.ReadLine();
                if (int.TryParse(s1, out p))
                {
                    Q.Addafter(k, p);
                    Console.WriteLine();
                    Q.Output();
                }
                else Console.WriteLine("Неверное значение!");
            }
            else Console.WriteLine("Error!");
            return Q;
        }
        /// <summary>
        /// Добавление в начало
        /// </summary>
        /// <param name="Q"></param>
        /// <returns></returns>
        static DoubleLinkList AddBegin(DoubleLinkList Q)
        {

            int p = 0;
            Console.WriteLine("Введите число для вставки");
            string s1 = Console.ReadLine();
            if (int.TryParse(s1, out p))
            {
                Q.AddBegin(p);
                Console.WriteLine();
                Q.Output();
            }
            else Console.WriteLine("Неверное значение!");
            return Q;

        }
        /// <summary>
        /// Добавление в конец
        /// </summary>
        /// <param name="Q"></param>
        /// <returns></returns>
        static DoubleLinkList AddEnd(DoubleLinkList Q)
        {

            int p = 0;
            Console.WriteLine("Введите число для вставки");
            string s1 = Console.ReadLine();
            if (int.TryParse(s1, out p))
            {
                Q.AddEnd(p);
                Console.WriteLine();
                Q.Output();
            }
            else Console.WriteLine("Неверное значение!");
            return Q;

        }
        /// <summary>
        /// Удаление с начала
        /// </summary>
        /// <param name="Q"></param>
        /// <returns></returns>
        static DoubleLinkList DelBegin(DoubleLinkList Q)
        {
            Q.DelBegin();
            Console.WriteLine();
            Q.Output();
            return Q;
        }
        /// <summary>
        /// Удаление с конца
        /// </summary>
        /// <param name="Q"></param>
        /// <returns></returns>
        static DoubleLinkList DelEnd(DoubleLinkList Q)
        {
            Q.DelEnd();
            Console.WriteLine();
            Q.Output();
            return Q;
        }
        /// <summary>
        /// Удаление до 
        /// </summary>
        /// <param name="Q"></param>
        /// <returns></returns>
        static DoubleLinkList DelTo(DoubleLinkList Q)
        {
            Console.WriteLine("Введите значение для поиска");
            int k;
            string s = Console.ReadLine();
            if (int.TryParse(s, out k))
            {
                Q.DelBefore(k);
                Console.WriteLine();
                Q.Output();
            }
            else Console.WriteLine("Error!");
            return Q;
        }
        /// <summary>
        /// Удаление после
        /// </summary>
        /// <param name="Q"></param>
        /// <returns></returns>
        static DoubleLinkList DelAfter(DoubleLinkList Q)
        {

            Console.WriteLine("Введите значение для поиска");
            int k;
            string s = Console.ReadLine();
            if (int.TryParse(s, out k))
            {
                Q.DelAfter(k);
                Console.WriteLine();
                Q.Output();
            }
            else Console.WriteLine("Error!");
            return Q;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность листа:");
            int N;
            string s = Console.ReadLine();
            if (int.TryParse(s, out N))
            {
                if (N > 0)
                {
                    DoubleLinkList Q = new DoubleLinkList(); //создаем лист
                    Q = random(N); // рандомно заполняем лист
                    Console.WriteLine("Введите номер команды:");
                    Console.WriteLine("1- Вывод на экран");
                    Console.WriteLine("2- Поиск по значению");
                    Console.WriteLine("3- Поиск по номеру элемента");
                    Console.WriteLine("4- Добавление элемента до заданного");
                    Console.WriteLine("5- Добавление элемента после заданного");
                    Console.WriteLine("6- Удаление до");
                    Console.WriteLine("7- Удаление после");
                    Console.WriteLine("8- Добавление в начало");
                    Console.WriteLine("9- Добавление в конец");
                    Console.WriteLine("10- Удаление с начала");
                    Console.WriteLine("11- Удаление с конца");
                    for (int i = 1; ; i++)
                    {
                        int D;
                        Console.WriteLine("Выбрана команда:");
                        string t = Console.ReadLine();
                        if (int.TryParse(t, out D))
                        {
                            switch (D)
                            {
                                case 1: conclusion(Q);
                                    break;
                                case 2: SearchByItemValue(Q);
                                    break;
                                case 3: SearchByNumber(Q);
                                    break;
                                case 4: AddTo(Q);
                                    break;
                                case 5: AddAfter(Q);
                                    break;
                                case 6: DelTo(Q);
                                    break;
                                case 7: DelAfter(Q);
                                    break;
                                case 8: AddBegin(Q);
                                    break;
                                case 9: AddEnd(Q);
                                    break;
                                case 10: DelBegin(Q);
                                    break;
                                case 11: DelEnd(Q);
                                    break;
                                default:
                                    Console.WriteLine("Error!");
                                    break;
                            }
                        }
                        else Console.WriteLine("Error!");
                    }

                }
                else Console.WriteLine("Error!");
            }
            else Console.WriteLine("Error!");
        }
    }
}


                                    

                   
            
        
    

