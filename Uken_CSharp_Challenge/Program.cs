/*
 This program will calculate the fewest numbers of repeats in a .txt file, if there is two numbers with same amount it will pick the smallest number.

How to use: In the "folder" variable set the home folder of .txt files.
            In "amtofFiles" variable put the amount of .txt files that are in the "folder" variable.


 Assumptions: Files will not have any illegal characters, illegal character defined as any value that's not a 32-bit signed integer. 
              .txt file does not have a line break in between numbers. 
              Files are named with a number prefix i.e (1,2,3,4,5,6,7,8...) and are sequentially named.

By: Puru Jetly
For Uken C# challenge for Uken Junior QA position.
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace Uken_CSharp_Challenge
{
    class Program
    {
        //Set folder in which txt files are located and amount of files to calculate fewest repeat number
        static string folder = @"C:\Users\Puru\Desktop\qa\";
        static int  amtofFiles = 5;

        static void Main(string[] args)
        {
            int[] numbers;
            for (int i = 1; i <= amtofFiles; i++){
                //use array to just read the file once for a single txt file
                numbers = fileReader(i.ToString() + ".txt");
                //writes to console appropriate ouput
                Console.Write("File: " + i.ToString() + ".txt" + ", Number: " + fewestRepeats(numbers)[0] + ", Repeated: " + fewestRepeats(numbers)[1] + " times \n");
            }

        }
        //reads txt file and returns it as a array 
        private static int[] fileReader(string txtFile)
        {
            //intialize list as don't know how many lines are in the txt file
            List<int> list = new List<int>();
            string line;            
            StreamReader file = new StreamReader(folder + txtFile);
            //as long as a line is not null add that number to the list 
            while((line = file.ReadLine()) != null)
            {
                list.Add(int.Parse(line));
            }      
            //returning as array for calculations, allows for constant search and access time  
            return list.ToArray();
        }

        // finds number that repeats the fewest
        static int[] fewestRepeats(int[] arr)
        {
            int n = arr.Length;
            // Initialize hash table
            Dictionary<int, int> count = new Dictionary<int,int>();
            //puts keys(number) in hash along with appropriate value (frequency of that number)
            for (int i = 0; i < n; i++)
            {
                int key = arr[i];
                //if the number already exists in the hash table increase the frequency count of it 
                if (count.ContainsKey(key))
                {
                    int frequency = count[key];
                    frequency++;
                    count[key] = frequency;
                }
                else
                    // if number not in hash table intialize it with frequency of 1 
                    count.Add(key, 1);
            }

            // find the min frequency 
            //initialize values to allow for first entry in dictionary to initialize return int array
            int minimumCount = n + 1, result = -1;
            bool init = true;
            //finds smallest and least frequent number 
            foreach (KeyValuePair<int,int> pair in count)
            {
                /*
                 * if current least frequent number is larger than or equal to the new pair value 
                 * and if the current key is larger than new pair key 
                 * Set those as the least frequent and smallest number in .txt file
                 */
                if (minimumCount >= pair.Value )
                {
                    //initialzation
                    if (init)
                    {                        
                        result = pair.Key;
                        minimumCount = pair.Value;
                        init = false;
                    }
                    if(result > pair.Key)
                    {
                        result = pair.Key;
                        minimumCount = pair.Value;
                    }
                }
            }            
            return new int[] { result, minimumCount };
        }
    }
}
