using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Text;
using Dapper;
using StudentExercises.Data;
using StudentExercises;

namespace StudentExercises {
    class Program {
        static void Main (string[] args) {
            // Create exercises
            Exercise LittleDebbie = new Exercise () {
                ExerciseName = "Little Debbie",
                Language = "JavaScript"
            };
            Exercise Probes = new Exercise () {
                ExerciseName = "Probes",
                Language = "C#"
            };
            Exercise Nutshell = new Exercise () {
                ExerciseName = "Nutshell",
                Language = "Alluvem"
            };

            // Create cohorts
            Cohort Twenty6 = new Cohort () {
                CohortName = "26",
            };
            Cohort Twenty7 = new Cohort () {
                CohortName = "27"
            };
            Cohort Twenty8 = new Cohort () {
                CohortName = "28"
            };

            // Create students
            Student Mike = new Student () {
                StudentFirstName = "Michael",
                StudentLastName = "McClenton",
                StudentSlackId = "@night",
                Cohort = Twenty6,

            };
            // Add me to the student list inside Cohort.cs
            Twenty7.studentsList.Add(Mike);

            Student John = new Student () {
                StudentFirstName = "John",
                StudentLastName = "Wood",
                StudentSlackId = "@JohnWood",
                Cohort = Twenty8,

            };
            // Add to 28
            Twenty8.studentsList.Add(John);

            Student Dez = new Student () {
                StudentFirstName = "Desmond",
                StudentLastName = "N`uts",
                StudentSlackId = "@dez",
                Cohort = Twenty7,

            };
            Twenty7.studentsList.Add(Dez);

            Student Bob = new Student () {
                StudentFirstName = "Bob",
                StudentLastName = "Saggett",
                StudentSlackId = "@Saggett",
                Cohort = Twenty6,

            };
            Twenty6.studentsList.Add(Bob);

            Student Sonny = new Student () {
                StudentFirstName = "Sonny",
                StudentLastName = "Cheeba",
                StudentSlackId = "@Cheeba",
                Cohort = Twenty6,
            };
            Twenty6.studentsList.Add(Sonny);


            // Create instructors
            Instructor Meg = new Instructor () {
                InstFirstName = "Meg",
                InstLasttName = "Ducharme",
                InstSlackHandle = "@meg",
                InstCohort = "27"
            };
            Instructor Steve = new Instructor () {
                InstFirstName = "Steve",
                InstLasttName = "Brownlee",
                InstSlackHandle = "@coach",
                InstCohort = "26"
            };
            Instructor Jenna = new Instructor () {
                InstFirstName = "Jenna",
                InstLasttName = "Solis",
                InstSlackHandle = "@jenna",
                InstCohort = "28"
            };
            Instructor Brenda = new Instructor () {
                InstFirstName = "Brenda",
                InstLasttName = "Long",
                InstSlackHandle = "@bLong",
                InstCohort = "27"
            };
            // Give students assignments from instructors
            Meg.GiveAssignment (LittleDebbie, Mike);
            Meg.GiveAssignment (Probes, Mike);
            Meg.GiveAssignment (Nutshell, Mike);

            Brenda.GiveAssignment (LittleDebbie, John);
            Brenda.GiveAssignment (Nutshell, John);

            Steve.GiveAssignment (Probes, Bob);
            Steve.GiveAssignment (Nutshell, Bob);

            Jenna.GiveAssignment (LittleDebbie, Dez);
            Jenna.GiveAssignment (Nutshell, Dez);

            List<Student> students = new List<Student> ();
            students.Add (Mike);
            students.Add (John);
            students.Add (Dez);
            students.Add (Bob);
            students.Add (Sonny);

            List<Exercise> exercises = new List<Exercise> ();
            exercises.Add (LittleDebbie);
            exercises.Add (Probes);
            exercises.Add (Nutshell);

            List<Cohort> cohorts = new List<Cohort> ();
            cohorts.Add (Twenty6);
            cohorts.Add (Twenty7);
            cohorts.Add (Twenty8);

            List<Instructor> instructors = new List<Instructor>();
            instructors.Add(Meg);
            instructors.Add(Steve);
            instructors.Add(Jenna);
            instructors.Add(Brenda);

            // List exercises with LINQ Where()
            var JSExersise = from ex in exercises
            where ex.Language.Contains ("JavaScript")
            orderby ex
            select ex;

            foreach (Exercise ex in JSExersise) {
                // Console.WriteLine(ex.ExerciseName);
            }
            // List students in a cohort
            var StudentCohorts = from stu in students
            where stu.Cohort.CohortName.Contains ("26")
            select stu;

            foreach (Student stu in StudentCohorts) {
                // Console.WriteLine (stu.StudentFirstName);
            }
            // List instructors for a cohort
            var InstCohorts = from ins in instructors
            where ins.InstCohort.Contains("27")
            select ins;

            foreach(Instructor ins in InstCohorts){
                // Console.WriteLine(ins.InstFirstName);
            }
            // List students by last name
            List<Student> byLastName = students.OrderBy(lastname => lastname.StudentLastName).ToList();
            foreach(Student lastname in byLastName){
                // Console.WriteLine(lastname.StudentLastName);
            }
            // Students with no work to do
            List<Student> noWork = students.Where(work => work.StudentExercises.Count==0).ToList();
            foreach(Student student in noWork){
                // Console.WriteLine(student.StudentFirstName);
            }
            // Who has the most assignments
            List<Student> mostWork = students.Where(most => most.StudentExercises.Count>2).ToList();
            foreach(Student stu in mostWork){
                // Console.WriteLine(stu.StudentFirstName);
            }

            // How many students in each cohort
            foreach (Cohort coh in cohorts){
                // Console.WriteLine(coh.studentsList.Count);
            }










            // Loop over students
            foreach (Student student in students) {
                // Loop over exercises
                foreach (Exercise exercise in exercises) {
                    // Loop over exercises again in order to match with previous loop
                    foreach (Exercise match in exercises) {
                        // If first exercise loop matches the second then write to console
                        if (exercise == match);
                        //   Console.WriteLine($"{student.StudentFirstName}"+" is working on "+ $"{exercise.ExerciseName}");

                    }
                }
            }


            
            SqliteConnection NewConnection = DatabaseInterface.NewConnection;
            DatabaseInterface.CheckExerciseTable();

            // IEnumerable<Exercise> newExerciseList = NewConnection.Query<Exercise>(@"SELECT * from Exercise");
            // exercises.ForEach(ex => Console.WriteLine($"{ex.ExerciseName}"));
            NewConnection.Query<Exercise>(@"
                SELECT * FROM Exercise
                where Exercise.Language == 'JavaScript'
            ")
            .ToList()
            .ForEach(jsex => Console.WriteLine($"{jsex.ExerciseName}"));

        }


    }

}