import java.util.*;

// ---------------------------- TASK ----------------------------
class Task {
    private final UUID id;
    private final String category; // e.g., Work / Personal / Study
    private String description;
    private int priority; // 1 = High, 2 = Medium, 3 = Low
    private boolean completed;

    public Task(String description, String category, int priority) {
        this.id = UUID.randomUUID();
        this.description = description;
        this.category = category;
        this.priority = priority;
        this.completed = false;
    }

    public UUID getId() {
        return id;
    }

    public String getDescription() {
        return description;
    }

    public String getCategory() {
        return category;
    }

    public int getPriority() {
        return priority;
    }

    public boolean isCompleted() {
        return completed;
    }

    public void markCompleted() {
        completed = true;
    }

    @Override
    public String toString() {
        return "[#" + id + "] (" + category + ") " + description +
                " | Priority: " + priority +
                " | Status: " + (completed ? "✅ Done" : "⏳ Pending");
    }
}

// ---------------------------- TO-DO LIST ----------------------------
class ToDoList {
    private final List<Task> tasks;

    public ToDoList() {
        this.tasks = new ArrayList<>();
        System.out.println("📝 To-Do List created!\n");
    }

    public void addTask(Task task) {
        tasks.add(task);
        System.out.println("➕ Added Task: " + task.getDescription());
    }

    public void removeTask(UUID id) {
        tasks.removeIf(t -> t.getId() == id);
        System.out.println("❌ Removed Task #" + id);
    }

    public void markTaskAsComplete(UUID id) {
        for (Task t : tasks) {
            if (t.getId() == id) {
                t.markCompleted();
                System.out.println("✔️ Task #" + id + " marked as complete.");
                return;
            }
        }
        System.out.println("⚠️ Task #" + id + " not found.");
    }

    public void printAll() {
        System.out.println("\n---- Current To-Do List ----");
        for (Task t : tasks) {
            System.out.println(t);
        }
        System.out.println("-----------------------------\n");
    }

    // Optional: Sorting
    public void sortByPriority() {
        tasks.sort(Comparator.comparing(Task::getPriority));
        System.out.println("📊 Sorted tasks by priority.");
    }

    public void sortByCompletion() {
        tasks.sort(Comparator.comparing(Task::isCompleted));
        System.out.println("📊 Sorted tasks by completion status.");
    }

}

// ---------------------------- CLIENT CODE ----------------------------
public class SimpleToDoListApp {
    public static void main(String[] args) throws InterruptedException {

        ToDoList list = new ToDoList();

        System.out.println("📅 A productive day begins for Srimani...\n");
        Thread.sleep(1000);

        // Adding tasks
        Task t1 = new Task("Revise Computer Networks", "Study", 1);
        Task t2 = new Task("Buy groceries", "Personal", 3);
        Task t3 = new Task("Complete Java project", "Work", 1);
        Task t4 = new Task("Evening workout", "Health", 2);

        list.addTask(t1);
        Thread.sleep(700);

        list.addTask(t2);
        Thread.sleep(700);

        list.addTask(t3);
        Thread.sleep(700);

        list.addTask(t4);
        Thread.sleep(1000);

        list.printAll();

        // Mark a task complete
        System.out.println("⏳ Srimani starts completing tasks...");
        Thread.sleep(1200);
        list.markTaskAsComplete(t1.getId());

        Thread.sleep(1200);
        list.printAll();

        // Optional sorting
        System.out.println("🔎 Sorting tasks by priority...");
        Thread.sleep(800);
        list.sortByPriority();
        list.printAll();

        System.out.println("✨ To-Do session finished for the day!");
    }
}