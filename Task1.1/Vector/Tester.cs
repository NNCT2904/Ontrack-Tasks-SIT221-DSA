using System;

namespace Vector
{
    class Tester
    {

        private static bool CheckIntSequence(int[] certificate, Vector<int> vector)
        {
            if (certificate.Length != vector.Count) return false;
            for (int i = 0; i < certificate.Length; i++)
            {
                if (certificate[i] != vector[i]) return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            Vector<int> vector = null;
            string result = "";

            // test 1
            try
            {
                Console.WriteLine("\nTest A: Create a new vector by calling 'Vector<int> vector = new Vector<int>(50);'");
                vector = new Vector<int>(50);
                Console.WriteLine(" :: SUCCESS");
                result = result + "A";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 2
            try
            {
                Console.WriteLine("\nTest B: Add a sequence of numbers 2, 6, 8, 5, 5, 1, 8, 5, 3, 5");
                vector.Add(2); vector.Add(6); vector.Add(8); vector.Add(5); vector.Add(5); vector.Add(1); vector.Add(8); vector.Add(5); vector.Add(3); vector.Add(5);
                if (!CheckIntSequence(new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5 }, vector)) throw new Exception("Vector stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "B";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 3
            try
            {
                Console.WriteLine("\nTest C: Remove number 3, 7, and then 6");
                bool check = vector.Remove(3) && (!vector.Remove(7)) && vector.Remove(6);
                if (!CheckIntSequence(new int[] { 2, 8, 5, 5, 1, 8, 5, 5 }, vector)) throw new Exception("Vector stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "C";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 4
            try
            {
                Console.WriteLine("\nTest D: Insert number 50 at index 6, then number 0 at index 0, then number 60 at index 'vector.Count-1', then number 70 at index 'vector.Count'");
                vector.Insert(6, 50); vector.Insert(0, 0); vector.Insert(vector.Count - 1, 60); vector.Insert(vector.Count, 70);
                if (!CheckIntSequence(new int[] { 0, 2, 8, 5, 5, 1, 8, 50, 5, 60, 5, 70 }, vector)) throw new Exception("Vector stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "D";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 5
            try
            {
                Console.WriteLine("\nTest E: Insert number -1 at index 'vector.Count+1'");
                vector.Insert(vector.Count + 1, -1);
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine(" :: SUCCESS");
                result = result + "E";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine("Last operation is invalid and must throw IndexOutOfRangeException. Your solution does not match specification.");
                result = result + "-";
            }

            // test 6
            try
            {
                Console.WriteLine("\nTest F: Remove number at index 4, then number index 0, and then number at index 'vector.Count-1'");
                vector.RemoveAt(4); vector.RemoveAt(0); vector.RemoveAt(vector.Count - 1);
                if (!CheckIntSequence(new int[] { 2, 8, 5, 1, 8, 50, 5, 60, 5 }, vector)) throw new Exception("Vector stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "F";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 7
            try
            {
                Console.WriteLine("\nTest G: Remove number at index 'vector.Count'");
                vector.RemoveAt(vector.Count);
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine(" :: SUCCESS");
                result = result + "G";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine("Last operation is invalid and must throw IndexOutOfRangeException. Your solution does not match specification.");
                result = result + "-";
            }

            // test 8
            try
            {
                Console.WriteLine("\nTest H: Run a sequence of operations: ");

                Console.WriteLine("vector.Contains(1);");
                if (vector.Contains(1)) Console.WriteLine(" :: SUCCESS");
                else throw new Exception("1 must be in the vector");

                Console.WriteLine("vector.Contains(2);");
                if (vector.Contains(2)) Console.WriteLine(" :: SUCCESS");
                else throw new Exception("2 must be in the vector");

                Console.WriteLine("vector.Contains(4);");
                if (!vector.Contains(4)) Console.WriteLine(" :: SUCCESS");
                else throw new Exception("4 must not be in the vector");

                Console.WriteLine("vector.Add(4); vector.Contains(4);");
                vector.Add(4);
                if (vector.Contains(4)) Console.WriteLine(" :: SUCCESS");
                else throw new Exception("4 must be in the vector");

                result = result + "H";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 9
            try
            {
                Console.WriteLine("\nTest I: Print the content of the vector via calling vector.ToString();");
                Console.WriteLine(vector.ToString());
                Console.WriteLine(" :: SUCCESS");
                result = result + "I";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 10
            try
            {
                Console.WriteLine("\nTest J: Clear the content of the vector via calling vector.Clear();");
                vector.Clear();
                if (!CheckIntSequence(new int[] { }, vector)) throw new Exception("Vector stores incorrect data. It must be empty.");
                Console.WriteLine(" :: SUCCESS");
                result = result + "J";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            Console.WriteLine("\n\n ------------------- SUMMARY ------------------- ");
            Console.WriteLine("Tests passed: " + result);
            Console.ReadKey();
        }
    }
}
