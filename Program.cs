using System;

namespace StudentExercises {
    class Program {
        static void Main (string[] args) {
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



            Cohort Twenty6 = new Cohort () {
                CohortName = "26",
            };
            Cohort Twenty7 = new Cohort () {
                CohortName = "27"
            };
            Cohort Twenty8 = new Cohort () { 
                CohortName="28"
            };


            Console.WriteLine ("Hello World!");
        }
    }
}