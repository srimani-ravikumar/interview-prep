import java.util.*;

// ===================== ABSTRACT USER =====================
abstract class User {
    private static int idCounter = 1;
    
    private final int id;
    private String name;

    public User(String name) {
        this.id = idCounter++;
        this.name = name;
    }

    public int getId() { return id; }
    public String getName() { return name; }

    public abstract void displayRole();
}

// ===================== STUDENT =====================
class Student extends User {
    private List<Course> enrolledCourses = new ArrayList<>();
    private Map<Course, Map<String, Double>> grades = new HashMap<>();

    public Student(String name) {
        super(name);
    }

    public void enroll(Course course) {
        enrolledCourses.add(course);
        course.addStudent(this);
        System.out.println(getName() + " enrolled in course: " + course.getTitle());
    }

    public void submitAssessment(Course course, String assessmentName, double score) {
        grades.putIfAbsent(course, new HashMap<>());
        grades.get(course).put(assessmentName, score);
        System.out.println(getName() + " submitted assessment '" + assessmentName + "' for course " + course.getTitle() + " | Score: " + score);
    }

    public double getGrade(Course course) {
        Map<String, Double> courseGrades = grades.get(course);
        if (courseGrades == null) return 0.0;
        return courseGrades.values().stream().mapToDouble(Double::doubleValue).average().orElse(0.0);
    }

    @Override
    public void displayRole() {
        System.out.println(getName() + " is a Student.");
    }
}

// ===================== INSTRUCTOR =====================
class Instructor extends User {
    private List<Course> teachingCourses = new ArrayList<>();

    public Instructor(String name) {
        super(name);
    }

    public Course createCourse(String title) {
        Course course = new Course(title, this);
        teachingCourses.add(course);
        System.out.println(getName() + " created course: " + title);
        return course;
    }

    @Override
    public void displayRole() {
        System.out.println(getName() + " is an Instructor.");
    }
}

// ===================== COURSE =====================
class Course {
    private String title;
    private Instructor instructor;
    private List<Student> enrolledStudents = new ArrayList<>();
    private List<Assessment> assessments = new ArrayList<>();

    public Course(String title, Instructor instructor) {
        this.title = title;
        this.instructor = instructor;
    }

    public String getTitle() { return title; }

    public void addStudent(Student s) {
        enrolledStudents.add(s);
    }

    public void addAssessment(Assessment a) {
        assessments.add(a);
        System.out.println("Assessment '" + a.getName() + "' added to course: " + title);
    }

    public List<Assessment> getAssessments() { return assessments; }
}

// ===================== ASSESSMENT =====================
abstract class Assessment {
    private String name;

    public Assessment(String name) { this.name = name; }

    public String getName() { return name; }

    public abstract void conduct(Student student);
}

class Quiz extends Assessment {
    public Quiz(String name) { super(name); }

    @Override
    public void conduct(Student student) {
        double score = new Random().nextInt(101); // random 0-100
        student.submitAssessment(null, getName(), score);
    }
}

class Assignment extends Assessment {
    public Assignment(String name) { super(name); }

    @Override
    public void conduct(Student student) {
        double score = new Random().nextInt(51) + 50; // random 50-100
        student.submitAssessment(null, getName(), score);
    }
}

// ===================== SIMULATION (MAIN) =====================
public class ELearningApp {
    public static void main(String[] args) {
        System.out.println("🎓 takeUFoward - E-Learning Platform Simulation Started\n");

        // Instructor Aditi creates courses
        Instructor aditi = new Instructor("Raj");
        Course dsCourse = aditi.createCourse("Data Structures");
        Course coreSubjects = aditi.createCourse("Core Subjects - CN, OS, DBMS");

        // Add assessments to courses
        dsCourse.addAssessment(new Quiz("DS Quiz 1"));
        dsCourse.addAssessment(new Assignment("DS Assignment 1"));

        coreSubjects.addAssessment(new Quiz("Core Subjects - CN, OS, DBMS Quiz 1"));
        coreSubjects.addAssessment(new Assignment("Core Subjects - CN, OS, DBMS Assignment 1"));

        // Srimani joins as Student
        Student srimani = new Student("Srimani");
        srimani.displayRole();

        // Enrollment
        srimani.enroll(dsCourse);
        srimani.enroll(coreSubjects);

        // Simulate completing assessments
        for (Assessment a : dsCourse.getAssessments()) {
            srimani.submitAssessment(dsCourse, a.getName(), new Random().nextInt(101));
        }

        for (Assessment a : javaCourse.getAssessments()) {
            srimani.submitAssessment(coreSubjects, a.getName(), new Random().nextInt(101));
        }

        // Show grades
        System.out.println("\n--- Srimani's Grades ---");
        System.out.println("Data Structures: " + srimani.getGrade(dsCourse));
        System.out.println("Core Subjects - CN, OS, DBMS: " + srimani.getGrade(coreSubjects));
    }
}
