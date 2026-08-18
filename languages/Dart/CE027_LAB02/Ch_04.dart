enum AudioState { playing, paused, stopped }

void main() {

  // Boolean
  bool isLoggedIn = true;
  bool isAdmin = false;

  print(isLoggedIn);
  print(isAdmin);

  // Comparison Operators
  int a = 20;
  int b = 10;

  print(a == b);
  print(a != b);
  print(a > b);
  print(a < b);
  print(a >= b);
  print(a <= b);

  // Logical Operators
  print(isLoggedIn && isAdmin);
  print(isLoggedIn || isAdmin);
  print(!isLoggedIn);

  // String Equality
  String language = "Dart";

  print(language == "Dart");
  print(language == "Java");

  // if
  if (a > b) {
    print("a is greater");
  }

  // if-else
  if (a % 2 == 0) {
    print("Even");
  } else {
    print("Odd");
  }

  // else-if Ladder
  int marks = 82;

  if (marks >= 90) {
    print("Grade A");
  } else if (marks >= 75) {
    print("Grade B");
  } else if (marks >= 60) {
    print("Grade C");
  } else {
    print("Fail");
  }

  // Ternary Operator
  String result = (marks >= 35) ? "Pass" : "Fail";
  print(result);

  // Switch
  String day = "Monday";

  switch (day) {
    case "Monday":
      print("Start of Week");
      break;

    case "Friday":
      print("Weekend Coming");
      break;

    default:
      print("Normal Day");
  }

  // Enum
  AudioState state = AudioState.paused;

  switch (state) {
    case AudioState.playing:
      print("Playing");
      break;

    case AudioState.paused:
      print("Paused");
      break;

    case AudioState.stopped:
      print("Stopped");
      break;
  }
}