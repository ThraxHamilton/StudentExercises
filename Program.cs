using System;
using System.Collections.Generic;

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
                CohortName="28"
            };

            // Create students
            Student Mike = new Student (){
                StudentFirstName = "Michael",
                StudentLastName = "McClenton",
                StudentSlackId = "@night",
                Cohort = "27",

            };
            Student John = new Student (){
                StudentFirstName = "John",
                StudentLastName = "Wood",
                StudentSlackId = "@JohnWood",
                Cohort = "28",

            };
            Student Dez = new Student (){
                StudentFirstName = "Desmond",
                StudentLastName = "N`uts",
                StudentSlackId = "@dez",
                Cohort = "27",

            };
            Student Bob = new Student (){
                StudentFirstName = "Bob",
                StudentLastName = "Saggett",
                StudentSlackId = "@Saggett",
                Cohort = "26",

            };
            // Create instructors
            Instructor Meg = new Instructor (){
                InstFirstName = "Meg",
                InstLasttName = "Ducharme",
                InstSlackHandle ="@meg",
                InstCohort = "27"
            };
            Instructor Steve = new Instructor (){
                InstFirstName = "Steve",
                InstLasttName = "Brownlee",
                InstSlackHandle ="@coach",
                InstCohort = "26"
            };
            Instructor Jenna = new Instructor (){
                InstFirstName = "Jenna",
                InstLasttName = "Solis",
                InstSlackHandle ="@jenna",
                InstCohort = "28"
            };
            Instructor Brenda = new Instructor (){
                InstFirstName = "Brenda",
                InstLasttName = "Long",
                InstSlackHandle ="@bLong",
                InstCohort = "27"
            };
            // Give students assignments from instructors
            Meg.GiveAssignment(LittleDebbie, Mike);
            Meg.GiveAssignment(Probes, Mike);

            Brenda.GiveAssignment(LittleDebbie,John);
            Brenda.GiveAssignment(Nutshell, John);

            Steve.GiveAssignment(Probes, Bob);
            Steve.GiveAssignment(Nutshell, Bob);
            
            Jenna.GiveAssignment(LittleDebbie, Dez);
            Jenna.GiveAssignment(Nutshell, Dez);

            List<Student> students = new List<Student>();
            students.Add(Mike);
            students.Add(John);
            students.Add(Dez);
            students.Add(Bob);

            List<Exercise> exercises = new List<Exercise>();
            exercises.Add(LittleDebbie);
            exercises.Add(Probes);
            exercises.Add(Nutshell);

        



            // Console.WriteLine ($"{students.FirstName}");
       
            foreach(Student student in students){
                foreach(Exercise exercise in exercises){
                    foreach(Exercise match in exercises){
                      if(exercise == match)
                      Console.WriteLine($"{student.StudentFirstName}"+" is working on "+ $"{exercise.ExerciseName}");

                    }
                }
            }
        }
        }
        
    }
