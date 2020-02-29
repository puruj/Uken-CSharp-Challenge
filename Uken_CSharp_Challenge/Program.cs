using System;
using System.Collections.Generic;
using System.IO;

namespace Uken_CSharp_Challenge
{
    class Program
    {
        static List<int> list = new List<int>();
        static string txt = "5.txt";
        static string path = @"C:\Users\Puru\Desktop\qa\" + txt;
        static void Main(string[] args)
        {
            ReaderZ();            
        }
        private static void ReaderZ()
        {
            string line;            
            StreamReader file = new StreamReader(path);
            while((line = file.ReadLine()) != null)
            {
                list.Add(int.Parse(line));
            }
            int[] arr = list.ToArray();
            Console.Write("File: " + txt + ", Number: " + fewestRepeats(arr)[0] + ", Repeated: " + fewestRepeats(arr)[1] + " times \n");
        }

        // finds number that repeats the fewest
        static int[] fewestRepeats(int[] arr)
        {
            int n = arr.Length;
            // Insert all elements in hash. 
            Dictionary<int, int> count = new Dictionary<int,int>();
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
                    count.Add(key, 1);
            }

            // find the min frequency 
            int min_count = n + 1, res = -1;
            bool init = true;
            foreach (KeyValuePair<int,int> pair in count)
            {
                if (min_count >= pair.Value )
                {
                    //initialzation
                    if (init)
                    {                        
                        res = pair.Key;
                        min_count = pair.Value;
                        init = false;
                    }
                    if(res > pair.Key)
                    {
                        res = pair.Key;
                        min_count = pair.Value;
                    }
                     //   Console.Write("res: " + res + " minCount: " + min_count + " \n"); 
                }
            }            
            return new int[] { res, min_count };
        }
    }
}
