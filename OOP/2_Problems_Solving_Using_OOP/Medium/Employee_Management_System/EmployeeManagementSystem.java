import java.util.*;

// Abstract Class (Abstraction)
abstract class Employee {
    private static int idCounter = 1;

    private int id;
    private String name;
    private String department;

    public Employee(String name, String department) {
        this.id = idCounter++;
        this.name = name;
        this.department = department;
    }

    public int getId() { return id; }
    public String getName() { return name; }
    public String getDepartment() { return department; }

    // Polymorphic payment calculation
    public abstract double calculateSalary();

    @Override
    public String toString() {
        return id + " | " + name + " | " + department;
    }
}

// Full-Time Employee – Monthly Fixed Salary
class FullTimeEmployee extends Employee {
    private double monthlySalary;

    public FullTimeEmployee(String name, String department, double monthlySalary) {
        super(name, department);
        this.monthlySalary = monthlySalary;
    }

    @Override
    public double calculateSalary() {
        return monthlySalary;
    }

    @Override
    public String toString() {
        return super.toString() + " | Full-Time | Salary: ₹" + calculateSalary();
    }
}

// Part-Time Employee – Hourly Wage × Hours Worked
class PartTimeEmployee extends Employee {
    private double hourlyRate;
    private int hoursWorked;

    public PartTimeEmployee(String name, String department, double hourlyRate, int hoursWorked) {
        super(name, department);
        this.hourlyRate = hourlyRate;
        this.hoursWorked = hoursWorked;
    }

    @Override
    public double calculateSalary() {
        return hourlyRate * hoursWorked;
    }

    @Override
    public String toString() {
        return super.toString() + " | Part-Time | Salary: ₹" + calculateSalary();
    }
}

// Company to manage employees
class Company {
    private Map<String, List<Employee>> departmentMap = new HashMap<>();

    public void addEmployee(Employee employee) {
        departmentMap
            .computeIfAbsent(employee.getDepartment(), d -> new ArrayList<>())
            .add(employee);
        System.out.println(employee.getName() + " added to " + employee.getDepartment());
    }

    public void showEmployeesByDepartment() {
        System.out.println("\n--- Employees By Department ---");
        for (String dept : departmentMap.keySet()) {
            System.out.println("\nDepartment: " + dept);
            departmentMap.get(dept).forEach(System.out::println);
        }
    }

    public void showTotalSalaries() {
        System.out.println("\n--- Salary Summary ---");
        double total = 0;
        for (List<Employee> list : departmentMap.values()) {
            for (Employee e : list) {
                System.out.println(e.getName() + ": ₹" + e.calculateSalary());
                total += e.calculateSalary();
            }
        }
        System.out.println("Total payroll: ₹" + total);
    }
}

// Simulation featuring Srimani
public class Main {
    public static void main(String[] args) {

        Company company = new Company();

        // Srimani managing employee creation
        System.out.println("🏢 Srimani starts setting up employees...");

        Employee emp1 = new FullTimeEmployee("Ravi", "Engineering", 60000);
        Employee emp2 = new PartTimeEmployee("Priya", "Engineering", 500, 80);
        Employee emp3 = new FullTimeEmployee("Arjun", "HR", 45000);
        Employee emp4 = new PartTimeEmployee("Meera", "Sales", 300, 40);

        company.addEmployee(emp1);
        company.addEmployee(emp2);
        company.addEmployee(emp3);
        company.addEmployee(emp4);

        company.showEmployeesByDepartment();
        company.showTotalSalaries();
    }
}