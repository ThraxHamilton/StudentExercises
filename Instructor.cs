namespace StudentExercises{
    public class Instructor{
        public string InstFirstName {get; set;}
        public string InstLasttName {get; set;}
        public string InstSlackHandle {get; set;}
        public string InstCohort {get; set;}
        // public string Exercises {get; set;}
        // Method to allow instructors to give assignments to students
        public void GiveAssignment (Exercise exercise, Student student){
            // 
            student.StudentExercises.Add(exercise);


            
        }
    }
}