using System.Collections.Generic;

namespace StudentExercises{

    public class Student {
        public string StudentFirstName {get; set;}
        public string StudentLastName {get; set;}
        public string StudentSlackId {get; set;}
        public string Cohort {get; set;}
        public List<Exercise> StudentExercises = new List<Exercise>();

    }
}