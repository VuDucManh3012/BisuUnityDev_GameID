using Newtonsoft.Json;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameIDToJson : MonoBehaviour
{
#if UNITY_EDITOR
    [FolderPath, Header("Path to panels")]
    public string path;
#endif
    [Button]
    public void SaveGameIDToJsonFile(GameId gameId)
    {
        string json = JsonConvert.SerializeObject(gameId, Formatting.Indented);

        string filePath = Path.Combine(path, gameId.packageName + ".json");

        File.WriteAllText(filePath, json);

        Debug.Log("Init Json Succeed");
    }
}
