using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class GameId
{
    public string packageName = "";

    public string adjustID = "";

    public string admobId = "";
    public string admobBannerId = "";

    public string bannerId = "";
    public string interId = "";
    public string rewardId = "";
    public string aoaId = "";

    public string maxDevKey = "";

    public List<string> listNativeId = new List<string>();
}
