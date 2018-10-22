using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dapper;
using Microsoft.Data.Sqlite;
using StudentExercises;

namespace StudentExercises.Data {
    public class DatabaseInterface {
        public static SqliteConnection NewConnection {
            get {
                string _connectionString = $"Data Source=./StudentExercises.db";
                return new SqliteConnection (_connectionString);
            }
        }

        public static void CheckExerciseTable () {
            SqliteConnection database = DatabaseInterface.NewConnection;

            try {
                List<Exercise> exercises = database.Query<Exercise>
                    ("Select Id from exercise").ToList ();
            } catch (SystemException ex) {
                Console.WriteLine ("catch");

                if (ex.Message.Contains ("no such table")) {
                    database.Execute (@"CREATE TABLE `Exercise` (
                        `Id` INTEGER PRIMARY KEY AUTOINCREMENT,
                        `ExerciseName` TEXT NOT NULL,
                        `Language` TEXT NOT NULL
                    )");

                    database.Execute (@"
                    INSERT INTO Exercise (ExerciseName,Language) VALUES ('Little Debbie', 'JavaScript');
                    INSERT INTO Exercise (ExerciseName,Language) VALUES ('Probes', 'C#');
                    INSERT INTO Exercise (ExerciseName,Language) VALUES ('Nutshell', 'Alluvem');
                    ");

                }
            }
        }
        public static void CheckInstTable () {
            SqliteConnection database = DatabaseInterface.NewConnection;

            try {
                Console.WriteLine("yerrr");
                List<Instructor> instructors = database.Query<Instructor>
                    ("Select Id from instructors").ToList ();
            } catch (SystemException ex) {
                Console.WriteLine(ex.Message);
                if (ex.Message.Contains ("no such table")) {
                Console.WriteLine ("luv 2 luv ya");
                    database.Execute (@"CREATE TABLE `Instructor` (
                        `Id` INTEGER PRIMARY KEY AUTOINCREMENT,
                        `InstFirstName` TEXT NOT NULL,
                        `InstLastName` TEXT NOT NULL,
                        `InstSlackHandle` TEXT NOT NULL,
                        `InstCohort` TEXT NOT NULL
                        
                    )");

                    database.Execute (@"
                   INSERT INTO Instructor (InstFirstName, InstLastName, InstSlackHandle, InstCohort) VALUES ('Meg', 'Ducharme', '@meg', '27');

                   INSERT INTO Instructor (InstFirstName, InstLastName, InstSlackHandle, InstCohort) 
                   VALUES ('Steve', 'Brownlee', '@coach', '26');

                   INSERT INTO Instructor (InstFirstName, InstLastName, InstSlackHandle, InstCohort) 
                   VALUES ('Jenna' ,'Solis', '@jenna', '28');

                   INSERT INTO Instructor (InstFirstName, InstLastName, InstSlackHandle, InstCohort) 
                   VALUES('Brenda' , 'Long', '@bLong', '27);
                    ");

                }
            }
        }

    }
}