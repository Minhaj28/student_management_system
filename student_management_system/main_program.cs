using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Linq;
using System.Runtime.CompilerServices;
using BLL.Interfaces;
using BLL.Services;
using DAL.Models;
using DAL.ORM;
using DAL.ViewModels;
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

        StudentEnrollmentAction studentEnrollmentAction = new StudentEnrollmentAction();
        StudentEnrollmentService studentEnrollmentService = new StudentEnrollmentService(studentEnrollmentAction);


        /*string conn = "DRIVER={MySQL ODBC 9.0 Unicode Driver}; SERVER=localhost; DATABASE=student_management_system; UID=root;PASSWORD=root; OPTION=3; port=3306; stmt=SET NAMES 'utf8';";
        OdbcConnection smsConnection = new OdbcConnection(conn);*/
        // smsConnection.Open();


        // Open the connection and execute the insert command.

         

       

        

       

        while (true)
        {
            
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Search student");
            Console.WriteLine("2. Create student");
            Console.WriteLine("3. Update student");
            Console.WriteLine("4. Delete student");
            Console.WriteLine("5. Create teacher");
            Console.WriteLine("6. Update teacher");
            Console.WriteLine("7. Delete teacher");
            Console.WriteLine("8. Search teacher");
            Console.WriteLine("9. Show All Student");
            Console.WriteLine("10. Show All Teacher");
            Console.WriteLine("11. Create course");
            Console.WriteLine("12. Show All Courses");
            Console.WriteLine("13. Update Course");
            Console.WriteLine("14. Delete Course");
            Console.WriteLine("15. Create User");
            Console.WriteLine("16. Show All User");
            Console.WriteLine("17. Update User");
            Console.WriteLine("18. Delete User");
            Console.WriteLine("19. Search User");
            Console.WriteLine("20. Search course");
            Console.WriteLine("21. Exit");
            Console.WriteLine("22. Create Student Enrollment");
            Console.WriteLine("23. Show All Student Enrollment");
            Console.WriteLine("24. Delete Student Enrollment");
            Console.WriteLine("25. Assign Teacher");
            Console.WriteLine("26. Show All Assigned Teacher");
            Console.WriteLine("27. Delete Assigned Teacher");
            Console.WriteLine("28. Create Exam");
            Console.WriteLine("29. Show All Exam");
            Console.WriteLine("30. Delete Exam");
            Console.WriteLine("31. Create ExamResult");
            Console.WriteLine("32. Show All ExamResult");
            Console.WriteLine("33. Delete ExamResult");
            Console.WriteLine("34. Take Attendance");
            Console.WriteLine("35. Show All Attendance");

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
                    UpdateStudent(studentService);
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
                case "22":
                    StudentEnrollment studentEnrollment = EnrollStudentUI(studentService, courseService);
                    studentEnrollmentService.EnrollStudent(studentEnrollment);
                    break;
                case "23":
                    List<StudentEnrollmentView> studentEnrollmentsView = studentEnrollmentService.GetStudentEnrollmentView();
                    ShowAllStudentEnrollment(studentEnrollmentsView);
                    break;
                case "24":
                    DeleteStudentEnrollment();
                    break;
                case "25":
                    AssignedTeacher assignedTeacher = AssignedTeacherUI(teacherService, courseService);
                    teacherService.AssignedTeacher(assignedTeacher);
                    break;
                case "26":
                    List<AssignedTeacherView> assignedTeacherView = teacherService.GetAssignedTeacherView();
                    ShowAllAssignedTeacher(assignedTeacherView);
                    break;
                case "27":
                    DeleteAssignedTeacher();
                    break;
                case "28":
                    Exam exam = CreateExamUI(courseService);
                    teacherService.TakeExam(exam);
                    break;
                case "29":
                    List<ExamView> examView = teacherService.GetExamView();
                    ShowAllExam(examView);
                    break;
                case "30":
                    DeleteExam();
                    break;
                case "31":
                    ExamResult examResult = CreateExamResultUI(teacherService, studentService);
                    teacherService.ExamResult(examResult);
                    break;
                case "32":
                    List<ResultView> sesultView = teacherService.GetResultView();
                    ShowAllResult(sesultView);
                    break;
                case "33":
                    DeleteResult();
                    break;
                case "34":
                    Attendance attendance = TakeAttendanceUI(studentEnrollmentService);
                    teacherService.TakeAttendance(attendance);
                    break;
                case "35":
                    List<AttendanceView> attendanceView = teacherService.GetAttendanceView();
                    ShowAllAttendance(attendanceView);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }


        ////////////////////////////////////////////////////////

        static User AddUserUI()
        {
            Console.WriteLine("Enter User Details:");
            Console.Write("UserName: ");
            string userName = Console.ReadLine();
            Console.Write("UserPassword: ");
            string userPassword = Console.ReadLine();

            User user = new User
            (
                userName,
                userPassword
            );
            Console.WriteLine("User created successfully.");
            return user;
        }

        static void ShowAllUsers(List<User> users)
        {

            if (users.Count > 0)
            {
                foreach (User user in users)
                {
                    Console.WriteLine($"UserId: {user.UserId}, UserName: {user.UserName}, UserPassword: {user.UserPassword}");
                }
            }
            else
            {
                Console.WriteLine("No User found.");
            }
        }

        
  

        List<User> SelectUser()
        {
            Console.WriteLine("Enter value to search User:");
            string value = Console.ReadLine().ToLower();

            List<User> result = userService.SearchUser(value);

            return result;

        }
        void SearchUser()
        {
            List<User> result = SelectUser();

            if (result.Count > 0)
            {
                foreach (User user in result)
                {
                    Console.WriteLine($"UserId: {user.UserId}, UserName: {user.UserName}, UserPassword: {user.UserPassword}");
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

            if (result.Count == 0)
            {
                Console.WriteLine("No user found.");
                return;
            }



            Console.WriteLine("Please select the user to update by entering the user ID:");


            foreach (User user1 in result)
            {
                Console.WriteLine($"UserId: {user1.UserId}, UserName: {user1.UserName}, UserPassword: {user1.UserPassword}");

            }
            Console.WriteLine();

            Console.Write("Enter user ID to update: ");
            int id = int.Parse(Console.ReadLine());

            User currentUser = userService.GetUserById(id);

            // Get user input and keep current values if input is empty
            Console.Write($"Enter UserName ({currentUser.UserName}): ");
            string input = Console.ReadLine();
            currentUser.UserName = string.IsNullOrEmpty(input) ? currentUser.UserName : input;

            Console.Write($"Enter UserPassword ({currentUser.UserPassword}): ");
            input = Console.ReadLine();
            currentUser.UserPassword = string.IsNullOrEmpty(input) ? currentUser.UserPassword : input;

            try
            {
                userService.UpdateUser(id, currentUser);
                Console.WriteLine($"User with ID {id} has been updated.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void DeleteUser()
        {
            List<User> result = SelectUser();

            if (result.Count == 0)
            {
                Console.WriteLine("No User found.");
                return;
            }



            Console.WriteLine("Please select the user to delete by entering the user ID:");

            foreach (User user in result)
            {
                Console.WriteLine($"UserId: {user.UserId}, UserName: {user.UserName}, UserPassword: {user.UserPassword}");

            }
            Console.WriteLine();

            Console.Write("Enter user ID to delete: ");
            int id = int.Parse(Console.ReadLine());


            try
            {
                userService.DeleteUser(id);
                Console.WriteLine("User deleted successfully.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        ///////////////////////////////////////////////////////////////

        static Student CreateStudentUI()
        {
            Console.WriteLine("Enter student details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("PhoneNumber: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Level (Graduate, Postgraduate, PhD): ");
            string level = Console.ReadLine();
            Console.Write("Gpa: ");
            string gpa = Console.ReadLine();


            Student student = new Student(name, address, email, phoneNumber, level, gpa);

            Console.WriteLine("Student created successfully.");
            return student;
        }
        static void ShowAllStudent(List<Student> students)
        {
            if (students.Count > 0)
            {
                foreach (Student student in students)
                {
                    Console.WriteLine($"StudentID: {student.StudentID}, Name: {student.Name}, Address: {student.Address}, Email: {student.Email}, PhoneNumber: {student.PhoneNumber}, Level: {student.Level}, GPA: {student.GPA}");
                }
            }
            else
            {
                Console.WriteLine("No students found.");
            }


        }

        List<Student> SelectStudent()
        {
            Console.WriteLine("Enter value to search student:");
            string value = Console.ReadLine().ToLower();

            List<Student> result = studentService.SearchStudents(value);

            return result;

        }
        void SearchStudent()
        {
            List<Student> result = SelectStudent();

            if (result.Count > 0)
            {
                foreach (Student student in result)
                {
                    Console.WriteLine($"StudentID: {student.StudentID}, Name: {student.Name}, Address: {student.Address}, Email: {student.Email}, PhoneNumber: {student.PhoneNumber}, Level: {student.Level}, GPA: {student.GPA}");

                }
            }
            else
            {
                Console.WriteLine("No students found.");
            }
        }

        void UpdateStudent(StudentService studentService)
        {
            List<Student> result = SelectStudent();

            if (result.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }



            Console.WriteLine("Please select the student to update by entering the student ID:");


            foreach (Student student1 in result)
            {
                Console.WriteLine($"StudentID: {student1.StudentID}, Name: {student1.Name}, Address: {student1.Address}, Email: {student1.Email}, PhoneNumber: {student1.PhoneNumber}, Level: {student1.Level}, GPA: {student1.GPA}");

            }
            Console.WriteLine();

            Console.Write("Enter student ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Student currentStudent = studentService.GetStudentById(id);

            // Get user input and keep current values if input is empty
            Console.Write($"Enter Name ({currentStudent.Name}): ");
            string input = Console.ReadLine();
            currentStudent.Name = string.IsNullOrEmpty(input) ? currentStudent.Name : input;

            Console.Write($"Enter Address ({currentStudent.Address}): ");
            input = Console.ReadLine();
            currentStudent.Address = string.IsNullOrEmpty(input) ? currentStudent.Address : input;

            Console.Write($"Enter Email ({currentStudent.Email}): ");
            input = Console.ReadLine();
            currentStudent.Email = string.IsNullOrEmpty(input) ? currentStudent.Email : input;

            Console.Write($"Enter Phone Number ({currentStudent.PhoneNumber}): ");
            input = Console.ReadLine();
            currentStudent.PhoneNumber = string.IsNullOrEmpty(input) ? currentStudent.PhoneNumber : input;

            Console.Write($"Enter Level ({currentStudent.Level}): ");
            input = Console.ReadLine();
            currentStudent.Level = string.IsNullOrEmpty(input) ? currentStudent.Level : input;

            Console.Write($"Enter GPA ({currentStudent.GPA}): ");
            input = Console.ReadLine();
            currentStudent.GPA = string.IsNullOrEmpty(input) ? currentStudent.GPA : input;

            try
            {
                studentService.UpdateStudent(id, currentStudent);
                Console.WriteLine($"Student with ID {id} has been updated.");
            }
            catch (Exception ex)
            {
                throw ex;
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



            Console.WriteLine("Please select the student to delete by entering the student ID:");

            foreach (Student student in result)
            {
                Console.WriteLine($"StudentID: {student.StudentID}, Name: {student.Name}, Address: {student.Address}, Email: {student.Email}, PhoneNumber: {student.PhoneNumber}, Level: {student.Level}, GPA: {student.GPA}");

            }
            Console.WriteLine();

           Console.Write("Enter student ID to delete: ");
            int id = int.Parse(Console.ReadLine());

          

            try
            {
                studentService.DeleteStudent(id);
                Console.WriteLine("Student deleted successfully.");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        //////////////////////////////////////////////////////

        static Course CreateCourseUI()
        {
            Console.WriteLine("Enter Course Name:");
            string courseName = Console.ReadLine();
            Console.WriteLine("Enter Description:");
            string description = Console.ReadLine();
            Console.WriteLine("Enter Level (Graduate, Postgraduate, PhD):");
            string level = Console.ReadLine();

            try
            {
                Course course = new Course(courseName, description, level);

                Console.WriteLine("Course created successfully.");

                return course;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
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
                Console.WriteLine($"ID: {course.CourseId}, Name: {course.CourseName}, Description: {course.Description}, Level: {course.Level}");
            }
        }

        List<Course> SelectCourse()
        {
            Console.WriteLine("Enter value to search Course:");
            string value = Console.ReadLine().ToLower();

            List<Course> result = courseService.SearchCourses(value);

            return result;
        }
       
        void SearchCourse()
        {
            List<Course> result = SelectCourse();

            if (result.Count > 0)
            {
                foreach (Course course in result)
                {
                    Console.WriteLine($"ID: {course.CourseId}, Name: {course.CourseName}, Description: {course.Description}, Level: {course.Level}");

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
                Console.WriteLine($"ID: {course.CourseId}, Name: {course.CourseName}, Description: {course.Description}, Level: {course.Level}");
            }

            Console.Write("Enter course ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                courseService.DeleteCourse(id);
                Console.WriteLine("Course deleted successfully.");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void UpdateCourse()
        {
            List<Course> result = SelectCourse();

            if (result.Count == 0)
            {
                Console.WriteLine("No Course found.");
                return;
            }



            Console.WriteLine("Please select the Course to update by entering the Course ID:");


            foreach (Course course1 in result)
            {
                Console.WriteLine($"CourseId: {course1.CourseId}, CourseName: {course1.CourseName}, Description: {course1.Description}, Level: {course1.Level}");

            }
            Console.WriteLine();

            Console.Write("Enter Course ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Course currentCourse = courseService.GetCourseById(id);

            // Get user input and keep current values if input is empty
            Console.Write($"Enter CourseName ({currentCourse.CourseName}): ");
            string input = Console.ReadLine();
            currentCourse.CourseName = string.IsNullOrEmpty(input) ? currentCourse.CourseName : input;

            Console.Write($"Enter Description ({currentCourse.Description}): ");
            input = Console.ReadLine();
            currentCourse.Description = string.IsNullOrEmpty(input) ? currentCourse.Description : input;

            Console.Write($"Enter Level ({currentCourse.Level}): ");
            input = Console.ReadLine();
            currentCourse.Level = string.IsNullOrEmpty(input) ? currentCourse.Level : input;

            try
            {
                courseService.UpdateCourse(id, currentCourse);
                Console.WriteLine($"Course with ID {id} has been updated.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //////////////////////////////////////////////
        static Teacher CreateTeacherUI()
        {
            Console.WriteLine("Enter teacher details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("PhoneNumber: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Department: ");
            string department = Console.ReadLine();
            Console.Write("Designation: ");
            string designation = Console.ReadLine();

            Teacher teacher = new Teacher(name, address, email, phoneNumber, department, designation);

            Console.WriteLine("Teacher created successfully.");
            return teacher;
        }

        List<Teacher> SelectTeacher()
        {
            Console.WriteLine("Enter value to search Teacher:");
            string value = Console.ReadLine().ToLower();

            List<Teacher> result = teacherService.SearchTeachers(value);

            return result;

        }

        void SearchTeacher()
        {
            List<Teacher> result = SelectTeacher();

            if (result.Count > 0)
            {
                foreach (Teacher teacher in result)
                {
                    Console.WriteLine($"TeacherId: {teacher.TeacherId}, Name: {teacher.Name}, Address: {teacher.Address}, Email: {teacher.Email}, PhoneNumber: {teacher.PhoneNumber}, Department: {teacher.Department}, Designation: {teacher.Designation}");

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

            if (result.Count == 0)
            {
                Console.WriteLine("No teacher found.");
                return;
            }



            Console.WriteLine("Please select the teacher to update by entering the teacher ID:");


            foreach (Teacher teacher1 in result)
            {
                Console.WriteLine($"TeacherId: {teacher1.TeacherId}, Name: {teacher1.Name}, Address: {teacher1.Address}, Email: {teacher1.Email}, PhoneNumber: {teacher1.PhoneNumber}, Department: {teacher1.Department}, Designation: {teacher1.Designation}");

            }
            Console.WriteLine();

            Console.Write("Enter teacher ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Teacher currentTeacher = teacherService.GetTeacherById(id);

            // Get user input and keep current values if input is empty
            Console.Write($"Enter Name ({currentTeacher.Name}): ");
            string input = Console.ReadLine();
            currentTeacher.Name = string.IsNullOrEmpty(input) ? currentTeacher.Name : input;

            Console.Write($"Enter Address ({currentTeacher.Address}): ");
            input = Console.ReadLine();
            currentTeacher.Address = string.IsNullOrEmpty(input) ? currentTeacher.Address : input;

            Console.Write($"Enter Email ({currentTeacher.Email}): ");
            input = Console.ReadLine();
            currentTeacher.Email = string.IsNullOrEmpty(input) ? currentTeacher.Email : input;

            Console.Write($"Enter Phone Number ({currentTeacher.PhoneNumber}): ");
            input = Console.ReadLine();
            currentTeacher.PhoneNumber = string.IsNullOrEmpty(input) ? currentTeacher.PhoneNumber : input;

            Console.Write($"Enter Department ({currentTeacher.Department}): ");
            input = Console.ReadLine();
            currentTeacher.Department = string.IsNullOrEmpty(input) ? currentTeacher.Department : input;

            Console.Write($"Enter Designation ({currentTeacher.Designation}): ");
            input = Console.ReadLine();
            currentTeacher.Designation = string.IsNullOrEmpty(input) ? currentTeacher.Designation : input;

            try
            {
                teacherService.UpdateTeacher(id, currentTeacher);
                Console.WriteLine($"Teacher with ID {id} has been updated.");
            }
            catch (Exception ex)
            {
                throw ex;
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



            Console.WriteLine("Please select the teacher to delete by entering the teacher ID:");

            foreach (Teacher teacher in result)
            {
                Console.WriteLine($"TeacherId: {teacher.TeacherId}, Name: {teacher.Name}, Address: {teacher.Address}, Email: {teacher.Email}, PhoneNumber: {teacher.PhoneNumber}, Department: {teacher.Department}, Designation: {teacher.Designation}");

            }
            Console.WriteLine();

            Console.Write("Enter teacher ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                teacherService.DeleteTeacher(id);
                Console.WriteLine("Teacher deleted successfully.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static void ShowAllTeacher(List<Teacher> teachers)
        {


            if (teachers.Count > 0)
            {
                foreach (Teacher teacher in teachers)
                {
                    Console.WriteLine($"TeacherId: {teacher.TeacherId}, Name: {teacher.Name}, Address: {teacher.Address}, Email: {teacher.Email}, PhoneNumber: {teacher.PhoneNumber}, Department: {teacher.Department}, Designation: {teacher.Designation}");

                }
            }
            else
            {
                Console.WriteLine("No teachers found.");
            }

        }

        ////////////////////////////////////////////////

        static StudentEnrollment EnrollStudentUI(StudentService studentService, CourseService courseService)
        {
            List<Student> students = studentService.GetAllStudents();
            ShowAllStudent(students);
            Console.WriteLine();

            List<Course> courses = courseService.GetAllCourses();
            ShowAllCourses(courses);
            Console.WriteLine();

            Console.WriteLine("Enter StudentId and CourseId for Enrollment:");
            Console.Write("StudentId: ");
            int studentId = int.Parse(Console.ReadLine());
            Console.Write("CourseId: ");
            int courseId = int.Parse(Console.ReadLine());
            

            StudentEnrollment studentEnrollment = new StudentEnrollment(studentId, courseId);

            
            return studentEnrollment;
        }

        static void ShowAllStudentEnrollment(List<StudentEnrollmentView> studentEnrollmentsView)
        {

            if (studentEnrollmentsView.Count > 0)
            {
                foreach (StudentEnrollmentView studentEnrollment in studentEnrollmentsView)
                {
                    Console.WriteLine($"StudentEnrollmentId: {studentEnrollment.StudentEnrollmentId}, StudentName: {studentEnrollment.Name}, CourseName: {studentEnrollment.CourseName}");
                }
            }
            else
            {
                Console.WriteLine("No StudentEnrollment found.");
            }
        }

        void DeleteStudentEnrollment()
        {
            Console.WriteLine("Please select the StudentEnrollment to delete by entering the StudentEnrollment ID:");
            List<StudentEnrollmentView> result = studentEnrollmentService.GetStudentEnrollmentView();
            ShowAllStudentEnrollment(result);
            Console.WriteLine();

            Console.Write("Enter StudentEnrollment ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                studentEnrollmentService.DeleteEnrollment(id);
                Console.WriteLine("StudentEnrollment deleted successfully.");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        //////////////////////////////////////////
        static AssignedTeacher AssignedTeacherUI(TeacherService teacherService, CourseService courseService)
        {
            List<Teacher> teachers = teacherService.GetAllTeachers();
            ShowAllTeacher(teachers);
            Console.WriteLine();

            List<Course> courses = courseService.GetAllCourses();
            ShowAllCourses(courses);
            Console.WriteLine();

            Console.WriteLine("Enter TeacherId and CourseId for Enrollment:");
            Console.Write("TeacherId: ");
            int teacherId = int.Parse(Console.ReadLine());
            Console.Write("CourseId: ");
            int courseId = int.Parse(Console.ReadLine());


            AssignedTeacher assignedTeacher = new AssignedTeacher(teacherId, courseId);

            Console.WriteLine("AssignedTeacher successfully.");

            return assignedTeacher;

        }


        static void ShowAllAssignedTeacher(List<AssignedTeacherView> assignedTeacherView)
        {

            if (assignedTeacherView.Count > 0)
            {
                foreach (AssignedTeacherView assignedTeacher in assignedTeacherView)
                {
                    Console.WriteLine($"AssignedTeacherId: {assignedTeacher.AssignedTeacherId}, TeacherName: {assignedTeacher.Name}, CourseName: {assignedTeacher.CourseName}");
                }
            }
            else
            {
                Console.WriteLine("No AssignedTeacher found.");
            }
        }

        void DeleteAssignedTeacher()
        {
            Console.WriteLine("Please select the AssignedTeacher to delete by entering the AssignedTeacher ID:");
            List<AssignedTeacherView> result = teacherService.GetAssignedTeacherView();
            ShowAllAssignedTeacher(result);
            Console.WriteLine();

            Console.Write("Enter AssignedTeacher ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                teacherService.DeleteAssignedTeacher(id);
                Console.WriteLine("AssignedTeacher deleted successfully.");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        ///////////////////////////////////////////////////

        static Exam CreateExamUI(CourseService courseService)
        {
            Console.WriteLine("All Course");
            List<Course> courses = courseService.GetAllCourses();
            ShowAllCourses(courses);
            Console.WriteLine();

            Console.WriteLine("Enter CourseId, ExamDate and ExamType for Create Exam:");
            Console.Write("CourseId: ");
            int courseId = int.Parse(Console.ReadLine());
            Console.Write("ExamDate: ");
            string examDate = Console.ReadLine();
            Console.Write("ExamType: ");
            string examType = Console.ReadLine();


            Exam exam = new Exam(courseId, examDate, examType);

            Console.WriteLine("Eaxm created successfully.");

            return exam;

        }

        static void ShowAllExam(List<ExamView> examView)
        {

            if (examView.Count > 0)
            {
                foreach (ExamView exam in examView)
                {
                    Console.WriteLine($"ExamId: {exam.ExamId}, CourseName: {exam.CourseName}, ExamDate: {exam.ExamType}, ExamDate: {exam.ExamType}");
                }
            }
            else
            {
                Console.WriteLine("No Exam found.");
            }
        }

        void DeleteExam()
        {
            Console.WriteLine("Please select the Exam to delete by entering the Eaxm ID:");
            List<ExamView> result = teacherService.GetExamView();
            ShowAllExam(result);
            Console.WriteLine();

            Console.Write("Enter Exam ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                teacherService.DeleteExam(id);
                Console.WriteLine("Exam deleted successfully.");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        ///////////////////////////////////////////////////
        static ExamResult CreateExamResultUI(TeacherService teacherService, StudentService studentService)
        {
            Console.WriteLine("All Exam:");
            List<ExamView> examView = teacherService.GetExamView();
            ShowAllExam(examView);
            Console.WriteLine();

            Console.WriteLine("All Student:");
            List<Student> students = studentService.GetAllStudents();
            ShowAllStudent(students);
            Console.WriteLine();

            Console.WriteLine("Enter ExamId, StudentId and Score for Create Result:");
            Console.Write("ExamId: ");
            int examId = int.Parse(Console.ReadLine());
            Console.Write("StudentId: ");
            int studentId = int.Parse(Console.ReadLine());
            Console.Write("Score: ");
            string score = Console.ReadLine();


            ExamResult examResult = new ExamResult(examId, studentId, score);

            Console.WriteLine("Create Result successfully.");

            return examResult;

        }

        static void ShowAllResult(List<ResultView> resultView)
        {

            if (resultView.Count > 0)
            {
                foreach (ResultView result in resultView)
                {
                    Console.WriteLine($"ResultId: {result.ResultId}, ExamId: {result.ExamId}, StudentId: {result.StudentID}, StudentName: {result.Name}, CourseName: {result.CourseName}, Score: {result.Score}");
                }
            }
            else
            {
                Console.WriteLine("No Result found.");
            }
        }

        void DeleteResult()
        {
            Console.WriteLine("Please select the Result to delete by entering the Result ID:");
            List<ResultView> result = teacherService.GetResultView();
            ShowAllResult(result);
            Console.WriteLine();

            Console.Write("Enter Result ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                teacherService.DeleteResult(id);
                Console.WriteLine("Result deleted successfully.");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        ///////////////////////////////////////////////////////////////
        static Attendance TakeAttendanceUI(StudentEnrollmentService studentEnrollmentService)
        {
            Console.WriteLine("All StudentEnrollment:");
            List<StudentEnrollmentView> studentEnrollmentView = studentEnrollmentService.GetStudentEnrollmentView();
            ShowAllStudentEnrollment(studentEnrollmentView);
            Console.WriteLine();


            Console.WriteLine("Enter StudentEnrollmentId, AttendanceDate and Status for Create Attendance:");
            Console.Write("StudentEnrollmentId: ");
            int studentEnrollmentId = int.Parse(Console.ReadLine());
            Console.Write("AttendanceDate: ");
            string attendanceDate = Console.ReadLine();
            Console.Write("Status: ");
            string status = Console.ReadLine();


            Attendance attendance = new Attendance(studentEnrollmentId, attendanceDate, status);

            Console.WriteLine("Create Attendance successfully.");

            return attendance;

        }

        static void ShowAllAttendance(List<AttendanceView> attendanceView)
        {

            if (attendanceView.Count > 0)
            {
                foreach (AttendanceView attendance in attendanceView)
                {
                    Console.WriteLine($"AttendanceId: {attendance.AttendanceId},StudentId: {attendance.StudentID},StudentName: {attendance.Name}, CourseName: {attendance.CourseName}, AttendanceDate: {attendance.AttendanceDate}, Status: {attendance.Status}");
                }
            }
            else
            {
                Console.WriteLine("No Attendance found.");
            }
        }


    }

}
