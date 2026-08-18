import 'package:characters/characters.dart';

void main() {
  // Basic Strings
  String language = 'Dart';
  String framework = "Flutter";

  print('$language with $framework');

  // Escape Sequence
  print("First Line\nSecond Line");

  // Raw String
  print(r"C:\flutter\bin");

  // No char type
  String letter = "A";
  print(letter.runtimeType);
  print(letter.length);

  // Unicode
  String emoji = "\u{1F680}";
  print(emoji);

  // UTF-16 Code Units
  print(emoji.codeUnits);

  // Unicode Code Points (Runes)
  print(emoji.runes.toList());

  // User-perceived Characters
  print(emoji.characters.length);

  // Family Emoji
  String family =
      "\u{1F468}\u{200D}\u{1F469}\u{200D}\u{1F467}\u{200D}\u{1F466}";

  print(family);

  print("length      : ${family.length}");
  print("runes       : ${family.runes.length}");
  print("characters  : ${family.characters.length}");
}