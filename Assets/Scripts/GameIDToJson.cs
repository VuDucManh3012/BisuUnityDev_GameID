using Newtonsoft.Json;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum TypeApp
{
    Android,
    IOS
}
public class GameIDToJson : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField] private TypeApp _typeApp;

    [FolderPath, Header("Path to panels")]
    public string pathAndroid;

    [FolderPath, Header("Path to panels")]
    public string pathIOS;
#endif
    [Button]
    public void SaveGameIDToJsonFile(GameId gameId)
    {
        string json = JsonConvert.SerializeObject(gameId, Formatting.Indented);

        string filePath = Path.Combine(_typeApp == TypeApp.Android ? pathAndroid : pathIOS, gameId.packageName + ".json");

        File.WriteAllText(filePath, json);

        Debug.Log("Init Json Succeed");
    }
}
