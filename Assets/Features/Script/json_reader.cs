using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using System;

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
    public FieldsContainer FieldsContainerObject;
    public static Action<JsonData> JsonDataContainer;
    JsonData  terrainGrid;
   
    void Start()
    {

        JsonReader();
    }

    void JsonReader()
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
            return;
        }

        FieldsContainerObject.TotalRowCount = terrainGrid.TerrainGrid.Length;
        FieldsContainerObject.TotalColumnCount = terrainGrid.TerrainGrid[0].Length;

        JsonDataContainer?.Invoke(terrainGrid);
    }


       


        



}