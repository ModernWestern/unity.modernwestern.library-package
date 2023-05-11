using UnityEngine;
using System.Collections.Generic;

public static class Bresenham
{
    /// <summary>
    /// Generates a list of Vector2 points that represent a straight line trajectory between two points in 2D space.
    /// </summary>
    /// <param name="start">The starting point of the line.</param>
    /// <param name="end">The ending point of the line.</param>
    /// <returns>A list of Vector2 points representing the straight line trajectory.</returns>
    public static List<Vector2> LineTrajectory(Vector2 start, Vector2 end)
    {
        var startInt = new Vector2Int(Mathf.RoundToInt(start.x), Mathf.RoundToInt(start.y));

        var endInt = new Vector2Int(Mathf.RoundToInt(end.x), Mathf.RoundToInt(end.y));

        return LineTrajectory(startInt, endInt);
    }

    /// <summary>
    /// Generates a list of Vector2 points that represent a straight line trajectory between two points in 2D space.
    /// </summary>
    /// <param name="start">The starting point of the line.</param>
    /// <param name="end">The ending point of the line.</param>
    /// <returns>A list of Vector2 points representing the straight line trajectory.</returns>
    public static List<Vector2> LineTrajectory(Vector2Int start, Vector2Int end)
    {
        List<Vector2> trajectory = new();

        int deltaX = Mathf.Abs(start.x - end.x), sx = end.x < start.x ? 1 : -1;

        int deltaY = Mathf.Abs(start.y - end.y), sy = end.y < start.y ? 1 : -1;

        var distanceFromIdealPosition = (deltaX > deltaY ? deltaX : -deltaY) / 2;

        while (true)
        {
            trajectory.Add(new Vector2(end.x, end.y));

            if (end.x == start.x && end.y == start.y)
            {
                break;
            }

            var error = distanceFromIdealPosition;

            if (error > -deltaX)
            {
                distanceFromIdealPosition -= deltaY;
                end.x += sx;
            }

            if (error < deltaY)
            {
                distanceFromIdealPosition += deltaX;
                end.y += sy;
            }
        }

        return trajectory;
    }
}