using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public FieldsContainer FieldsContainerObject;
    public GridTile SingleTileObject;
  
    void GenerateGrid(JsonData jsonData)
    {
        FieldsContainerObject.Grid = null;
        FieldsContainerObject.Grid = new GridTile[FieldsContainerObject.TotalRowCount, FieldsContainerObject.TotalColumnCount];

        for (int i = 0; i < FieldsContainerObject.TotalRowCount; i++)
        {
            for (int j = 0; j < FieldsContainerObject.TotalColumnCount; j++)
            {
                GridTile tile = Instantiate(SingleTileObject, new Vector2(i, j), Quaternion.identity);
                FieldsContainerObject.Grid[i, j] = tile;
               
                tile.SpriteRendererReference.sprite = FieldsContainerObject.GridTiles[jsonData.TerrainGrid[i][j].TileType];
                tile.TileType = jsonData.TerrainGrid[i][j].TileType;
                tile.transform.parent = this.transform;
            }
        }
    }

    private void OnEnable()
    {
        JsonReader.JsonDataContainer += GenerateGrid;
    }
    private void OnDisable()
    {
        JsonReader.JsonDataContainer -= GenerateGrid;
        
    }
}
