using System.Globalization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\zuevi\\Desktop\\Students";
            Directory.CreateDirectory(path);

            string filePath = "C:\\Users\\zuevi\\Downloads\\Students.dat";

            BinaryFormatter formatter = new BinaryFormatter();
            var fileStream = new FileStream(filePath, FileMode.Open);
            try
            {
                var students = (Student[])formatter.Deserialize(fileStream);
                foreach (var student in students)
                {
                    StreamWriter streamWriter = new StreamWriter(path + "/" + student.Group + ".txt", true);
                    streamWriter.WriteLine($"{student.Name}, {student.DateOfBirth.ToShortDateString()}");
                    streamWriter.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
