using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class JsonData
{
    public TileProperty[][] TerrainGrid { get; set; }
}

public class TileProperty
{
    public int TileType { get; set; }
}

public class json_reader : MonoBehaviour
{
    float _rowCount, _columnCount;
    JsonData  terrainGrid;
 
    void Start()
    {

        TextAsset jsonFile = Resources.Load<TextAsset>("GridData");

        if (jsonFile == null)
        {
            Debug.LogError("Failed to load JSON.");
            return;
        }

        
         terrainGrid = JsonConvert.DeserializeObject<JsonData>(jsonFile.text);

        if (terrainGrid == null || terrainGrid.TerrainGrid == null)
        {
            Debug.LogError("Failed to parse JSON data.");
            return;
        }

        
          _rowCount = terrainGrid.TerrainGrid.Length;
          _columnCount = terrainGrid.TerrainGrid[0].Length;
        
    }

}