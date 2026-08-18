import 'dart:math';

void main() {
  // Number Types
  int age = 20;
  double cgpa = 8.96;
  num value = 100;

  print(age);
  print(cgpa);

  value = 99.99;
  print(value);

  // String & bool
  String name = "Parth";
  bool isStudent = true;

  print(name);
  print(isStudent);

  // Object & dynamic
  dynamic data = 10;
  print(data);

  data = "Hello Dart";
  print(data);

  Object obj = 3.14;
  print(obj.runtimeType);

  // Type Checking
  num number = 12.5;

  print(number is double);
  print(number is int);
  print(number.runtimeType);

  // Type Conversion
  double decimal = 12.5;
  int integer = decimal.toInt();

  int num1 = 10;
  double num2 = num1.toDouble();

  print(integer);
  print(num2);

  // Parsing
  String s1 = "100";
  String s2 = "25.5";

  int intValue = int.parse(s1);
  double doubleValue = double.parse(s2);

  print(intValue);
  print(doubleValue);

  // Mixed Types
  int x = 10;
  double y = 5.5;

  print(x + y);
  print((x + y).runtimeType);

  // Operators
  int a = 17;
  int b = 5;

  print(a + b);
  print(a - b);
  print(a * b);
  print(a / b);
  print(a ~/ b);
  print(a % b);

  print(a > b);
  print(a < b);
  print(a == b);
  print(a != b);

  print(a > 10 && b < 10);
  print(a < 10 || b < 10);
  print(!(a == b));

  // Conditional Operator
  String result = (a > b) ? "a is Greater" : "b is Greater";
  print(result);

  // Math Library
  print(sqrt(25));
  print(pow(2, 5));
  print(max(20, 15));
  print(min(20, 15));
}