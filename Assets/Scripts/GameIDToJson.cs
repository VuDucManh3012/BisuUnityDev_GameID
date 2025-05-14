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
        CleanString(gameId);

        string json = JsonConvert.SerializeObject(gameId, Formatting.Indented);

        string filePath = Path.Combine(_typeApp == TypeApp.Android ? pathAndroid : pathIOS, gameId.packageName + ".json");

        File.WriteAllText(filePath, json);

        Debug.Log("Init Json Succeed");
    }

    void CleanString(GameId gameId)
    {
        gameId.packageName = RemoveEmptyEntries(gameId.packageName);
        gameId.adjustID = RemoveEmptyEntries(gameId.adjustID);

        gameId.admobId = RemoveEmptyEntries(gameId.admobId);

        gameId.bannerId = RemoveEmptyEntries(gameId.bannerId);
        gameId.interId = RemoveEmptyEntries(gameId.interId);
        gameId.rewardId = RemoveEmptyEntries(gameId.rewardId);
        gameId.aoaId = RemoveEmptyEntries(gameId.aoaId);
        gameId.maxDevKey = RemoveEmptyEntries(gameId.maxDevKey);

        for (int i = 0; i < gameId.listNativeId.Count; i++)
        {
            gameId.listNativeId[i] = RemoveEmptyEntries(gameId.listNativeId[i]);
        }
    }
    string RemoveEmptyEntries(string input)
    {
        return string.Join(" ", input.Split(new[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries));
    }
}
