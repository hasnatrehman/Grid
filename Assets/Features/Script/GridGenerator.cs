using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public FieldsContainer FieldsContainerObject;
    public GridTile SingleTileObject;
   

    private void Start()
    {
        if(SingleTileObject == null)
        {
            
        }
    }
    void generateGrid(JsonData jsonData)
    {
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
        json_reader.JsonDataContainer += generateGrid;
    }
    private void OnDisable()
    {
        json_reader.JsonDataContainer -= generateGrid;
        
    }
}
