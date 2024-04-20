using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacementHandler : MonoBehaviour
{
    public FieldsContainer FieldsContainer;
    public void NeighbourFinding(int x, int y, int type)
    {
      
        // for right neighbour

        if (x != FieldsContainer.TotalRowCount - 1 && FieldsContainer.Grid[x + 1, y].TileType == 3 && FieldsContainer.Grid[x + 1, y].IsOccopied == false)
        {
            Debug.LogError("Right neighbour is available");

           // Instantiate(HorizontalTable, new Vector2(x + 0.5f, y), Quaternion.identity);

            FieldsContainer.Grid[x, y].IsOccopied = true;
            FieldsContainer.Grid[x + 1, y].IsOccopied = true;

        }
        // down
        else if (y >= FieldsContainer.TotalColumnCount / FieldsContainer.TotalColumnCount && FieldsContainer.Grid[x, y - 1].TileType == 3 && FieldsContainer.Grid[x, y - 1].IsOccopied == false)
        {
            Debug.LogError("down neighbour is available");
          //  Instantiate(VerticleTable, new Vector2(x, y - 0.5f), Quaternion.identity);
            FieldsContainer.Grid[x, y].IsOccopied = true;
            FieldsContainer.Grid[x, y - 1].IsOccopied = true;
        }
        // left
        else if (x >= FieldsContainer.TotalRowCount / FieldsContainer.TotalRowCount && FieldsContainer.Grid[x - 1, y].TileType == 3 && FieldsContainer.Grid[x - 1, y].IsOccopied == false)
        {
            Debug.LogError("Left neighbour is available");

          //  Instantiate(HorizontalTable, new Vector2(x - 0.5f, y), Quaternion.identity);
            FieldsContainer.Grid[x, y].IsOccopied = true;
            FieldsContainer.Grid[x - 1, y].IsOccopied = true;

        }
        // top
        else if (y != FieldsContainer.TotalColumnCount - 1 && FieldsContainer.Grid[x, y + 1].TileType == 3 && FieldsContainer.Grid[x, y + 1].IsOccopied == false)
        {
            Debug.LogError("Top neighbour is available");
            //  Instantiate(VerticleTable, new Vector2(x, y + 0.5f), Quaternion.identity);
            FieldsContainer.Grid[x, y].IsOccopied = true;
            FieldsContainer.Grid[x, y + 1].IsOccopied = true;
        }
        else
        {
            Debug.LogError("Nass ja No Space");
        }

    }


    private void OnEnable()
    {
        GridTile.RootTileData += NeighbourFinding;
    }

    private void OnDisable()
    {
        GridTile.RootTileData -= NeighbourFinding;
    }
}
