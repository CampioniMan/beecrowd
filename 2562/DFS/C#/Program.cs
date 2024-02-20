using PokemonTypes;

int StringToInt(string s)
{
    var result = 0;
    foreach (var character in s)
    {
        result = result * 10 + (character - '0');
    }
    return result;
}

string? input; // maybe Console.In.ReadToEnd();
while (!string.IsNullOrEmpty(input = Console.ReadLine()))
{
    var splitInput = input.Split(' ');
    var n = StringToInt(splitInput[0]);
    var m = StringToInt(splitInput[1]);
    var vertices = new CustomNode[n];
    for (var i = 0; i < n; i++)
    {
        vertices[i] = new CustomNode
        {
            Neighbours = new List<CustomNode>(),
            Visited = false
        };
    }
    
    for (var i = 0; i < m; i++)
    {
        input = Console.ReadLine()!;
        splitInput = input.Split(' ');
        var specieIdA = StringToInt(splitInput[0]) - 1;
        var specieIdB = StringToInt(splitInput[1]) - 1;
        if (specieIdA == specieIdB) continue;

        vertices[specieIdA].Neighbours.Add(vertices[specieIdB]);
        vertices[specieIdB].Neighbours.Add(vertices[specieIdA]);
    }
    
    var capturedSpecie = StringToInt(Console.ReadLine()!);
    Console.WriteLine(vertices[capturedSpecie - 1].GetNeighbourhoodSize());
}

return 0;
