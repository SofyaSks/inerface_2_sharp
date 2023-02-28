using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace @interface
{
    

    class StudentCard
    {
        public int Number { get; set; }
        public string Series { get; set; }
        public override string ToString()
        {
            return $"Студенческий билет: { Series} { Number} ";
        }
    }

    class Student : IComparable, ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public StudentCard StudentCard { get; set; }

        public int Avg { get; set; }

        public object Clone()
        {
            Student tmp = (Student)this.MemberwiseClone(); // поверхностное копирование
            tmp.StudentCard = new StudentCard
            {
                Number = this.StudentCard.Number,
                Series = this.StudentCard.Series
            }; // this можно убрать (берём от того кого клонируем)
                return tmp;

            throw new NotImplementedException();
        }

        public int CompareTo(object obj) // единоразовая акция с одним полем тк одна перегрузка
        {
            if (obj is Student)
            {
                return LastName.CompareTo((obj as Student).LastName);
            }
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {BirthDate.ToShortDateString()} {StudentCard} {Avg}";
        }
    }

    // IEnumerable - статический интерфейс 
    class Auditory : IEnumerable
    {
       public Student[] students =
        {
        new Student {
        FirstName ="John",
        LastName ="Miller",
        BirthDate =new DateTime(1997,3,12),
        StudentCard =new StudentCard { Number=189356, Series="AB" },
        Avg = 10
        },

        new Student {
        FirstName ="Candice",
        LastName ="Leman",
        BirthDate =new DateTime(1998,7,22),
        StudentCard = new StudentCard { Number=345185, Series="XA" },
        Avg = 12
        },
        new Student {
        FirstName ="Joey",
        LastName ="Finch",
        BirthDate = new DateTime(1996,11,30),
        StudentCard = new StudentCard { Number=258322,Series="AA" },
        Avg = 9
        },
        new Student {
        FirstName ="Nicole",
        LastName ="Taylor",
        BirthDate = new DateTime(1996,5,10),
        StudentCard = new StudentCard { Number=513484, Series="AA" },
        Avg = 11
        }
        };

        public IEnumerator GetEnumerator()
        {
            return students.GetEnumerator(); // возвращает адрес на каждый объект
        }

        public void Sort() // CompareTo
        {
            Array.Sort(students);
        }

        public void Sort(IComparer comp)
        {
            Array.Sort(students, comp);
        }

        public void Sort(Class_Avg comp)
        {
            Array.Sort(students, comp);
        }

    }

    class Class_Avg : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x.Avg > y.Avg) return 1;
            else if (x.Avg < y.Avg) return -1;
            else return 0;
        }
    }

    class Class_FN : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                return string.Compare((x as Student).FirstName, (y as Student).FirstName);
            }
            throw new NotImplementedException();
        }
    }

    class Class_BD : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                return DateTime.Compare((x as Student).BirthDate, (y as Student).BirthDate);
            }
            throw new NotImplementedException();
        }
    }


    internal class Program_3
    {
        static void Main(string[] args)
        {
  
            Auditory aud = new Auditory();

            /*WriteLine($"Список  студентов");
            foreach (Student item in aud)
            {
                WriteLine(item);
            }

            WriteLine("****************************");
            aud.Sort();
            foreach (Student item in aud)
            {
                WriteLine(item);
            }

            WriteLine("*************************** SORT First Name **************************");
            aud.Sort(new Class_FN());
            foreach (Student item in aud)
            {
                WriteLine(item);
            }

            WriteLine("*************************** SORT birthday **************************");
            aud.Sort(new Class_BD());
            foreach (Student item in aud)
            {
                WriteLine(item);
            }

            WriteLine("*************************** SORT average **************************");
            aud.Sort(new Class_Avg());
            foreach (Student item in aud)
            {
                WriteLine(item);
            }*/

            WriteLine("*************************** CLONE **************************");
            Student st_tmp = (Student)aud.students[2].Clone();

            WriteLine(aud.students[2]);
            WriteLine(st_tmp);

            aud.students[2].Avg = 4;
            st_tmp.FirstName = "Ivan";

            WriteLine("**************************************************");

            WriteLine(aud.students[2]);
            WriteLine(st_tmp);

            // Сборщик мусора
        }

    }


}
