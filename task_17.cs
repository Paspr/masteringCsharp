using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Vehicle // класс в системе распознавания ТС
    {
        private String _model; // модель ТС
        public String Model { get { return _model; } set { _model = value; } }
        private String _color; // цвет ТС
        public String Color { get { return _color; } set { _color = value; } }
        private double _speed; // скорость ТС
        public double Speed { get { return _speed; } set { _speed = value; } }
        public virtual string GetWheelsNumber() { return "кол-во колес не " +
                "задано"; } // кол-во колес ТС

        public void ChangeColor(String new_color) { Color = new_color; }

        public void ChangeSpeed(double add_speed) { Speed += add_speed; }
    }

    class Motorcycle : Vehicle // Наследование мотоцикла
    {
        public override string GetWheelsNumber() { return "Мотоцикл - 2" +
                "колеса"; }

        public Motorcycle(String m, String c, double s)
        {
            Model = m;
            Color = c;
            Speed = s;
        }
    }

    class Car : Vehicle // Наследование автомобиля
    {
        public override string GetWheelsNumber() { return "Автомобиль - 4" +
                " колеса"; }

        public Car(String m, String c, double s)
        {
            Model = m;
            Color = c;
            Speed = s;
        }
    }

    class Person // класс пользователя в системе электронного обучения
    {
        private String _name; // ФИО
        public String Name { get { return _name; } set { _name = value; } }
        private int _age; // возраст
        public int Age { get { return _age; } set { _age = value; } }
        public virtual string Role() { return "Роль не задана"; } // Роль в 
                                                                  // системе
                                                                  // обучения
    }
    class Student : Person // класс ученика
    {
        public override string Role() { return "Студент"; }
        public string[] subjects; // Изучаемые предметы
        public void ChangeAgeNewCourse(int new_age) { Age += new_age; } // Увеличение
                                                                        // возраста 
                                                                        // с новым 
                                                                        // курсом

        public void AddSubject(string add_subject)
        {
            Array.Resize(ref subjects, subjects.Length + 1);
            subjects[subjects.Length - 1] = add_subject;
        }

        public Student(String n, int a, string[] s)
        {
            Name = n;
            Age = a;
            subjects = s;
        }
    }
    class Teacher : Person // класс преподавателя
    {
        public int GroupsNumber; // количество групп студентов у преподавателя
        public override string Role() { return "Преподаватель"; } // Роль в 
                                                                  // системе 
                                                                  // обучения
        public void ChangeGroupsNumber(int new_number) { GroupsNumber = 
                new_number; }

        public Teacher(String n, int a, int g)
        {
            Name = n;
            Age = a;
            GroupsNumber = g;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.WriteLine("Объекты транспортных средств");
            Car FirstVehicle = new Car("BMW", "Серый", 70.5);
            Console.WriteLine($"Объект: {FirstVehicle}");
            Console.WriteLine($"Модель ТС: {FirstVehicle.Model}");
            Console.WriteLine($"Цвет ТС: {FirstVehicle.Color}");
            Console.WriteLine($"Скорость ТС: {FirstVehicle.Speed} км/ч");
            Console.WriteLine(FirstVehicle.GetWheelsNumber());
            FirstVehicle.ChangeColor("Красный");
            FirstVehicle.ChangeSpeed(-20);
            Console.WriteLine($"Новый цвет ТС: {FirstVehicle.Color}");
            Console.WriteLine($"Новая скорость ТС: {FirstVehicle.Speed} км/ч");
            Motorcycle SecondVehicle = new Motorcycle("Yamaha", "Зеленый",
                175);
            Console.WriteLine($"Объект: {SecondVehicle}");
            Console.WriteLine($"Модель ТС: {SecondVehicle.Model}");
            Console.WriteLine($"Цвет ТС: {SecondVehicle.Color}");
            Console.WriteLine($"Скорость ТС: {SecondVehicle.Speed} км/ч");
            Console.WriteLine(SecondVehicle.GetWheelsNumber());
            SecondVehicle.ChangeColor("Черный");
            SecondVehicle.ChangeSpeed(30);
            Console.WriteLine($"Новый цвет ТС: {SecondVehicle.Color}");
            Console.WriteLine($"Новая скорость ТС: {SecondVehicle.Speed} км/ч");
            Console.WriteLine("-------------------");
            string[] motos = new string[] { "KAWASAKI", "HONDA", "Harley Davidson" };
            string[] cars = new string[] { "Cadillac", "Chevrolet", "Daewoo Davidson", "Ferrari" };
            string[] colors = new string[] { "Черный", "Белый", "Серый", "Золотистый", "Красный", "Зеленый" };
            Vehicle[] Polymorphism = new Vehicle[10];
            for (int i = 0; i < 4; i++) 
            {
                Polymorphism[i] = new Car(cars[rand.Next(0, 3)], colors[rand.Next(0, 6)], rand.Next(60, 150));
            }
            for (int i = 4; i < 8; i++)
            {
                Polymorphism[i] = new Motorcycle(motos[rand.Next(0, 3)], colors[rand.Next(0, 6)], rand.Next(60, 150));
            }
            Polymorphism[8] = FirstVehicle;
            Polymorphism[9] = SecondVehicle;
            for (int i = Polymorphism.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                var temp = Polymorphism[j];
                Polymorphism[j] = Polymorphism[i];
                Polymorphism[i] = temp;
            }
            for (int i = 0; i < Polymorphism.Length; i++)
            {
                Console.WriteLine(Polymorphism[i].GetWheelsNumber());
            }
            Console.WriteLine("-------------------");
            Console.WriteLine("Объекты в системе обучения");
            Student NewStudent = new Student("Александр Евгеньевич Артемов", 
                20, new string[3] { "Дискретная математика", "Программирование",
                "Физика" });
            Console.WriteLine($"Объект: {NewStudent}");
            Console.WriteLine($"Роль объекта в системе: {NewStudent.Role()}");
            Console.WriteLine($"ФИО: {NewStudent.Name}");
            Console.WriteLine($"Возраст (лет): {NewStudent.Age}");
            Console.Write("Изучаемые предметы: ");
            for (int i = 0; i < NewStudent.subjects.Length; i++)
                Console.Write($" {NewStudent.subjects[i]}");
            Console.WriteLine();
            NewStudent.ChangeAgeNewCourse(1);
            NewStudent.AddSubject("Теория вероятностей");
            Console.WriteLine($"Возраст на новом курсе (лет): {NewStudent.Age}");
            Console.Write("Изучаемые предметы на новом курсе: ");
            for (int i = 0; i < NewStudent.subjects.Length; i++)
                Console.Write($" {NewStudent.subjects[i]}");
            Console.WriteLine();
            Teacher NewTeacher = new Teacher("Андрей Григорьевич Белов", 57, 
                17);
            Console.WriteLine($"Объект: {NewTeacher}");
            Console.WriteLine($"Роль объекта в системе: {NewTeacher.Role()}");
            Console.WriteLine($"ФИО: {NewTeacher.Name}");
            Console.WriteLine($"Возраст (лет): {NewTeacher.Age}");
            Console.WriteLine($"Количество групп студентов: " +
                $"{NewTeacher.GroupsNumber}");
            NewTeacher.ChangeGroupsNumber(20);
            Console.WriteLine($"Количество групп студентов в новом учебном " +
                $"году: {NewTeacher.GroupsNumber}");
        }
    }
}
