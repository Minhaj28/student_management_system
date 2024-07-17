using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using BLL.Interfaces;
using BLL.Services;
using DAL.ORM;
using Domain.Classes;

class main_program
{
    /*static List<Student> students = new List<Student>();
    static List<Course> courses = new List<Course>();
    static List<Teacher> teachers = new List<Teacher>();*/
    /*static UserService _userService;
    public main_program(UserService userService)
    {
        _userService = userService;
    }*/

    static void Main(string[] args)
    {

        UserAction userAction = new UserAction();
        UserService userService = new UserService(userAction);

        StudentAction studentAction = new StudentAction();
        StudentService studentService = new StudentService(studentAction);

        GraduateStudentAction graduateStudentAction = new GraduateStudentAction();
        GraduateStudentService graduateStudentService = new GraduateStudentService(graduateStudentAction);

        PostgraduateStudentAction postgraduateStudentAction = new PostgraduateStudentAction();
        PostgraduateStudentService postgraduateStudentService = new PostgraduateStudentService(postgraduateStudentAction);

        PhDStudentAction phDStudentAction = new PhDStudentAction();
        PhDStudentService phDStudentService = new PhDStudentService(phDStudentAction);

        TeacherAction teacherAction = new TeacherAction();
        TeacherService teacherService = new TeacherService(teacherAction);

        CourseAction courseAction = new CourseAction();
        CourseService courseService = new CourseService(courseAction);




        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Search student by attribute");
            Console.WriteLine("2. Create student");
            Console.WriteLine("3. Update student");
            Console.WriteLine("4. Delete student");
            Console.WriteLine("5. Create teacher");
            Console.WriteLine("6. Update teacher");
            Console.WriteLine("7. Delete teacher");
            Console.WriteLine("8. Search teacher by attribute");
            Console.WriteLine("9. Show All Student");
            Console.WriteLine("10. Show All Teacher");
            Console.WriteLine("11. Create course");
            Console.WriteLine("12. Show All Courses");
            Console.WriteLine("13. Update Course");
            Console.WriteLine("14. Delete Course");
            Console.WriteLine("15. Create User");
            Console.WriteLine("16. Show All User");
            Console.WriteLine("17. Create User");
            Console.WriteLine("18. Delete User");
            Console.WriteLine("19. Search User by attribute");
            Console.WriteLine("20. Search course by attribute");
            Console.WriteLine("21. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    SearchStudent();
                    break;
                case "2":
                    Student student = CreateStudentUI();
                    studentService.CreateStudent(student);
                    break;
                case "3":
                    UpdateStudent();
                    break;
                case "4":
                    DeleteStudent();
                    break;
                case "5":
                    Teacher teacher = CreateTeacherUI();
                    teacherService.CreateTeacher(teacher);
                    break;
                case "6":
                    UpdateTeacher();
                    break;
                case "7":
                    DeleteTeacher();
                    break;
                case "8":
                    SearchTeacher();
                    break;
                case "9":
                    List<Student> students = studentService.GetAllStudents();
                    ShowAllStudent(students);
                    break;
                case "10":
                    List<Teacher> teachers = teacherService.GetAllTeachers();
                    ShowAllTeacher(teachers);
                    break;
                case "11":
                    Course course = CreateCourseUI();
                    courseService.CreateCourse(course);
                    break;
                case "12":
                    List<Course> courses = courseService.GetAllCourses();
                    ShowAllCourses(courses);
                    break;
                case "13":
                    UpdateCourse();
                    break;
                case "14":
                    DeleteCourse();
                    break;
                case "15":
                    User user = AddUserUI();
                    userService.AddUser(user);
                    break;
                case "16":
                    List<User> users = userService.GetAllUsers();
                    ShowAllUsers(users);
                    break;
                case "17":
                    UpdateUser();
                    break;
                case "18":
                    DeleteUser();
                    break;
                case "19":
                    SearchUser();
                    break;
                case "20":
                    SearchCourse();
                    break;
                case "21":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }


        static User AddUserUI()
        {
            Console.WriteLine("Enter User Details:");
            Console.Write("UserId ID: ");
            int userID = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string userName = Console.ReadLine();
            Console.Write("Address: ");
            string userAddress = Console.ReadLine();
            Console.Write("Email: ");
            string userEmail = Console.ReadLine();
            Console.Write("PhoneNumber: ");
            string userPhonenumber = Console.ReadLine();

            User user = new User
            (
                userID,
                userName,
                userAddress,
                userEmail,
                userPhonenumber
            );
            return user;
        }

        static void ShowAllUsers(List<User> users)
        {

            if (users.Count > 0)
            {
                foreach (User user in users)
                {
                    Console.WriteLine($"UserId: {user.UserId}, UserName: {user.Name}, UserAddress: {user.Address}, Email: {user.Email}, PhoneNumber: {user.PhoneNumber}");
                }
            }
            else
            {
                Console.WriteLine("No User found.");
            }
        }

        
  

        List<User> SelectUser()
        {
            Console.WriteLine("Enter attribute to search by (ID, Name, Address, Email, phonenumber ):");
            string attribute = Console.ReadLine();
            Console.WriteLine("Enter value to search for:");
            string value = Console.ReadLine().ToLower();

            List<User> result = userService.SearchUser(attribute, value);

            return result;

        }
        void SearchUser()
        {
            List<User> result = SelectUser();

            if (result.Count > 0)
            {
                foreach (User user in result)
                {
                    Console.WriteLine($"UserId: {user.UserId}, UserName: {user.Name}, UserAddress: {user.Address}, Email: {user.Email}, PhoneNumber: {user.PhoneNumber}");
                }
            }
            else
            {
                Console.WriteLine("No user found.");
            }
        }

        void UpdateUser()
        {
            List<User> result = SelectUser();

            if (result.Count > 0)
            {
                Console.WriteLine("Please select the user to update by entering the user ID:");
                for (int i = 0; i < result.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. UserId: {result[i].UserId}, UserName: {result[i].Name}, UserAddress: {result[i].Address}, Email: {result[i].Email}, PhoneNumber: {result[i].PhoneNumber}");
                }
                Console.Write("Enter user ID to update: ");
                int id = int.Parse(Console.ReadLine());


                User user = userService.GetUserById(id);
                if (user == null)
                {
                    Console.WriteLine("User not found.");
                    return;
                }

                Console.Write("Enter new name (leave blank to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) user.Name = name;

                Console.Write("Enter new Address (leave blank to keep current): ");
                string address = Console.ReadLine();
                if (!string.IsNullOrEmpty(address)) user.Address = address;

                Console.Write("Enter new email (leave blank to keep current): ");
                string email = Console.ReadLine();
                if (!string.IsNullOrEmpty(email)) user.Email = email;

                Console.Write("Enter new phoneNumber (leave blank to keep current): ");
                string phoneNumber = Console.ReadLine();
                if (!string.IsNullOrEmpty(phoneNumber)) user.PhoneNumber = phoneNumber;

                Console.WriteLine("User updated successfully.");
                userService.UpdateUser(user);
            }
            else
            {
                Console.WriteLine("No users found.");
            }
        }

        void DeleteUser()
        {
            List<User> result = SelectUser();

            if (result.Count == 0)
            {
                Console.WriteLine("No users found.");
                return;
            }



            Console.WriteLine(" Please select the user to delete by entering the user ID:");

            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine($"{i + 1}. UserId: {result[i].UserId}, UserName: {result[i].Name}, UserAddress: {result[i].Address}, Email: {result[i].Email}, PhoneNumber: {result[i].PhoneNumber}");
            }

            Console.Write("Enter user ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            User selectedUser = userService.GetUserById(id);
            if (selectedUser == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            studentService.DeleteStudent(selectedUser.UserId);
            Console.WriteLine("User deleted successfully.");
        }




        static Student CreateStudentUI()
        {
            Console.WriteLine("Enter student details:");
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Level (Graduate, Postgraduate, PhD): ");
            string level = Console.ReadLine();

            Student student = level.ToLower() switch
            {
                "graduate" => new GraduateStudent(id, name, "", email, "", id, "Graduate", ""),
                "postgraduate" => new PostgraduateStudent(id, name, "", email, "", id, "Postgraduate", ""),
                "phd" => new PhDStudent(id, name, "", email, "", id, "PhD", ""),
                _ => throw new ArgumentException("Invalid level")
            };

            Console.WriteLine("Student created successfully.");
            return student;
        }
        static void ShowAllStudent(List<Student> students)
        {
            if (students.Count > 0)
            {
                foreach (Student student in students)
                {
                    Console.WriteLine($"StudentID: {student.StudentID}, Student: {student.Name}, Email: {student.Email}, Level: {student.Level}, GPA: {student.Gpa}");
                }
            }
            else
            {
                Console.WriteLine("No students found.");
            }


        }

        List<Student> SelectStudent()
        {
            Console.WriteLine("Enter attribute to search by (ID, Name, Email, Level):");
            string attribute = Console.ReadLine();
            Console.WriteLine("Enter value to search for:");
            string value = Console.ReadLine().ToLower();

            List<Student> result = studentService.SearchStudents(attribute, value);

            return result;

        }
        void SearchStudent()
        {
            List<Student> result = SelectStudent();

            if (result.Count > 0)
            {
                foreach (Student student in result)
                {
                    Console.WriteLine($"ID: {student.StudentID}, Name: {student.Name}, Email: {student.Email}, Level: {student.Level}");
                }
            }
            else
            {
                Console.WriteLine("No students found.");
            }
        }

        void UpdateStudent()
        {
            List<Student> result = SelectStudent();

            if (result.Count > 0)
            {
                Console.WriteLine("Please select the student to update by entering the student ID:");
                for (int i = 0; i < result.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. ID: {result[i].StudentID}, Name: {result[i].Name}, Email: {result[i].Email}, Level: {result[i].Level}");
                }
                Console.Write("Enter student ID to update: ");
                int id = int.Parse(Console.ReadLine());


                Student student = studentService.GetStudentById(id);
                if (student == null)
                {
                    Console.WriteLine("Student not found.");
                    return;
                }

                Console.Write("Enter new name (leave blank to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) student.Name = name;

                Console.Write("Enter new email (leave blank to keep current): ");
                string email = Console.ReadLine();
                if (!string.IsNullOrEmpty(email)) student.Email = email;

                Console.WriteLine("Student updated successfully.");
                studentService.UpdateStudent(student);
            }
            else
            {
                Console.WriteLine("No students found.");
            }
        }

        void DeleteStudent()
        {
            List<Student> result = SelectStudent();

            if (result.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }



            Console.WriteLine(" Please select the student to delete by entering the student ID:");

            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine($"{i + 1}. ID: {result[i].StudentID}, Name: {result[i].Name}, Email: {result[i].Email}, Level: {result[i].Level}");
            }

            Console.Write("Enter student ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            Student selectedStudent = studentService.GetStudentById(id);
            if (selectedStudent == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            studentService.DeleteStudent(selectedStudent.StudentID);
            Console.WriteLine("Student deleted successfully.");
        }




        static Course CreateCourseUI()
        {
            Console.WriteLine("Enter Course ID:");
            int courseID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Course Name:");
            string courseName = Console.ReadLine();
            Console.WriteLine("Enter Description:");
            string description = Console.ReadLine();
            Console.WriteLine("Enter Level (Graduate, Postgraduate, PhD):");
            string level = Console.ReadLine();

            Course course = new Course(courseID, courseName, description, level);

            Console.WriteLine("Course created successfully.");
            return course;
        }

        static void ShowAllCourses(List<Course> courses)
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("No courses available.");
                return;
            }

            foreach (var course in courses)
            {
                Console.WriteLine($"ID: {course.CourseID}, Name: {course.CourseName}, Description: {course.Description}, Level: {course.Level}");
            }
        }

        List<Course> SelectCourse()
        {
            Console.WriteLine("Enter attribute to search by (ID, Name, Description, Level):");
            string attribute = Console.ReadLine();
            Console.WriteLine("Enter value to search for:");
            string value = Console.ReadLine().ToLower();

            List<Course> result = courseService.SearchCourses(attribute, value);

            return result;
        }
       
        void SearchCourse()
        {
            List<Course> result = SelectCourse();

            if (result.Count > 0)
            {
                foreach (Course course in result)
                {
                    Console.WriteLine($"ID: {course.CourseID}, Name: {course.CourseName}, Description: {course.Description}, Level: {course.Level}");

                }
            }
            else
            {
                Console.WriteLine("No course found.");
            }
        }

        void DeleteCourse()
        {
            List<Course> result = SelectCourse();

            if (result.Count == 0)
            {
                Console.WriteLine("No courses found.");
                return;
            }

            Console.WriteLine("Please select the course to delete by entering the course ID:");

            foreach (Course course in result)
            {
                Console.WriteLine($"ID: {course.CourseID}, Name: {course.CourseName}, Description: {course.Description}, Level: {course.Level}");
            }

            Console.Write("Enter course ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            Course selectedCourse = courseService.GetCourseById(id);
            if (selectedCourse == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            courseService.DeleteCourse(selectedCourse.CourseID);
            Console.WriteLine("Course deleted successfully.");
        }

        void UpdateCourse()
        {
            var result = SelectCourse();

            if (result.Count == 0)
            {
                Console.WriteLine("No courses found.");
                return;
            }



            Console.WriteLine("Please select the course to update by entering the course ID:");

            foreach (Course course in result)
            {
                Console.WriteLine($"ID: {course.CourseID}, Name: {course.CourseName}, Description: {course.Description}, Level: {course.Level}");
            }

            Console.Write("Enter course ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Course selectedCourse = courseService.GetCourseById(id);
            if (selectedCourse == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            Console.WriteLine("Enter new name (or press Enter to keep current):");
            string newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName))
            {
                selectedCourse.CourseName = newName;
            }

            Console.WriteLine("Enter new description (or press Enter to keep current):");
            string newDescription = Console.ReadLine();
            if (!string.IsNullOrEmpty(newDescription))
            {
                selectedCourse.Description = newDescription;
            }

            Console.WriteLine("Enter new level (or press Enter to keep current):");
            string newLevel = Console.ReadLine();
            if (!string.IsNullOrEmpty(newLevel))
            {
                selectedCourse.Level = newLevel;
            }
            courseService.UpdateCourse(selectedCourse);

            Console.WriteLine("Course updated successfully.");
        }

        //////////////////////////////////////////////
        static Teacher CreateTeacherUI()
        {
            Console.WriteLine("Enter teacher details:");
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();

            Teacher teacher = new Teacher(id, name, "", email, "", id);

            Console.WriteLine("Teacher created successfully.");
            return teacher;
        }

        List<Teacher> SelectTeacher()
        {
            Console.WriteLine("Enter attribute to search by (ID, Name, Email):");
            string attribute = Console.ReadLine();
            Console.WriteLine("Enter value to search for:");
            string value = Console.ReadLine().ToLower();

            List<Teacher> result = teacherService.SearchTeachers(attribute, value);

            return result;

        }

        void SearchTeacher()
        {
            List<Teacher> result = SelectTeacher();

            if (result.Count > 0)
            {
                foreach (Teacher teacher in result)
                {
                    Console.WriteLine($"ID: {teacher.TeacherID}, Name: {teacher.Name}, Email: {teacher.Email}");
                }
            }
            else
            {
                Console.WriteLine("No teachers found.");
            }
        }
        void UpdateTeacher()
        {

            List<Teacher> result = SelectTeacher();

            if (result.Count > 0)
            {
                Console.WriteLine("Select a teacher to update:");
                for (int i = 0; i < result.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. ID: {result[i].TeacherID}, Name: {result[i].Name}, Email: {result[i].Email}");
                }
                Console.Write("Enter teacher ID to update: ");
                int id = int.Parse(Console.ReadLine());


                Teacher teacher = teacherService.GetTeacherById(id);
                if (teacher == null)
                {
                    Console.WriteLine("Teacher not found.");
                    return;
                }
                Console.Write("Enter new name (leave blank to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) teacher.Name = name;

                Console.Write("Enter new email (leave blank to keep current): ");
                string email = Console.ReadLine();
                if (!string.IsNullOrEmpty(email)) teacher.Email = email;
                teacherService.UpdateTeacher(teacher);

                Console.WriteLine("Teacher updated successfully.");

            }
            else
            {
                Console.WriteLine("No teachers found.");
            }
        }

        void DeleteTeacher()
        {

            List<Teacher> result = SelectTeacher();

            if (result.Count == 0)
            {
                Console.WriteLine("No teachers found.");
                return;
            }



            Console.WriteLine(" Please select the teacher to delete by entering the teacher ID:");

            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine($"{i + 1}. ID: {result[i].TeacherID}, Name: {result[i].Name}, Email: {result[i].Email}");
            }

            Console.Write("Enter teacher ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            Teacher selectedTeacher = teacherService.GetTeacherById(id);
            if (selectedTeacher == null)
            {
                Console.WriteLine("Teacher not found.");
                return;
            }
            teacherService.DeleteTeacher(selectedTeacher.TeacherID);

            Console.WriteLine("Teacher deleted successfully.");
        }

        static void ShowAllTeacher(List<Teacher> teachers)
        {


            if (teachers.Count > 0)
            {
                foreach (var teacher in teachers)
                {
                    Console.WriteLine($"ID: {teacher.TeacherID}, Name: {teacher.Name}, Email: {teacher.Email}");
                }
            }
            else
            {
                Console.WriteLine("No teachers found.");
            }

        }

    }

}
