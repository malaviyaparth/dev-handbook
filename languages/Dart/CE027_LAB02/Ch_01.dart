import 'dart:math';

/// Demonstrates comments, output, statements,
/// expressions and arithmetic operations in Dart.
void main() {

  // Single-line comment

  /*
    Multi-line comment
    This program covers almost every concept
    from Chapter 1.
  */

  // Variables (Statements)
  int x = 22, y = 7;

  // Expression
  int sum = x + y;

  // Printing strings
  print("Welcome to Dart!");

  // Printing variables
  print("x = $x");
  print("y = $y");

  // Printing expression directly
  print("x + y = ${x + y}");

  // Printing variable
  print("Sum = $sum");

  // Arithmetic Operators
  print("Addition       : ${x + y}");
  print("Subtraction    : ${x - y}");
  print("Multiplication : ${x * y}");
  print("Division       : ${x / y}");
  print("Integer Divide : ${x ~/ y}");
  print("Modulo         : ${x % y}");

  // Order of operations
  print("350 / 5 + 2 = ${350 / 5 + 2}");
  print("350 / (5 + 2) = ${350 / (5 + 2)}");

  // Math Library
  print("PI = $pi");
  print("sqrt(2) = ${sqrt(2)}");
  print("max(10,20) = ${max(10, 20)}");
  print("min(10,20) = ${min(10, 20)}");

  // Trigonometry (Angles in Radians)
  double angle = 45 * pi / 180;

  print("sin(45°) = ${sin(angle)}");
  print("cos(45°) = ${cos(angle)}");

  // Verification
  double value1 = 1 / sqrt(2);
  double value2 = sin(angle);

  print("1/sqrt(2) = $value1");
  print("Difference = ${value1 - value2}");
}