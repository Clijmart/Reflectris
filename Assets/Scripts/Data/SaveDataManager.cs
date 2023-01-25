using System.Collections.Generic;

public static class SaveDataManager
{
    private static Dictionary<string, ISaveable> saveables = new();

    public static void AddSaveable(string saveableType, ISaveable saveable)
    {
        saveables[saveableType] = saveable;
    }

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