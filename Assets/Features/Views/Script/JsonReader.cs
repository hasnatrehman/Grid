using UnityEngine;
using Newtonsoft.Json;
using System;

public class JsonData
{
    public TileProperty[][] TerrainGrid { get; set; }
}

public class TileProperty
{
    public int TileType { get; set; }
}

public class JsonReader : MonoBehaviour
{
    public FieldsContainer FieldsContainerObject;
    public static Action<JsonData> JsonDataContainer;
    JsonData _terrainGrid;
   
    void Start()
    {

        JsonReaderMeathod();
    }

    void JsonReaderMeathod()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("GridData");

        if (jsonFile == null)
        {
            Debug.LogError("Failed to load JSON.");
            return;
        }

        _terrainGrid = JsonConvert.DeserializeObject<JsonData>(jsonFile.text);

        if (_terrainGrid == null || _terrainGrid.TerrainGrid == null)
        {
            return;
        }

       

        FieldsContainerObject.TotalRowCount = _terrainGrid.TerrainGrid.Length;
        FieldsContainerObject.TotalColumnCount = _terrainGrid.TerrainGrid[0].Length;

        JsonDataContainer?.Invoke(_terrainGrid);
    }

    private void OnDisable()
    {
        FieldsContainerObject.TotalRowCount = 0;
        FieldsContainerObject.TotalColumnCount = 0;
    }









}