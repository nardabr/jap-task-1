using Microsoft.EntityFrameworkCore;
using Server.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Database.Data.Seeders
{
    public static class LectureEventsSeeder
    {
        public static void SeedLectureEvents(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LectureEvent>().HasData(
                new LectureEvent 
                { 
                    Id = 1, 
                    ProgramId = 1, 
                    Type = "Lecture", 
                    Name = "Udemy - React", 
                    Description = "This course will teach you React.js in a practice-oriented way, using all the latest patterns and best practices you need. You will learn all the key fundamentals as well as advanced concepts and related topics to turn you into a React.js developer.", 
                    Url = "https://www.udemy.com/course/react-the-complete-guide-incl-redux/?src=sac&kw=react", 
                    WorkHours = 40, 
                    OrderNumber = 1, 
                    StartDate = new DateTime(2022, 09, 05), 
                    EndDate = new DateTime(2022, 09, 16) 
                },
                new LectureEvent 
                { 
                    Id = 2, 
                    ProgramId = 1, 
                    Type = "Lecture", 
                    Name = "Udemy - .Net Core", 
                    Description = "The .NET framework is getting better and better and more important in the web development world nowadays. Almost every request I get for new web development projects is asking for knowledge in .NET, including Web API and Entity Framework Core. So, knowing the fundamentals of back-end web development with .NET can be highly beneficial to your career. And that’s where this course comes in.", 
                    Url = "https://www.udemy.com/course/net-core-31-web-api-entity-framework-core-jumpstart/", 
                    WorkHours = 20, 
                    OrderNumber = 2, 
                    StartDate = new DateTime(2022, 09, 16), 
                    EndDate = new DateTime(2022, 09, 22) 
                },
                new LectureEvent
                {
                    Id = 3,
                    ProgramId = 1,
                    Type = "Event",
                    Name = "Test Project - Task",
                    Description = "Goal of the project is to build JAP platform. The main idea is to build a platform where we could have evidence of students, selections and programs.",
                    Url = "https://www.udemy.com/",
                    WorkHours = 40,
                    OrderNumber = 3,
                    StartDate = new DateTime(2022, 09, 22),
                    EndDate = new DateTime(2022, 09, 29)
                },
                 new LectureEvent
                 {
                     Id = 4,
                     ProgramId = 1,
                     Type = "Event",
                     Name = "Task Refactoring",
                     Description = "Edit completed assignment",
                     Url = "https://www.udemy.com/",
                     WorkHours = 8,
                     OrderNumber = 4,
                     StartDate = new DateTime(2022, 09, 29),
                     EndDate = new DateTime(2022, 09, 30)
                 },
                 new LectureEvent
                 {
                     Id = 5,
                     ProgramId = 2,
                     Type = "Lecture",
                     Name = "Udemy - Software Testing",
                     Description = "2022 BEST job oriented Software Manual Testing course on real time Project+Interview ques+Resume Prep+ Lifetime Support",
                     Url = "https://www.udemy.com/course/learn-software-testing-in-practical-become-a-qa-expert/?src=sac&kw=qa",
                     WorkHours = 10,
                     OrderNumber = 1,
                     StartDate = new DateTime(2022, 08, 08),
                     EndDate = new DateTime(2022, 08, 11)
                 },
                 new LectureEvent
                 {
                     Id = 6,
                     ProgramId = 2,
                     Type = "Lecture",
                     Name = "Udemy - Manual Testing",
                     Description = "Become a Master in Manual Testing QA with Live Testing Projects, AGILE, JIRA, 100+Interview Questions & Lifetime support",
                     Url = "https://www.udemy.com/course/specialize-in-software-testing-with-real-examples-agile-jira/?src=sac&kw=qa",
                     WorkHours = 10,
                     OrderNumber = 2,
                     StartDate = new DateTime(2022, 08, 11),
                     EndDate = new DateTime(2022, 08, 15)
                 },
                 new LectureEvent
                 {
                     Id = 7,
                     ProgramId = 2,
                     Type = "Event",
                     Name = "Test Project - Task",
                     Description = "Goal of the project is to build JAP platform. The main idea is to build a platform where we could have evidence of students, selections and programs.",
                     Url = "https://www.udemy.com/",
                     WorkHours = 40,
                     OrderNumber = 3,
                     StartDate = new DateTime(2022, 08, 15),
                     EndDate = new DateTime(2022, 08, 23)
                 },
                 new LectureEvent
                 {
                     Id = 8,
                     ProgramId = 2,
                     Type = "Event",
                     Name = "Task Refactoring",
                     Description = "Edit completed assignment",
                     Url = "https://www.udemy.com/",
                     WorkHours = 8,
                     OrderNumber = 4,
                     StartDate = new DateTime(2022, 08, 23),
                     EndDate = new DateTime(2022, 08, 24)
                 },
                 new LectureEvent
                 {
                     Id = 9,
                     ProgramId = 3,
                     Type = "Lecture",
                     Name = "DevOps Beginners to Advanced",
                     Description = "Begin DevOps Career As an Absolute Beginner | Linux, AWS, Scripting, Jenkins, Ansible, Docker, K8s, N-Tier Projects",
                     Url = "https://www.udemy.com/course/decodingdevops/?src=sac&kw=devop",
                     WorkHours = 50,
                     OrderNumber = 1,
                     StartDate = new DateTime(2022, 09, 05),
                     EndDate = new DateTime(2022, 09, 28)
                 },
                 new LectureEvent
                 {
                     Id = 10,
                     ProgramId = 3,
                     Type = "Lecture",
                     Name = "Learn DevOps",
                     Description = "DevOps for Absolute Beginners: Azure DevOps, Docker, Kubernetes, Jenkins, Terraform, Ansible - AWS, Azure & Google Cloud",
                     Url = "https://www.udemy.com/course/devops-with-docker-kubernetes-and-azure-devops/?src=sac&kw=devop",
                     WorkHours = 20,
                     OrderNumber = 2,
                     StartDate = new DateTime(2022, 09, 28),
                     EndDate = new DateTime(2022, 10, 07)
                 },
                 new LectureEvent
                 {
                     Id = 11,
                     ProgramId = 3,
                     Type = "Event",
                     Name = "Test Project - Task",
                     Description = "Goal of the project is to build JAP platform. The main idea is to build a platform where we could have evidence of students, selections and programs.",
                     Url = "https://www.udemy.com/",
                     WorkHours = 40,
                     OrderNumber = 3,
                     StartDate = new DateTime(2022, 10, 07),
                     EndDate = new DateTime(2022, 10, 19)
                 },
                 new LectureEvent
                 {
                     Id = 12,
                     ProgramId = 3,
                     Type = "Event",
                     Name = "Task Refactoring",
                     Description = "Edit completed assignment",
                     Url = "https://www.udemy.com/",
                     WorkHours = 8,
                     OrderNumber = 4,
                     StartDate = new DateTime(2022, 10, 19),
                     EndDate = new DateTime(2022, 10, 20)
                 }
                ); ;
        }
    }
}
