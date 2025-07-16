public class DemoGenericMethod {
    public static void main(String[] args) {
        ExampleGenericMethod.genericPrint(58);
        ExampleGenericMethod.genericPrint("Srimanikandan");
    }
}

class ExampleGenericMethod {
    /**
     * Generic Methods allows different data types within a single method
     * It is an alternative to method overloading
    */ 
    public static  <T> void genericPrint(T element) {
        System.out.println("Type : " + element.getClass().getName());
        System.out.println("Value : " + element);
    }
}
