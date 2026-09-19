/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Check to see if you can move left.
    /// </summary>
    public void MoveLeft()
    {
        bool[] movements = _mazeMap[(_currX, _currY)];

        if (!movements[0])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currX--;
    }

    /// <summary>
    /// Check to see if you can move right.
    /// </summary>
    public void MoveRight()
    {
        bool[] movements = _mazeMap[(_currX, _currY)];

        if (!movements[1])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currX++;
    }

    /// <summary>
    /// Check to see if you can move up.
    /// </summary>
    public void MoveUp()
    {
        bool[] movements = _mazeMap[(_currX, _currY)];

        if (!movements[2])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currY--;
    }

    /// <summary>
    /// Check to see if you can move down.
    /// </summary>
    public void MoveDown()
    {
        bool[] movements = _mazeMap[(_currX, _currY)];

        if (!movements[3])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currY++;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}