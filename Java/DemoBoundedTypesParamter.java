public class DemoBoundedTypesParamter {
    public static void main(String[] args) {
        NumericBox<Integer> intNum = new NumericBox<Integer>(20);
        intNum.print();
        NumericBox<Double> doubleNum = new NumericBox<Double>(15.5);
        doubleNum.print();
    }
}

/*
 * Bounder Type Paremeters restricts the type of values that can be used as generic arguments
 */
class NumericBox<T extends Number> {
    private T num;

    NumericBox(T num) {
        this.num = num;
    }

    public void print() {
        System.out.println("Number is " + num);
    }
}