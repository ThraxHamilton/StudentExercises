using System.Collections.Generic;

namespace StudentExercises {
    public class Cohort {
        public string CohortName {get; set;}
     public List<Student> studentsList = new List<Student>();
     public List<Instructor> instructorList = new List<Instructor>();

    }
}