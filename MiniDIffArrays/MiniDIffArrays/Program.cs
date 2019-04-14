//Given k sorted arrays, you need to select one element from each array such that the difference of maximum element and minimum element of the selected elements is minimum.Example for k = 3

//1 13 27 30

//16 20 29

//2 3 14 18 19 22 25 28

//ans: 2 selected elements(27, 29, 28)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniDIffArrays
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] a = { 1, 13, 26, 30 };

            int[] b = { 8, 20, 29 };

            int[] c = { 2, 3, 14, 17, 14, 22, 25, 28 };
            // int[] re = GetNumbers(b, c);
            int[] comb = GetNumbers(b, c);


            int[] final = FinalRes(a, comb);//re.OrderBy(i=>i).ToArray());

            foreach (var i in final)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }

        private static int[] FinalRes(int[] a, int[] re)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            int two = 0;
            int three = 0;

            foreach (int aa in a)
            {
                for (int i = 0; i < re.Length; i++)
                {
                    int f1 = Math.Abs(aa - re[i]);
                    int f2 = Math.Abs(aa - re[i + 1]);
                    if (d.Count == 0)
                    {
                        d.Add(aa, f1 > f2 ? f2 : f1);
                        two = re[i];
                        three = re[i + 1];
                    }
                    else
                    {
                        if (d.Values.ElementAt(0) > f1 || d.Values.ElementAt(0) > f2)
                        {
                            d.Clear();
                            d.Add(aa, f1 > f2 ? f2 : f1);
                            two = re[i];
                            three = re[i + 1];
                        }

                    }
                    ++i;
                }

            }
            int[] final = { d.First().Value, d.First().Key, two, three };

            return final;
        }

        private static int[] GetNumbers(int[] b, int[] c)
        {
            Dictionary<int, List<string>> diff = new Dictionary<int, List<string>>();
            bool firstEntry = true;
            int x = 999;
            for (int j = 0; j < b.Length; j++)
            {
                for (int k = 0; k < c.Length; k++)
                {
                    if (firstEntry && x == 999)
                    {
                        diff.Add(Math.Abs(b[j] - c[k]), new List<string> { b[j].ToString() + "," + c[k].ToString() });
                        x = Math.Abs(b[j] - c[k]);
                        firstEntry = false;
                    }
                    else if (x >= Math.Abs(b[j] - c[k]))
                    {
                        if (diff.ContainsKey(Math.Abs(b[j] - c[k])))
                            diff[Math.Abs(b[j] - c[k])].Add(b[j].ToString() + "," + c[k].ToString());
                        else
                            diff.Add(Math.Abs(b[j] - c[k]), new List<string> { b[j].ToString() + "," + c[k].ToString() });
                        x = Math.Abs(b[j] - c[k]);
                    }

                }
            }
            List<string> combinations = diff.OrderBy(i => i.Key).First().Value;
            List<int> l = new List<int>();
            foreach (var cc in combinations)
            {
                l.AddRange(cc.Split(',').Select(s => int.Parse(s)).ToArray());

            }
            return l.ToArray();
        }
    }
}
