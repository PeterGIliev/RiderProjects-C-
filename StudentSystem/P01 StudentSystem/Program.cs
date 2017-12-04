using System;
using P01_StudentSystem.Data.Models;
using P01_StudentSystem.Data;

namespace P01_StudentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new StudentSystemContext();

            var students = new[]
            {
                new Student(){Name = "Peter", PhoneNumber = "123456", RegisteredOn = new DateTime(2002,9,12)}, 
                new Student(){Name = "Ivan", PhoneNumber = "234324", RegisteredOn = new DateTime(2010,12,23)}, 
                new Student(){Name = "Georgi", PhoneNumber = "5467456", RegisteredOn = new DateTime(1998,4,2)}, 
            };
            
            var courses = new[]
            {
                new Course(){Name = "Math", Description = "AAAAAAA", StartDate = new DateTime(2001,9,12), EndDate = new DateTime(2002,9,12), Price = 120.50m},
                new Course(){Name = "Tech", Description = "BBBBBBB", StartDate = new DateTime(2011,9,12), EndDate = new DateTime(2012,9,12), Price = 180.99m},
                new Course(){Name = "Art", Description = "CCCCCCC", StartDate = new DateTime(1997,9,12), EndDate = new DateTime(1998,9,12), Price = 230.10m}
            };
            
            var resources = new[]
            {
                new Resource(){Name = "Web1", ResourceType = ResourceType.Video, Url = "www.abv.bg", Course = courses[0]}, 
                new Resource(){Name = "Web2", ResourceType = ResourceType.Document, Url = "www.abv.com", Course = courses[1]}, 
                new Resource(){Name = "Web3", ResourceType = ResourceType.Presentation, Url = "www.abv.net", Course = courses[2]}, 
            };
            
            context.Resources.AddRange(resources);

            var studentCourses = new[]
            {
                new StudentCourse(){Student = students[0], Course = courses[2]}, 
                new StudentCourse(){Student = students[1], Course = courses[1]}, 
                new StudentCourse(){Student = students[2], Course = courses[0]}, 
            };
            
            context.StudentCourses.AddRange(studentCourses);

            var homeworkSubmissions = new[]
            {
                new Homework() {Content = "XXXXXXXXX", ContentType = ContentType.Application, SubmissionTime = new DateTime(2001,1,12,11,36,54), SubmissionType = "Number One", Course = courses[0], Student = students[2]},
                new Homework() {Content = "YYYYYYYYY", ContentType = ContentType.Pdf, SubmissionTime = new DateTime(2006,7,3,1,16,34), SubmissionType = "Number Two", Course = courses[1], Student = students[1]},
                new Homework() {Content = "ZZZZZZZZZ", ContentType = ContentType.Zip, SubmissionTime = new DateTime(2013,3,4,8,6,14), SubmissionType = "Number Three", Course = courses[2], Student = students[0]},
            };
            
            context.HomeworkSubmissions.AddRange(homeworkSubmissions);

            context.SaveChanges();

        }
    }
}