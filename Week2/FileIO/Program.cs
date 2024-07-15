using System;
using System.IO;
using System.Collections.Generic;

namespace FileIO
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello Again!");
            string path = @"./TestText.txt";
            StreamReader sr = new StreamReader(path);

            string text = "some content for the file";

            // read, write (overwrite content, or create the file), append (add to the end of the file)
            if( !File.Exists(path))
            {
                File.WriteAllText(path, text);
                //File.WriteAllLines(path, string[]);
            }
            else
            {
                Console.WriteLine("Reading from file with File.ReadAllText: ");
                text = File.ReadAllText(path);
                Console.WriteLine(text);
            }
            
            Console.WriteLine();
            Console.WriteLine("Reading from file with StreamReader (line by line): ");
            while((text = sr.ReadLine()) != null)
            {
                Console.Write(text);
                Console.WriteLine(" -- ");
            }

            sr.Close();
            sr = new StreamReader(path);
            
            Console.WriteLine();
            Console.WriteLine("Reading from file with StreamReader (EOF): ");
            while((text = sr.ReadToEnd()) != "")
            {
                Console.Write(text);
                Console.WriteLine(" -- ");
            }
            sr.Close();

            Console.WriteLine("\n\n\n");

            //Duck myDuck = new Duck("purple", 100);
            //myDuck.Quack();
            //Console.WriteLine(myDuck.ToString());
            path = @"./Ducks.txt";
            string ducks = File.ReadAllText(path);
            Console.WriteLine(ducks);
            string[] duckVals = ducks.Split(' ');
            Duck mySavedDuck = new Duck(duckVals[0], int.Parse(duckVals[1]));
            mySavedDuck.Quack();

            sr = new StreamReader(path);
            List<Duck> duckList = new List<Duck>();

            while((text = sr.ReadLine()) != null)
            {
                duckVals = ducks.Split(' ');
                mySavedDuck = new Duck(duckVals[0], int.Parse(duckVals[1]));
                mySavedDuck.Quack();
            }
            sr.Close();

            foreach(Duck d in duckList)
            {
                d.Quack();
            }
        }
    }

    class Duck
    {
        public string color {get; set;}
        public int numFeathers {get; set;}

        public Duck (string color, int feathers)
        {
            this.color = color;
            this.numFeathers = feathers;
        }

        public void Quack()
        {
            Console.WriteLine("Quack! I'm {0}", this.color);
        }

        public string ToString()
        {
            string result = "";
            result = this.color + " " + this.numFeathers;
            return result;
        }
    }
}