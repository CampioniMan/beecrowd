const int maxN = 1000;
var leaderIndexes = new int[maxN];
var componentSizes = new ulong[maxN];

string? input;
while (!string.IsNullOrEmpty(input = Console.ReadLine()))
{
    var splitInput = input.Split(' ');
    var n = StringToInt(splitInput[0]);
    var m = StringToInt(splitInput[1]);
    for (var i = 0; i < n; i++)
    {
        leaderIndexes[i] = i;
        componentSizes[i] = 1;
    }
    
    ConstructGraphAndFindComponents(m);
    
    var capturedSpecie = StringToInt(Console.ReadLine()!);
    Console.WriteLine(componentSizes[FindSet(capturedSpecie - 1)]);
}

return 0;

void ConstructGraphAndFindComponents(int m)
{
    for (var i = 0; i < m; i++)
    {
        var line = Console.ReadLine()!;
        var splitInput = line.Split(' ');
        var specieIdA = StringToInt(splitInput[0]);
        var specieIdB = StringToInt(splitInput[1]);

        if (specieIdA == specieIdB) continue;

        var leaderA = FindSet(specieIdA - 1);
        var leaderB = FindSet(specieIdB - 1);

        if (leaderA == leaderB) continue;

        Union(leaderB, leaderA);
    }
}

void Union(int first, int second)
{
    if (componentSizes[first] > componentSizes[second])
    {
        (second, first) = (first, second);
    }

    leaderIndexes[first] = second;
    componentSizes[second] += componentSizes[first];
}

int FindSet(int childIndex)
{
    if (childIndex == leaderIndexes[childIndex])
        return childIndex;
    leaderIndexes[childIndex] = FindSet(leaderIndexes[childIndex]);
    return leaderIndexes[childIndex];
}

int StringToInt(string s)
{
    var result = 0;
    foreach (var character in s)
    {
        result = result * 10 + (character - '0');
    }
    return result;
}
