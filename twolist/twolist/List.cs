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

    public class DoubleLinkList
    {
        Element Head = null;
        Element Last = null;
        int count=0;

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= count) throw new IndexOutOfRangeException();
                Element p = Head;
                for (int i = 0; p != null; i++, p = p.next)
                    if (index == i) return p.inf;
                throw new IndexOutOfRangeException();
            }
        }

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
                        count++;
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
                        count++;
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
                count--;
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
                count--;
            }
        }

        /// <summary>
        /// Удаление элемента перед заданным (метод №10)
        /// </summary>
        /// <param name="beforeThisIndex">Индекс перед которым необходимо удалить</param>
        public void DelBefore(int beforeThisIndex)
        {
            if (count < 2 || beforeThisIndex < 1 || beforeThisIndex > count-1)
                return;

            Element p = Head.next;
            for (int i = 1; p != null; i++, p = p.next)
            {
                if (i == beforeThisIndex)
                {
                    if (p.prev.prev != null) p.prev.prev.next = p;
                    p.prev = p.prev.prev;
                    count--;
                    break;
                }
            }
        }

        /// <summary> 
        /// Удаление элемента после заданного (метод №12)
        /// </summary>
        /// <param name="afterThisIndex">Индекс после которого нужно удалить</param>
        public void DelAfter(int afterThisIndex)
        {
            if (count < 2 || afterThisIndex < 1 || afterThisIndex > count - 1)
                return;

            Element p = Head;
            for (int i = 0; p != null; i++, p = p.next)
            {
                if (i == afterThisIndex)
                {
                    if (p.next != null) break;
                    if(p.next.next != null) p.next.next.prev = p;
                    p.next = p.next.next;
                    count--;
                    break;
                }
            }
        }
        /// <summary>
        /// 15. Вставить  после каждого элемента, занимающего четную позицию в списке, новый элемент Е1
        /// </summary>
        /// <param name="addItem"></param>
        public void AddAfterEven(int addItem) 
        { 
            Element p = Head; 
            //перебор элементов списка и счетчик номера
            for (int i = 1; p != null; i++, p = p.next) 
            { 
                //если номер элемента четный 
                if (i % 2 == 0) 
                { 
                    Element addElement = new Element(addItem); 
                    //ссылка на следующий элемент добавляемого элемента указывает на следующий элемент относительно текущего элемента
                    addElement.next = p.next;
                    //ссылка на предыдущий элементы добавляемого элемента указывает на следующий элемент относительно текущего элемента
                    addElement.prev = p;
                    //если за текущим элементом существует элемент, ссылка на предыдущий элементы последующего элемента относительно текущего элемента указывает на добавляемый элемент
                    if (p.next != null) p.next.prev = addElement;
                    //ссылка на последующий элемент относительно текущего элемента указывает на добавляемый элемент
                    p.next = addElement; 
                    //переход к следующемоу элементу
                    p = p.next; 
                    //увеличение количества элементов
                    count++; 
                } 
            } 
        }

        /// <summary>
        /// 26. Поменять местами первый и последний элементы списка
        /// </summary>
        /// <param name="addItem"></param>
        public void RearrangementOfHeadAndLast(int addItem)
        {
            int h = Head.inf;
            Head.inf = Last.inf;
            Last.inf = h;
        }
    }
}
