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

        // Deserialize JSON into JsonData object
         terrainGrid = JsonConvert.DeserializeObject<JsonData>(jsonFile.text);

        if (terrainGrid == null || terrainGrid.TerrainGrid == null)
        {
            Debug.LogError("Failed to parse JSON data.");
            return;
        }

        // Access your terrain data
        _rowCount = terrainGrid.TerrainGrid.Length;
        _columnCount = terrainGrid.TerrainGrid[0].Length;

        Debug.Log("Rows: " + _rowCount + ", Columns: " + _columnCount);

        // Print and save the tile type of each block
        for (int i = 0; i < _rowCount; i++)
        {
            for (int j = 0; j < _columnCount; j++)
            {
                int tileType = terrainGrid.TerrainGrid[i][j].TileType;
                Debug.Log("Tile Type at (" + i + ", " + j + "): " + tileType);
            }
        }


        
    }



}