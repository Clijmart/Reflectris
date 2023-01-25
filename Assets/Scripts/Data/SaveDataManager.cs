using System.Collections.Generic;

public static class SaveDataManager
{
    private static Dictionary<string, ISaveable> saveables = new();

    /// <summary>
    /// Add a saveable instance to the dictionary.
    /// </summary>
    /// <param name="saveableType">The type of saveable.</param>
    /// <param name="saveable">The saveable instance</param>
    public static void AddSaveable(string saveableType, ISaveable saveable)
    {
        saveables[saveableType] = saveable;
    }

    /// <summary>
    /// Save the data from the saveable instances to the json file.
    /// </summary>
    public static void SaveJsonData()
    {
        SaveData saveData = new();
        foreach (var saveable in saveables.Values)
        {
            saveable.PopulateSaveData(saveData);
        }

        if (FileManager.WriteToFile("SaveData.dat", saveData.ToJson()))
        {
            //Debug.Log("Save successful");
        }
    }

    /// <summary>
    /// Load the data to the saveable instances from the json file.
    /// </summary>
    public static void LoadJsonData()
    {
        if (FileManager.LoadFromFile("SaveData.dat", out var json))
        {
            SaveData saveData = new();
            saveData.LoadFromJson(json);

            foreach (var saveable in saveables.Values)
            {
                saveable.LoadFromSaveData(saveData);
            }

            //Debug.Log("Load complete");
        }
    }
}