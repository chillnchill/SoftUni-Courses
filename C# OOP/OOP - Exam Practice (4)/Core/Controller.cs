using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Repositories.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IUniversity> universities;
        private readonly IRepository<IStudent> students;
        private readonly IRepository<ISubject> subjects;
        public Controller()
        {
            universities = new UniversityRepository();
            students = new StudentRepository();
            subjects = new SubjectRepository();
        }

        public string AddStudent(string firstName, string lastName)
        {
            string name = firstName + " " + lastName;
            var exists = students.FindByName(name);

            if (exists != null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            IStudent student = new Student(0, firstName, lastName);
            students.AddModel(student);
            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            ISubject subject = subjects.FindByName(subjectName);
            int count = 2;


            if (subject != null && subject.Name == subjectName)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            if (subjectType == nameof(EconomicalSubject))
            {
                subject = new EconomicalSubject(0, subjectName);
            }
            else if (subjectType == nameof(HumanitySubject))
            {
                subject = new HumanitySubject(0, subjectName);
            }
            else if (subjectType == nameof(TechnicalSubject))
            {
                subject = new TechnicalSubject(0, subjectName);
            }
            else
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            subjects.AddModel(subject);
            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects.GetType().Name);

        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            IUniversity university;
            var exists = universities.FindByName(universityName);

            if (exists != null && exists.Name == universityName)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }


            List<int> reqSubjectNums = requiredSubjects.Select(s => subjects.FindByName(s).Id).ToList();
            university = new University(0, universityName, category, capacity, reqSubjectNums);
            universities.AddModel(university);
            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);

        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] name = studentName.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string first = name[0];
            string last = name[1];

            IStudent student = students.FindByName(studentName);
            IUniversity university = universities.FindByName(universityName);

            if (student == null)
            {
                return string.Format(OutputMessages.StudentNotRegitered, first, last);
            }
            if (university == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }
            if (!university.RequiredSubjects.SequenceEqual(student.CoveredExams))
            {
                return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }
            if (student.University == university)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined, first, last, universityName);
            }
            student.JoinUniversity(university);

            return string.Format(OutputMessages.StudentSuccessfullyJoined, first, last, universityName);

        }

        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = students.FindById(studentId);
            ISubject subject = subjects.FindById(subjectId);

            if (student == null)
            {
                return string.Format(OutputMessages.InvalidStudentId);
            }
            if (subject == null)
            {
                return string.Format(OutputMessages.InvalidSubjectId);
            }
            if (student.CoveredExams.Contains(subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);
            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string UniversityReport(int universityId)
        {
            
            IUniversity university = universities.FindById(universityId);
            List<IStudent> count = students.Models.Where(u => u.University == university).ToList();
            StringBuilder result = new StringBuilder();

            result.AppendLine($"*** {university.Name} ***");
            result.AppendLine($"Profile: {university.Category}");
            result.AppendLine($"Students admitted: {count.Count}");
            result.AppendLine($"University vacancy: {university.Capacity - count.Count}");

            return result.ToString().TrimEnd();
        }
    }
}
