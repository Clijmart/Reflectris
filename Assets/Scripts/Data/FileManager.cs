using System;
using System.IO;
using UnityEngine;

public static class FileManager
{
    /// <summary>
    /// Write string to a file.
    /// </summary>
    /// <param name="fileName">The file to write to.</param>
    /// <param name="fileContents">The string to write to the file.</param>
    /// <returns>Whether or not the writing went successfully.</returns>
    public static bool WriteToFile(string fileName, string fileContents)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, fileName);

        try
        {
            File.WriteAllText(fullPath, fileContents);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to write to {fullPath} with exception {e}");
            return false;
        }
    }

    /// <summary>
    /// Load string from a file.
    /// </summary>
    /// <param name="fileName">The file to load from.</param>
    /// <param name="result">The string loaded from the file.</param>
    /// <returns>Whether or not the loading went successfully.</returns>
    public static bool LoadFromFile(string fileName, out string result)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, fileName);

        try
        {
            result = File.ReadAllText(fullPath);
            return true;
        }
        catch (Exception e)
        {
            result = "";
            if (!File.Exists(fullPath))
                Debug.Log($"No save data to read from {fullPath}. Using default values.");
            else
                Debug.LogError($"Failed to read from {fullPath} with exception {e}");
            return false;
        }
    }
}