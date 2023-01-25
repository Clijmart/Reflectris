using UnityEngine;

public class TimeUtil
{
    /// <summary>
    /// Turn time into a nicely formatted string.
    /// </summary>
    /// <param name="timeInSeconds">Time in seconds.</param>
    /// <returns>A formatted string.</returns>
    public static string FormattedTime(int timeInSeconds, bool includeHours)
    {
        // Made with the help of https://answers.unity.com/questions/45676/making-a-timer-0000-minutes-and-seconds.html
        string formattedTime;
        if (includeHours)
        {
            int hours = Mathf.FloorToInt(timeInSeconds / 3600f);
            int minutes = Mathf.FloorToInt((timeInSeconds - (hours * 3600)) / 60f);
            int seconds = Mathf.FloorToInt(timeInSeconds - (hours * 3600) - (minutes * 60));

            formattedTime = $"{hours:00}:{minutes:00}:{seconds:00}";
        } else
        {
            int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
            int seconds = Mathf.FloorToInt(timeInSeconds - (minutes * 60));

            formattedTime = $"{minutes:00}:{seconds:00}";
        }

        return formattedTime;
    }
}