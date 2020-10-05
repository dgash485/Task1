﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Task1
{
    class Student 
    {
        public string Name { get; private set;}
        public int Age { get; private set;}
        public int Group { get; private set;}
        public double AverageScore { get; private set;}

        public Student(string name, int age, int group, double averageScore)
        {
            Name = name;
            Age = age;
            Group = group;
            AverageScore = averageScore;
        }
    }

    class Program
    {

        static Student[] ThreeBestStudents(Student[] students)
        {
            return students
                .OrderByDescending(student => student.AverageScore)
                .Take(3)
                .ToArray();
            //Array.Sort(students);

            //int length = students.Length;

            //return new Student[] {students[length - 1], students[length - 2], students[length - 3]};
        }

        static int CountBestStudents(Student[] students)
        {
            return students
                .Where(student => student.AverageScore == students.Max(student => student.AverageScore))
                .Count();
        }

        static int CountWorstStudents(Student[] students)
        {
            return students
                .Where(student => student.AverageScore == students.Min(student => student.AverageScore))
                .Count();
        }

        static Student[] GetBestStudentsForGroup(int group, Student[] students)
        {
            return students
                .Where(student => student.Group == group)
                .GroupBy(student => student.AverageScore)
                .OrderByDescending(group => group.Key)
                .First()
                .ToArray();
        }

        static void PrintStudents(Student[] students)
        {
            foreach(var student in students)
            {
                Console.WriteLine($"{student.Name} {student.Age} {student.Group} {student.AverageScore}");
            }
        }

        static void PrintBestStudentsForGroup(List<int> groups, Student[] students)
        {
            foreach(var group in groups)
            {
                Console.WriteLine($"Лучшие студенты группы {group}: ");
                PrintStudents(GetBestStudentsForGroup(group, students));
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            var students = new Student[]
            {
                new Student("Danil", 19, 4434, 4.9),
                new Student("Ivan", 19, 4434, 4.4),
                new Student("Dmitriy", 19, 4434, 4.9),
                new Student("Katya", 20, 4102, 4.9),
                new Student("Masha", 19, 4102, 4.9),
                new Student("Misha", 20, 4102, 4.7),
                new Student("Petya", 22, 3407, 3.8),
                new Student("Irina", 21, 3407, 4.2),
                new Student("Uriy", 18, 5102, 4.7),
                new Student("Alexander", 18, 5102, 3.4)
            };

            var bestStudents = ThreeBestStudents(students);
            var groups = students.Select(student => student.Group).Distinct().ToList();

            PrintStudents(bestStudents);
            Console.WriteLine();
            Console.WriteLine("Количество студентов с максимальным баллом: {0}", CountBestStudents(students));
            Console.WriteLine("Количество студентов с минимальным баллом: {0}", CountWorstStudents(students));
            Console.WriteLine();
            PrintBestStudentsForGroup(groups, students);
        }
    }
}