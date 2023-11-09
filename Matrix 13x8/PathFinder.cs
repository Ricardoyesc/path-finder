class PathFinder
{
    private Board board;

    public PathFinder(Board board)
    {
        this.board = board;
    }

    public List<Tuple<int, int>> FindShortestPath(Tuple<int, int> start)
    {
        int rows = board.GetRows();
        int columns = board.GetColumns();
        
        FindTarget(rows, columns, out var target);

        if (target == null)
        {
            return null;
        }

        Dictionary<Tuple<int, int>, Tuple<int, int>> parents = new Dictionary<Tuple<int, int>, Tuple<int, int>>();
        Dictionary<Tuple<int, int>, int> gScores = new Dictionary<Tuple<int, int>, int>();
        List<Tuple<int, int>> openList = new List<Tuple<int, int>>();
        List<Tuple<int, int>> closedList = new List<Tuple<int, int>>();

        openList.Add(start);
        gScores[start] = 0;

        while (openList.Count > 0)
        {
            Tuple<int, int> current = FindLowestFScore(openList, gScores, target);

            if (current.Equals(target))
            {
                return ReconstructPath(parents, current);
            }

            openList.Remove(current);
            closedList.Add(current);

            List<Tuple<int, int>> neighbors = GetNeighbors(current, rows, columns);

            foreach (var neighbor in neighbors)
            {
                if (closedList.Contains(neighbor))
                {
                    continue;
                }

                int tentativeGScore = gScores[current] + 1;

                if (!openList.Contains(neighbor) || tentativeGScore < gScores[neighbor])
                {
                    parents[neighbor] = current;
                    gScores[neighbor] = tentativeGScore;

                    if (!openList.Contains(neighbor))
                    {
                        openList.Add(neighbor);
                    }
                }
            }
        }

        return null;
    }

    private void FindTarget(int rows, int columns, out Tuple<int, int> target)
    {
        target = null;
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
                if (board.GetCellValue(x, y) == 'X')
                {
                    target = new Tuple<int, int>(x, y);
                    break;
                }
            }
        }
    }

    private Tuple<int, int> FindLowestFScore(List<Tuple<int, int>> openList, Dictionary<Tuple<int, int>, int> gScores, Tuple<int, int> goal)
    {
        Tuple<int, int> lowestFScoreNode = openList[0];
        int lowestFScore = gScores[lowestFScoreNode] + HeuristicCostEstimate(lowestFScoreNode, goal);

        foreach (var node in openList)
        {
            int fScore = gScores[node] + HeuristicCostEstimate(node, goal);
            if (fScore < lowestFScore)
            {
                lowestFScoreNode = node;
                lowestFScore = fScore;
            }
        }

        return lowestFScoreNode;
    }

    private int HeuristicCostEstimate(Tuple<int, int> current, Tuple<int, int> goal)
    {
        return Math.Abs(current.Item1 - goal.Item1) + Math.Abs(current.Item2 - goal.Item2);
    }

    private List<Tuple<int, int>> GetNeighbors(Tuple<int, int> current, int rows, int columns)
    {
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };
        List<Tuple<int, int>> neighbors = new List<Tuple<int, int>>();

        for (int i = 0; i < 4; i++)
        {
            int x = current.Item1 + dx[i];
            int y = current.Item2 + dy[i];

            if (x >= 0 && x < rows && y >= 0 && y < columns && board.GetCellValue(x, y) != 'B')
            {
                neighbors.Add(new Tuple<int, int>(x, y));
            }
        }

        return neighbors;
    }

    private List<Tuple<int, int>> ReconstructPath(Dictionary<Tuple<int, int>, Tuple<int, int>> parents, Tuple<int, int> current)
    {
        List<Tuple<int, int>> path = new List<Tuple<int, int>> { current };
        while (parents.ContainsKey(current))
        {
            current = parents[current];
            board.SetCell(current.Item1, current.Item2, 'P');
            path.Insert(0, current);
        }
        return path;
    }
}
