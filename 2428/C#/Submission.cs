using System; 

class URI {

    static int StringToInt(string s)
    {
        var result = 0;
        foreach (var character in s)
        {
            result = result * 10 + (character - '0');
        }
        return result;
    }

    // This code is contributed by nitin mittal.
    static void BinaryInsertionSort(int[] array)
    {
        for (var i = 1; i < array.Length; i++)
        {
            var x = array[i];
            var j = Math.Abs(Array.BinarySearch(array, 0, i, x) + 1);
            Array.Copy(array, j, array, j + 1, i - j);
            array[j] = x;
        }
    }

    static void Main(string[] args) { 
        var input = Console.ReadLine();
        var splitInput = input.Split(' ');
        var areas = new int[splitInput.Length];
        for (var index = 0; index < splitInput.Length; index++)
        {
            areas[index] = StringToInt(splitInput[index]);
        }
        BinaryInsertionSort(areas);

        var horizontalCondition = decimal.Divide(areas[0], areas[1]) == decimal.Divide(areas[2], areas[3]);
        var verticalCondition = decimal.Divide(areas[0], areas[2]) == decimal.Divide(areas[1], areas[3]);

        var output = horizontalCondition && verticalCondition ? "S" : "N";
        Console.WriteLine(output);
    }

}