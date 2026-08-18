Console.WriteLine("Hello, This is a Student Dashboard!");

Console.Write("Enter your name : ");
string name = Console.ReadLine();

List<int> list = new List<int>();
int total = 0;
for (int i = 1; i <= 5; i++)
{
    Console.Write($"Enter your subject {i} mark : ");
    list.Add(int.Parse(Console.ReadLine()));
    total += list[i - 1];
}

Console.WriteLine("Total marks obtaind :" + total);

double percentage = total / 5.0;
Console.WriteLine("Percentage :" + percentage);

string grade = percentage switch
{
    >= 90 => "AA",
    >= 80 => "AB",
    >= 70 => "BB",
    >= 60 => "BC",
    >= 50 => "CC",
    >= 40 => "CD",
    _ => "Fail"
};
Console.WriteLine("Grade :" + grade);
