using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLogic
{
    public class Logic
    {
        public List<Student> students { get; set; } = new List<Student>();

        public void AddStudent(string name, string speciality, string group)
        {
            students.Add(new Student(name, speciality, group));
            WriteFile(Environment.NewLine + name + " " + speciality + " " + group);
        }

        public void DeleteStudent(int index)
        {
            students.RemoveAt(index);
            List<string> lines = new List<string>();

            string line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\max\\source\\repos\\Test1\\Test1\\Students.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    try
                    {
                        string[] subs = line.Split(' ');
                        lines.Add(subs[0] + " " + subs[1] + " "
                            + subs[2] + " " + subs[3] + " " + subs[4]);
                    } catch (Exception e) { }
                    

                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();

                // lines.RemoveAt(index);

                lines[index] = "";

                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("C:\\Users\\max\\source\\repos\\Test1\\Test1\\Students.txt");
                //Write a line of text

                foreach (string s in lines) sw.WriteLine(s);
                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

        }

        public void ReadFile()
        {
            string line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\max\\source\\repos\\Test1\\Test1\\Students.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    try
                    {
                        string[] subs = line.Split(' ');
                        AddStudent(subs[0] + " " + subs[1] + " " + subs[2], subs[3], subs[4]);
                    } catch(Exception e) { }
                    

                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public void WriteFile(string text)
        {
            try
            {
                File.AppendAllText("C:\\Users\\max\\source\\repos\\Test1\\Test1\\Students.txt", text);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
