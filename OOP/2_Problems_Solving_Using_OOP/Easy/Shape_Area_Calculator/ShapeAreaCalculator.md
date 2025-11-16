```mermain
classDiagram

    class Shape {
        <<abstract>>
        - String name
        + getName() String
        + computeArea() double*
    }

    class Circle {
        - double radius
        + computeArea() double
    }

    class Rectangle {
        - double width
        - double height
        + computeArea() double
    }

    class Triangle {
        - double base
        - double height
        + computeArea() double
    }

    Shape <|-- Circle
    Shape <|-- Rectangle
    Shape <|-- Triangle

```