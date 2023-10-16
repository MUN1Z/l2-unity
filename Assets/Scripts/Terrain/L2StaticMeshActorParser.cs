using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class L2StaticMeshActorParser
{
    public L2StaticMeshActor GetL2StaticMeshActor(string mapName) {
        string jsonPath = StaticMeshUtils.GetJsonPath(mapName);
        if(!File.Exists(jsonPath)) {
            Debug.Log("No L2StaticMeshActor for map " + mapName);
            return null;
        }

        string jsonText = File.ReadAllText(jsonPath);
        L2StaticMeshActor data = JsonConvert.DeserializeObject<L2StaticMeshActor>(jsonText);

        Debug.Log("GetL2StaticMeshActor for " + mapName);
        Debug.Log(data.ToString());
        return data;
    }
}
