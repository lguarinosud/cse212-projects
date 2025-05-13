using System.Net;
using System.Runtime.ExceptionServices;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>


    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // 1. Create an array of doubles with the size of 'length'.
        //    This will be the array that will hold the multiples of 'number'.
        double[] multiples = new double[length];
        // 2. Loop through the array and assign each element to be the multiple of 'number' and the index.
        // The for loop will iterate from 0 to length -1. 
        for (int i = 0; i < length; i++)
        {
            // Now we will use the index to calculate a secuence of multiples of the number. The + 1 is used to avoid mutliplying by 0.
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // 1 - Create a new array list to hold my rotatelistRight. It needs to be a fixed array int[] so it won't failed when the list is empty and we are trying to add items. 

        int[] rotatedArray = new int[data.Count];
        // 2 - Use a for Loop to itirate each item, and Calculate the module using variable "amount" to get the new index.
        for (int i = 0; i < data.Count; i++)
        {
            // Calculate the new index
            int newIndex = (i + amount) % data.Count;

            // 3 - Add the item to the new list at the new index
            rotatedArray[newIndex] = data[i];
        }
        // 4 - We need to clear the original list, so it will make it easy to add the new rotated list
        data.Clear();

        // 5 - Add the rotated list to the original list
        data.AddRange(rotatedArray);




    }
}
