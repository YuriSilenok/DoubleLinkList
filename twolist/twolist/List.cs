using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace twolist
{
    class Element
    {
        int Inf;
        Element Next;
        Element Prev;
        public Element(int tmp)
        {
            Inf = tmp;
            Next = null;
            Prev = null;
        }
        public int inf
        {
            set { Inf = value; }
            get { return Inf; }

        }

        public Element next
        {
            set { Next = value; }
            get { return Next; }
        }
        public Element prev
        {
            set { Prev = value; }
            get { return Prev; }
        }
    }

    class DoubleLinkList
    {
        Element Head = null;
        Element Last = null;
        int count=0;
        /// <summary>
        /// Добавление в начало (метод №1)
        /// </summary>
        /// <param name="a"></param>
        public void AddBegin(int a)
        {
            Element nE = new Element(a);
            if (Head != null)
            {
                nE.next = Head;
                Head.prev = nE;
                Head = nE;
            }
            else { Head = Last = nE; }
            count++;
        }
        /// <summary>
        /// Добавление в конец (метод №2)
        /// </summary>
        /// <param name="a"></param>
        public void AddEnd(int a)
        {
            Element newElement = new Element(a);
            if (Last != null)
            {
                newElement.prev = Last;
                Last.next = newElement;
                Last = newElement;
            }
            else { Head = Last = newElement; }
            count++;
        }
        /// <summary>
        /// Количество элементов в списке
        /// </summary>
        public int Count
        {
            get
            {
                return count;
            }

        }
        /// <summary>
        /// Вывод списка на экран (метод №3)
        /// </summary>
        public string Output()
        {
            string result = "";
            if (Count == 0)
                return result;
            Element p = Head;
            while (p != null)
            {
                result += p.inf + "\t";
                p = p.next;
            }
            return result;
        }
        /// <summary>
        /// Поиск элемента по его номеру в списке (метод №4)
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns></returns>
        public int Search(int index)
        {
            if (index < 0 || index >= count) throw new Exception("Индекс вне диапазона элементов");
            Element p = Head;
            int iter = 0;
            while (iter != index)
            {
                if(p==null) throw new Exception("Элемента не существует");
                iter++;
                p = p.next;
            }
            return p.inf;
        }
        /// <summary>
        /// Поиск элемента по его значению (метод №5)
        /// </summary>
        /// <param name="item">Значение</param>
        /// <returns></returns>
        public int Find(int item)
        {           
            Element p = Head;
            for (int indexRersult = 0; p != null; indexRersult++, p=p.next)
                if (p.inf == item) 
                    return indexRersult;
            return -1;
        }
        /// <summary>
        /// Добавление элемента перед заданным (метод №6)
        /// </summary>
        /// <param name="beforeThisIndex">Перед этим индексом</param>
        /// <param name="addItem">Добавляемый элемент</param>
        public void Addbefore(int beforeThisIndex, int addItem)
        {
            int count = Count;
            if (Count > 0)
            {
                Element p = Head;
                for (int i = 0; p != null; i++, p = p.next)
                {
                    if (beforeThisIndex == i)
                    {
                        Element nE = new Element(addItem);
                        nE.next = p;
                        nE.prev = p.prev;
                        if (p.prev != null)
                        {
                            p.prev.next = nE;
                            p.prev = nE;
                        }
                        else Head = nE;
                        return;
                    }
                }
                throw new Exception("Индекс вне диапазона элементов");
            }
            else AddBegin(addItem);
        }
        /// <summary>
        /// Добавление элемента после заданного (метод №7)
        /// </summary>
        /// <param name="afterThisIndex">После этого индекса</param>
        /// <param name="addItem">Добавляемый элемент</param>
        public void Addafter(int afterThisIndex, int addItem)
        {
            int count = Count;
            if (Count > 0)
            {
                Element p = Head;
                for (int i = 0; p != null; i++, p = p.next)
                {
                    if (afterThisIndex == i)
                    {
                        Element nE = new Element(addItem);
                        nE.prev = p;
                        nE.next = p.next;
                        if (p.next != null)
                        {
                            p.next.prev = nE;
                            p.next = nE;
                        }
                        else Last = nE;
                        return;
                    }
                }
                throw new Exception("Индекс вне диапазона элементов");
            }
            else AddBegin(addItem);
        }
        /// <summary>
        /// Удаление элемента из начала списка (метод №8)
        /// </summary>
        public void DelBegin()
        {
            if (Head != null)
            {
                if (Head.next != null)
                {
                    Head.next.prev = null;
                    Head = Head.next;
                }
                else  Head = Last = null; 
            }

        }
        
        /// <summary>
        /// Удаление из конца списка (метод №9)
        /// </summary>
        public void DelEnd()
        {
            if (Last != null)
            {
                if (Last.prev != null)
                {
                    Last.prev.next = null;
                    Last = Last.prev;
                }
                else Head = Last = null; 
            }
            //else return 0;
        }

        /// <summary>
        /// Удаление элемента перед заданным (метод №10)
        /// </summary>
        /// <param name="beforeThisIndex"></param>
        public void DelBefore(int beforeThisIndex)
        {
            if (Count < 2)
                return;

            int count = Count;
            Element p = Last;
            while ((p.prev != null) && (count != beforeThisIndex))
            {
                p = p.prev;
                count--;
            }
            if (p.prev != null)
            {
                if (p.prev.prev != null)
                {
                    p.prev = p.prev.prev;
                    p.prev.next = p.prev.next.next;
                }
                else
                {
                    p.prev = null;
                    Head = p;
                }
            }
        }
        /// <summary> 
        /// Удаление элемента после заданного (метод №12)
        /// </summary>
        /// <param name="n"></param>
        public void DelAfter(int n)
        {
            if (Count == 0)
                return;
            if (n == Count)
                return;
            int count = 1;
            Element p = Head;
            while ((p.next != null) && (count != n))
            {
                p = p.next;
                count++;
            }
            if (p.next != null)
            {
                if (p.next.next != null)
                {
                    p.next = p.next.next;
                    p.next.prev = p.next.prev.prev;
                }
                else
                {
                    p.next = null;
                    Last = p;
                }
            }

        }
    }
}
