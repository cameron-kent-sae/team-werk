using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem 
{
    public static void SavePlayer(Player player)
    {
        Debug.Log("Save called");
        
        //Create a formatter to convert game data to binary for file storage
        BinaryFormatter formatter = new BinaryFormatter();

        //create a destination path for save files
        string path = Application.persistentDataPath + "/player.save1";
        FileStream stream = new FileStream(path, FileMode.Create);

        //create a new PlayerData and access the player gameObject
        PlayerData data = new PlayerData(player);

        //Save the data and the close the file
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        Debug.Log("Load called");

        //Access the file path for retrieval
        string path = Application.persistentDataPath + "/player.save1";
        
        //Check if there is a file to load
        if (File.Exists(path))
        {
            //Create a formatter to open and ream the file
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Debug.Log("File called");

            //Convert the binary data to game data and the close the file
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        } else
        {
            Debug.LogError("Save file not found");
            return null;
        }
    }
}
