namespace ConsoleApp1
{
    public class Person
    {
        public string Name;
        public int Age;

        public Person(string n, int a)
        {
            Name = n;
            Age = a;    
        }

        public override string ToString()
        {
            return $"{Name}    {Age}"; 
        }
    }



    public class ArOper
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }

        public int Minus(int a, int b)
        {
            return a - b;
        }
        public int Mult(int a, int b)
        {
            return a * b;
        }
        public int Div(int a, int b)
        {
            return a / b;
        }

        public void Hello1()
        {
            Console.WriteLine("Hello 1!");
        }

        public void Hello2()
        {
            Console.WriteLine("Hello 2!");
        }

    }


    public class Program
    {

        //delegate int MyDeleg(int k, int l);
        //delegate void Message();
        

        public static void Main()
        {
            ArOper oper = new ArOper();
            //MyDeleg deleg = new MyDeleg(oper.Sum); 

            Func<int, int, int> deleg = (a, b) => a + b;

            Console.WriteLine(deleg(5, 3));

            deleg = (a, b) => 2*a - b;

            Console.WriteLine(deleg(5, 3));

            //deleg = delegate (int k, int l)
            //{
            //    return k * l;
            //};

            //Console.WriteLine(deleg(5, 3));

            //deleg = oper.Minus;

            //Console.WriteLine(deleg(5, 3));

            //deleg = oper.Mult;

            //Console.WriteLine(deleg(5, 3));

            //deleg = oper.Div;

            //Console.WriteLine(deleg.Invoke(5, 3));

            Action mess = new Action(oper.Hello1);
           
            mess = () => { Console.WriteLine("Hello from labda"); };

            mess.Invoke();

            mess += oper.Hello2;
            
            mess?.Invoke();


            int[] arr = { 2, 3, 4, 6, 8, 9, 109, 45, 32, 13, 43 };


            Console.WriteLine($"length = {arr.Length}");

            var lst = arr.Where(k => k % 2 != 0).OrderBy(k=>-k).TakeLast(2);

            foreach (int k in lst)
                Console.WriteLine(k);

            List<Person> pers = new List<Person>();
            pers.Add(new Person("Tom", 23));
            pers.Add(new Person("Bob", 27));
            pers.Add(new Person("Sam", 29));
            pers.Add(new Person("Alice", 34));



            var per = pers.Where(p => p.Age > 23).OrderBy(p=>p.Name).Select(p => p.Name);
            foreach (var k in per)
                Console.WriteLine(k);


        }
    }
}