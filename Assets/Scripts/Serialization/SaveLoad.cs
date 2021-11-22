using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public static class SaveLoad
{
    public static bool newGame;
    public static bool loadGame;

    public static void Save(LevelSystem playerLevel, PermStat playerStat, AvailableStatPoints ASP, skillavailablepoints SAP, DifficultySelect ds)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.toia";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(playerLevel, playerStat, ASP, SAP, ds);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData Load()
    {
        string path = Application.persistentDataPath + "/player.toia";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            loadGame = true;
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static bool CheckSave()
    {
        string path = Application.persistentDataPath + "/player.toia";
        if (File.Exists(path)){
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void NewSave()
    {
        string path = Application.persistentDataPath + "/player.toia";
        File.Delete(path);
        newGame = true;
    }
}
