using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public FieldsContainer FieldsContainerObject;
    GridTile[,] grid;

    void generateGrid(JsonData jsonData)
    {
        grid = new GridTile[FieldsContainerObject.TotalRowCount, FieldsContainerObject.TotalColumnCount];

        for (int i = 0; i < FieldsContainerObject.TotalRowCount; i++)
        {
            for (int j = 0; j < FieldsContainerObject.TotalColumnCount; j++)
            {
                GridTile tile = Instantiate(FieldsContainerObject.SingleTileObject, new Vector2(i, j), Quaternion.identity);
                grid[i, j] = tile;
               
                tile.SpriteRendererReference.sprite = FieldsContainerObject.GridTiles[jsonData.TerrainGrid[i][j].TileType];
                tile.TileType = jsonData.TerrainGrid[i][j].TileType;
                tile.transform.parent = this.transform;
            }
        }
    }


    private void OnEnable()
    {
        json_reader.JsonDataContainer += generateGrid;
    }
    private void OnDisable()
    {
        json_reader.JsonDataContainer -= generateGrid;
        
    }
}
