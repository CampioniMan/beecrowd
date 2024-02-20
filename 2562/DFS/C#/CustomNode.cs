namespace PokemonTypes;

class CustomNode
{
    public List<CustomNode> Neighbours;
    public bool Visited;

    public int GetNeighbourhoodSize()
    {
        var verticeCount = 1;
        Visited = true;
        foreach (var neighbour in Neighbours)
        {
            if (neighbour.Visited) continue;

            verticeCount += neighbour.GetNeighbourhoodSize();
        }

        Visited = false;
        return verticeCount;
    }
}