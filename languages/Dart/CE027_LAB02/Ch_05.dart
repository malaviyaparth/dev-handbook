import 'dart:math';

void main() {

  // while Loop
  int i = 1;

  while (i <= 3) {
    print("while: $i");
    i++;
  }

  // do-while Loop
  int j = 1;

  do {
    print("do-while: $j");
    j++;
  } while (j <= 3);

  // for Loop
  for (int k = 1; k <= 3; k++) {
    print("for: $k");
  }

  // break
  for (int n = 1; n <= 5; n++) {
    if (n == 4) break;
    print("break: $n");
  }

  // continue
  for (int n = 1; n <= 5; n++) {
    if (n == 3) continue;
    print("continue: $n");
  }

  // Random Number
  Random random = Random();
  print("Random: ${random.nextInt(10)}");

  // for-in Loop
  List<String> fruits = ["Apple", "Banana", "Mango"];

  for (String fruit in fruits) {
    print(fruit);
  }

  // forEach Loop
  List<int> numbers = [10, 20, 30];

  numbers.forEach((number) {
    print(number);
  });
}