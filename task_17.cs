using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Vehicle // ����� � ������� ������������� ��
    {
        private String _model; // ������ ��
        public String Model { get { return _model; } set { _model = value; } }
        private String _color; // ���� ��
        public String Color { get { return _color; } set { _color = value; } }
        private double _speed; // �������� ��
        public double Speed { get { return _speed; } set { _speed = value; } }
        public virtual string GetWheelsNumber() { return "���-�� ����� �� " +
                "������"; } // ���-�� ����� ��

        public void ChangeColor(String new_color) { Color = new_color; }

        public void ChangeSpeed(double add_speed) { Speed += add_speed; }
    }

    class Motorcycle : Vehicle // ������������ ���������
    {
        public override string GetWheelsNumber() { return "�������� - 2" +
                "������"; }

        public Motorcycle(String m, String c, double s)
        {
            Model = m;
            Color = c;
            Speed = s;
        }
    }

    class Car : Vehicle // ������������ ����������
    {
        public override string GetWheelsNumber() { return "���������� - 4" +
                " ������"; }

        public Car(String m, String c, double s)
        {
            Model = m;
            Color = c;
            Speed = s;
        }
    }

    class Person // ����� ������������ � ������� ������������ ��������
    {
        private String _name; // ���
        public String Name { get { return _name; } set { _name = value; } }
        private int _age; // �������
        public int Age { get { return _age; } set { _age = value; } }
        public virtual string Role() { return "���� �� ������"; } // ���� � 
                                                                  // �������
                                                                  // ��������
    }
    class Student : Person // ����� �������
    {
        public override string Role() { return "�������"; }
        public string[] subjects; // ��������� ��������
        public void ChangeAgeNewCourse(int new_age) { Age += new_age; } // ����������
                                                                        // �������� 
                                                                        // � ����� 
                                                                        // ������

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
    class Teacher : Person // ����� �������������
    {
        public int GroupsNumber; // ���������� ����� ��������� � �������������
        public override string Role() { return "�������������"; } // ���� � 
                                                                  // ������� 
                                                                  // ��������
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
            Console.WriteLine("������� ������������ �������");
            Car FirstVehicle = new Car("BMW", "�����", 70.5);
            Console.WriteLine($"������: {FirstVehicle}");
            Console.WriteLine($"������ ��: {FirstVehicle.Model}");
            Console.WriteLine($"���� ��: {FirstVehicle.Color}");
            Console.WriteLine($"�������� ��: {FirstVehicle.Speed} ��/�");
            Console.WriteLine(FirstVehicle.GetWheelsNumber());
            FirstVehicle.ChangeColor("�������");
            FirstVehicle.ChangeSpeed(-20);
            Console.WriteLine($"����� ���� ��: {FirstVehicle.Color}");
            Console.WriteLine($"����� �������� ��: {FirstVehicle.Speed} ��/�");
            Motorcycle SecondVehicle = new Motorcycle("Yamaha", "�������",
                175);
            Console.WriteLine($"������: {SecondVehicle}");
            Console.WriteLine($"������ ��: {SecondVehicle.Model}");
            Console.WriteLine($"���� ��: {SecondVehicle.Color}");
            Console.WriteLine($"�������� ��: {SecondVehicle.Speed} ��/�");
            Console.WriteLine(SecondVehicle.GetWheelsNumber());
            SecondVehicle.ChangeColor("������");
            SecondVehicle.ChangeSpeed(30);
            Console.WriteLine($"����� ���� ��: {SecondVehicle.Color}");
            Console.WriteLine($"����� �������� ��: {SecondVehicle.Speed} ��/�");
            Console.WriteLine("-------------------");
            Motorcycle ThirdVehicle = new Motorcycle("KAWASAKI", "�����", 
                105);
            Motorcycle FourthVehicle = new Motorcycle("HONDA", "������", 150);
            Motorcycle FifthVehicle = new Motorcycle("Harley Davidson", "�����",
                90);
            Car SixthVehicle = new Car("Cadillac", "����������", 90);
            Car SeventhVehicle = new Car("Chevrolet", "�������", 120);
            Car EighthVehicle = new Car("Daewoo", "������", 60);
            Car NinthVehicle = new Car("Daewoo", "������", 60);
            Car TenthVehicle = new Car("Ferrari", "�������", 180);
            Vehicle[] Polymorphism = new Vehicle[10];
            Polymorphism[0] = FirstVehicle;
            Polymorphism[1] = SecondVehicle;
            Polymorphism[2] = ThirdVehicle;
            Polymorphism[3] = FourthVehicle;
            Polymorphism[4] = FifthVehicle;
            Polymorphism[5] = SixthVehicle;
            Polymorphism[6] = SeventhVehicle;
            Polymorphism[7] = EighthVehicle;
            Polymorphism[8] = NinthVehicle;
            Polymorphism[9] = TenthVehicle;
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
            Console.WriteLine("������� � ������� ��������");
            Student NewStudent = new Student("��������� ���������� �������", 
                20, new string[3] { "���������� ����������", "����������������",
                "������" });
            Console.WriteLine($"������: {NewStudent}");
            Console.WriteLine($"���� ������� � �������: {NewStudent.Role()}");
            Console.WriteLine($"���: {NewStudent.Name}");
            Console.WriteLine($"������� (���): {NewStudent.Age}");
            Console.Write("��������� ��������: ");
            for (int i = 0; i < NewStudent.subjects.Length; i++)
                Console.Write($" {NewStudent.subjects[i]}");
            Console.WriteLine();
            NewStudent.ChangeAgeNewCourse(1);
            NewStudent.AddSubject("������ ������������");
            Console.WriteLine($"������� �� ����� ����� (���): {NewStudent.Age}");
            Console.Write("��������� �������� �� ����� �����: ");
            for (int i = 0; i < NewStudent.subjects.Length; i++)
                Console.Write($" {NewStudent.subjects[i]}");
            Console.WriteLine();
            Teacher NewTeacher = new Teacher("������ ����������� �����", 57, 
                17);
            Console.WriteLine($"������: {NewTeacher}");
            Console.WriteLine($"���� ������� � �������: {NewTeacher.Role()}");
            Console.WriteLine($"���: {NewTeacher.Name}");
            Console.WriteLine($"������� (���): {NewTeacher.Age}");
            Console.WriteLine($"���������� ����� ���������: " +
                $"{NewTeacher.GroupsNumber}");
            NewTeacher.ChangeGroupsNumber(20);
            Console.WriteLine($"���������� ����� ��������� � ����� ������� " +
                $"����: {NewTeacher.GroupsNumber}");
        }
    }
}
