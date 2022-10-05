﻿using jap_task.Models;
using Microsoft.EntityFrameworkCore;

namespace server.Data.Seeders
{
    public static class StudentsSeeder
    {
        public static void SeedStudents(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
               new Student { Id = 1, FirstName = "Ada", LastName = "Lovelace", StudentStatusId = 1, SelectionId = 1 },
               new Student { Id = 2, FirstName = "Grace", LastName = "Hopper", StudentStatusId = 2, SelectionId = 2 },
               new Student { Id = 3, FirstName = "Joan", LastName = "Clarke", StudentStatusId = 4, SelectionId = 3 },
               new Student { Id = 4, FirstName = "Harry", LastName = "Potter", StudentStatusId = 1, SelectionId = 1 },
               new Student { Id = 5, FirstName = "Hermione", LastName = "Granger", StudentStatusId = 2, SelectionId = 2 },
               new Student { Id = 6, FirstName = "Ron", LastName = "Weasley", StudentStatusId = 3, SelectionId = 3 },
               new Student { Id = 7, FirstName = "Albus", LastName = "Dumbledore", StudentStatusId = 1, SelectionId = 1 },
               new Student { Id = 8, FirstName = "Lord", LastName = "Voldemort", StudentStatusId = 3, SelectionId = 2 },
               new Student { Id = 9, FirstName = "Draco", LastName = "Malfoy", StudentStatusId = 3, SelectionId = 3 },
               new Student { Id = 10, FirstName = "Sirius", LastName = "Black", StudentStatusId = 4, SelectionId = 1 }
               );
        }
    }
}