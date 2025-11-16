import java.util.*;

// ---------------------------- SUBJECT ----------------------------
class Subject {
    private final String name;
    private double marks;

    public Subject(String name, double marks) {
        this.name = name;
        this.marks = marks;
    }

    public String getName() { return name; }
    public double getMarks() { return marks; }

    public void setMarks(double marks) {
        this.marks = marks;
    }
}

// ---------------------------- STUDENT ----------------------------
class Student {
    private static int idCounter = 1;

    private final int id;
    private final String name;
    private final String gradeLevel; // e.g., "Grade 10", "First Year"
    private final Map<String, Subject> subjects; // dynamic subjects

    public Student(String name, String gradeLevel) {
        this.id = idCounter++;
        this.name = name;
        this.gradeLevel = gradeLevel;
        this.subjects = new HashMap<>();
    }

    public int getId() { return id; }
    public String getName() { return name; }
    public String getGradeLevel() { return gradeLevel; }

    public void addSubject(String subjectName, double marks) {
        subjects.put(subjectName, new Subject(subjectName, marks));
        System.out.println("📘 Added subject: " + subjectName + " for " + name);
    }

    public double calculateAverage() {
        if (subjects.isEmpty()) return 0;

        double total = 0;
        for (Subject s : subjects.values()) {
            total += s.getMarks();
        }
        return total / subjects.size();
    }

    public void printReport() {
        System.out.println("\n----- Report Card: " + name + " -----");
        System.out.println("Grade Level: " + gradeLevel);
        for (Subject s : subjects.values()) {
            System.out.println("📚 " + s.getName() + " : " + s.getMarks());
        }
        System.out.println("🎯 Average Marks: " + calculateAverage());
    }
}

// ---------------------------- SCHOOL ----------------------------
class School {
    private final String name;
    private final Map<Integer, Student> students;

    public School(String name) {
        this.name = name;
        this.students = new HashMap<>();
        System.out.println("🏫 School \"" + name + "\" session started!\n");
    }

    public void addStudent(Student student) {
        students.put(student.getId(), student);
        System.out.println("🧑‍🎓 Student added: " + student.getName());
    }

    public Student getStudent(int id) {
        return students.get(id);
    }

    public Student getTopper() {
        double maxAvg = -1;
        Student topper = null;

        for (Student s : students.values()) {
            double avg = s.calculateAverage();
            if (avg > maxAvg) {
                maxAvg = avg;
                topper = s;
            }
        }
        return topper;
    }
}


// ---------------------------- CLIENT SIMULATION ----------------------------
public class StudentGradingSystem {
    public static void main(String[] args) throws InterruptedException {

        School school = new School("Nexus International School");

        // Student 1 - Srimani
        Student srimani = new Student("Srimani", "First Year");
        school.addStudent(srimani);

        srimani.addSubject("Mathematics", 92);
        Thread.sleep(800);

        srimani.addSubject("Computer Science", 98);
        Thread.sleep(800);

        srimani.addSubject("Physics", 88);
        Thread.sleep(1000);

        // Student 2 - Aditya
        Student aditya = new Student("Aditya", "First Year");
        school.addStudent(aditya);

        aditya.addSubject("Mathematics", 85);
        aditya.addSubject("Computer Science", 90);
        aditya.addSubject("Physics", 80);

        Thread.sleep(1200);

        System.out.println("\n📊 Generating Report Cards...");
        srimani.printReport();
        Thread.sleep(800);
        aditya.printReport();

        Thread.sleep(1000);

        System.out.println("\n🏆 Checking Top Performer...");
        Student topper = school.getTopper();

        System.out.println("\n🥇 Topper is: " + topper.getName() + 
                           " with an average of " + topper.calculateAverage());

        System.out.println("\n✨ Student grading evaluation completed!");
    }
}