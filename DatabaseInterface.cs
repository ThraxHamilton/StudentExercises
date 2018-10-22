using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Collections;
using Dapper;
using StudentExercises;

namespace StudentExercises.Data {
    public class DatabaseInterface {
        public static SqliteConnection NewConnection {
            get{
                string _connectionString = $"Data Source=./StudentExercises.db";
                return new SqliteConnection(_connectionString);
            }
        }

        public static void CheckExerciseTable() {
            SqliteConnection database  = DatabaseInterface.NewConnection;

            try {
                List<Exercise> exercises =database.Query<Exercise>
                ("Select Id from exercise").ToList();
            }

            catch (SystemException ex) {
                Console.WriteLine("catch");

                if (ex.Message.Contains("no such table"))
                {
                     database.Execute(@"CREATE TABLE `Exercise` (
                        `Id` INTEGER PRIMARY KEY AUTOINCREMENT,
                        `ExerciseName` TEXT NOT NULL,
                        `Language` TEXT NOT NULL
                    )");

                     database.Execute(@"
                    INSERT INTO Exercise (ExerciseName,Language) VALUES ('Little Debbie', 'JavaScript');
                    INSERT INTO Exercise (ExerciseName,Language) VALUES ('Probes', 'C#');
                    INSERT INTO Exercise (ExerciseName,Language) VALUES ('Nutshell', 'Alluvem');
                    ");

                    database.Execute(@"
                    INSERT INTO Exercise (ExerciseName, Language) VALUES ('Student Exercises', 'C#');");
                }
            }
        }
    }
}