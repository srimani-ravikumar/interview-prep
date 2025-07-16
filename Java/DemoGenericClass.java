import java.util.*;

public class DemoGenericClass {
    public static void main(String[] args) {
        GenericClass<String> obj = new GenericClass<String>();
        if (!obj.removeLast()) {
            System.out.println("Opps! No one is here to remove");
        }
        obj.add("Srimani");
        obj.add("Ravikumar");
        obj.add("Nirmal");
        obj.add("Srinivas");

        obj.print();
        obj.removeLast();
        obj.print();

        obj.displayType();
    }
}

class GenericClass<T> {
    private List<T> list = new ArrayList<T>();

    public void displayType() {
        System.out.println("Type : " + this.getClass().getTypeName());
    }

    public void add(T item) {
        list.add(item);
    }

    public Boolean removeLast() {
        if (list.isEmpty()) {
            return false;
        }

        list.remove(list.size() - 1);
        return true;
    }

    public void print() {
        System.out.print("[ ");
        for (T element : list) {
            System.out.print(element + ", ");
        }
        System.out.println("]");
    }
}