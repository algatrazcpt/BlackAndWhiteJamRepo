using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class GameSaveSystem : MonoBehaviour
{
    public static void SaveGame(int id)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerDialog.dat";

        FileStream fs = new FileStream(path, FileMode.Create);

        SaveData binaryData = new SaveData(id);

        binaryFormatter.Serialize(fs, binaryData);
        fs.Close();

    }
    public static SaveData LoadGame()
    {
        string path = Application.persistentDataPath + "/playerDialog.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);
            SaveData save = formatter.Deserialize(fs) as SaveData;
            fs.Close();
            return save;
        }
        else
        {
            Debug.Log("Save file not found");
            return null;
        }
    }
}
