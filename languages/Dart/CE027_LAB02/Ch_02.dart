void main() {

  // Explicit Type
  int age = 20;
  double cgpa = 8.96;
  String name = "Parth";
  bool isStudent = true;

  // var (Type Inference)
  var city = "Junagadh";
  var marks = 567;
  var percentage = 94.5;

  // Mutable Variable
  age = 21;

  // final (Runtime Constant)
  final currentTime = DateTime.now();

  // const (Compile-Time Constant)
  const pi = 3.14159;
  const college = "DDU";

  // Printing Values
  print("Name        : $name");
  print("Age         : $age");
  print("CGPA        : $cgpa");
  print("Student     : $isStudent");

  print("\nCity        : $city");
  print("Marks       : $marks");
  print("Percentage  : $percentage");

  print("\nRuntime Types");
  print(city.runtimeType);
  print(marks.runtimeType);
  print(percentage.runtimeType);

  print("\nFinal");
  print(currentTime);
  
  print("\nConst");
  print(pi);
  print(college);

  // Scope
  print("\nVariable Scope");

  String department = "Computer Engineering";

  if (true) {
    String semester = "Semester 5";

    print(department);
    print(semester);
  }

  print(department);

  // print(semester); // Error (Outside Scope)
}