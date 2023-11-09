Board board = new Board();
board.PrintBoard();

PathFinder pathFinder = new PathFinder(board);
List<Tuple<int, int>> shortestPath = pathFinder.FindShortestPath(new Tuple<int, int>(0, 0));
//List<Tuple<int, int>> shortestPath = pathFinder.FindShortestPath(new Tuple<int, int>(board.GetRows() - 1, 0));
//List<Tuple<int, int>> shortestPath = pathFinder.FindShortestPath(new Tuple<int, int>(0, board.GetColumns() - 1));
//List<Tuple<int, int>> shortestPath = pathFinder.FindShortestPath(new Tuple<int, int>(board.GetRows()-1, board.GetColumns() - 1));

if (shortestPath != null)
{
    Console.WriteLine("Ruta más corta para llegar a X:");
    foreach (var point in shortestPath)
    {
        Console.WriteLine($"({point.Item1}, {point.Item2})");
    }
    board.PrintBoard();
}
else
{
    Console.WriteLine("No hay rutas posibles para llegar a X.");
}