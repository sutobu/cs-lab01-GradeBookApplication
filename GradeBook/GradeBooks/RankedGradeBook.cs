﻿using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
            Name = name;
            IsWeighted = isWeighted;
        }

        public override char GetLetterGrade(double averageGrade)
        {

            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }
            var sortedGrades = Students.OrderByDescending(s => s.AverageGrade).ToList();
            int studentPlace = 1;
            foreach (var student in sortedGrades)
            {
                if (averageGrade < student.AverageGrade)
                {
                    studentPlace++;
                }
            }
            double studentPercentage = studentPlace * 100 / (sortedGrades.Count + 1);
            if (studentPercentage <= 20)
            {
                return 'A';
            }
            else if (studentPercentage <= 40)
            {
                return 'B';
            }
            else if (studentPercentage <= 60)
            {
                return 'C';
            }
            else if (studentPercentage <= 80)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }

        public override void CalculateStatistics()
        {

            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {

            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
