class Program
{
    static void Main(string[] args)
    {
        ClassRoom classRoom = new ClassRoom();
        classRoom.Students = new List<Student>();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nStudent Manager");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Remove Student");
            Console.WriteLine("4. Show Average Grade");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option: ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.Write("Enter student name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter student age: ");
                    int age = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter number of grades: ");
                    int numGrades = Convert.ToInt32(Console.ReadLine());

                    List<double> grades = new List<double>();
                    for (int i = 0; i < numGrades; i++)
                    {
                        Console.Write($"Enter grade #{i + 1}: ");
                        double grade = Convert.ToDouble(Console.ReadLine());
                        grades.Add(grade);
                    }

                    Student newStudent = new Student(name, age, grades);
                    classRoom.AddStudent(newStudent);
                    Console.WriteLine("Student added successfully!");
                    break;

                case 2:
                    Console.WriteLine("\nAll students:");
                    classRoom.DisplayStudents();
                    break;

                case 3:
                    Console.Write("Enter the name of the student to remove: ");
                    string nameToRemove = Console.ReadLine();

                    Student toRemove = classRoom.Students.Find(s => s.Name == nameToRemove);
                    if (toRemove != null)
                    {
                        classRoom.RemoveStudent(toRemove);
                        Console.WriteLine("Student removed successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                    break;

                case 4:
                    Console.Write("Enter the name of the student to calculate average: ");
                    string avgName = Console.ReadLine();
                    Student studentToAverage = classRoom.Students.Find(s => s.Name == avgName);

                    if (studentToAverage != null)
                    {
                        double avg = classRoom.GetStudentAvaregGrade(studentToAverage);
                        Console.WriteLine($"Average grade for {avgName}: {avg:F2}");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                    break;

                case 5:
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<double> Grade { get; set; }

    public Student(string name, int age, List<double> grade)
    {
        this.Name = name;
        this.Age = age;
        this.Grade = grade;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Grade: {Grade}");
    }
}
public class ClassRoom{
    public List<Student> Students { get; set; }
   
   public void AddStudent(Student student){
       Students.Add(student);
   }
   public void RemoveStudent(Student student){
       Students.Remove(student);
   }
   public void DisplayStudents(){
       foreach(var student in Students){
           student.DisplayInfo();
       }
   }
   public double GetStudentAvaregGrade(Student student){
         double sum = 0;
         foreach(var grade in student.Grade){
              sum += grade;
         }
         return (double)(sum / student.Grade.Count);
   }
}