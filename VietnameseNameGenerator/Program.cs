using VietnameseNameGenerator;

string jsonFilePath = "example.json";
string outputFilePath = "output.txt";

Helper.ConvertJsonToText(jsonFilePath, outputFilePath);
Console.WriteLine("Conversion complete. Check the output.txt file.");


Console.ReadLine();
