using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPlacementHandler : MonoBehaviour
{
    public GameObject ResetButton;
    public FieldsContainer FieldsContainerObject;
    public GameObject VerticleTable, HorizontalTable;
    GameObject _tableContainer;
    
    private void Start()
    {
        if(ResetButton == null)
        {
            ResetButton = GameObject.Find("LevelResetButton");
        }
        if (ResetButton.activeInHierarchy)
        {
            ResetButton.SetActive(false);
        }

        GenerateTablesContainer();
    }
    
    public void NeighbourFinding(int x, int y)             // I prioritized the clockwise detection cycle
    {
        // For Finding Right Neighbour
        if (x != FieldsContainerObject.TotalRowCount - 1 && FieldsContainerObject.Grid[x + 1, y].TileType == 3 && FieldsContainerObject.Grid[x + 1, y].IsOccopied == false)
        {
            
            float objectPlacementAdjuster = (FieldsContainerObject.Grid[x + 1, y].transform.position.x + FieldsContainerObject.Grid[x, y].transform.position.x) / 2;

            GameObject G =  Instantiate(HorizontalTable);
            G.transform.position = new Vector2(objectPlacementAdjuster, y);
            G.transform.SetParent(_tableContainer.transform);
            if(!G.activeInHierarchy)
                G.SetActive(true);

            FieldsContainerObject.Grid[x, y].IsOccopied = true;
            FieldsContainerObject.Grid[x + 1, y].IsOccopied = true;

        }
        // For Finding Down Neighbour
        else if (y >= FieldsContainerObject.TotalColumnCount / FieldsContainerObject.TotalColumnCount && FieldsContainerObject.Grid[x, y - 1].TileType == 3 && FieldsContainerObject.Grid[x, y - 1].IsOccopied == false)
        {
          
            float objectPlacementAdjuster = (FieldsContainerObject.Grid[x , y - 1].transform.position.y + FieldsContainerObject.Grid[x, y].transform.position.y) / 2;

            GameObject G = Instantiate(VerticleTable);
            G.transform.position = new Vector2(x, objectPlacementAdjuster);
            G.transform.SetParent(_tableContainer.transform);
            if (!G.activeInHierarchy)
                G.SetActive(true);
            FieldsContainerObject.Grid[x, y].IsOccopied = true;
            FieldsContainerObject.Grid[x, y - 1].IsOccopied = true;
        }
        // For Finding Left Neighbour
        else if (x >= FieldsContainerObject.TotalRowCount / FieldsContainerObject.TotalRowCount && FieldsContainerObject.Grid[x - 1, y].TileType == 3 && FieldsContainerObject.Grid[x - 1, y].IsOccopied == false)
        {
           
            float objectPlacementAdjuster = (FieldsContainerObject.Grid[x - 1, y].transform.position.x + FieldsContainerObject.Grid[x, y].transform.position.x) / 2;

            GameObject G = Instantiate(HorizontalTable);
            G.transform.position = new Vector2(objectPlacementAdjuster, y);
            G.transform.SetParent(_tableContainer.transform);
            if (!G.activeInHierarchy)
               G.SetActive(true);
            FieldsContainerObject.Grid[x, y].IsOccopied = true;
            FieldsContainerObject.Grid[x - 1, y].IsOccopied = true;

        }
        // For Finding Top Neighbour
        else if (y != FieldsContainerObject.TotalColumnCount - 1 && FieldsContainerObject.Grid[x, y + 1].TileType == 3 && FieldsContainerObject.Grid[x, y + 1].IsOccopied == false)
        {
            
            float objectPlacementAdjuster = (FieldsContainerObject.Grid[x, y + 1].transform.position.y + FieldsContainerObject.Grid[x, y].transform.position.y) / 2;

            GameObject G = Instantiate(VerticleTable);
            G.transform.position = new Vector2(x, objectPlacementAdjuster);
            G.transform.SetParent(_tableContainer.transform);
            if (!G.activeInHierarchy)
               G.SetActive(true);
            FieldsContainerObject.Grid[x, y].IsOccopied = true;
            FieldsContainerObject.Grid[x, y + 1].IsOccopied = true;
        }
        else
        {
            Debug.Log("Nasso No Space Here");
            return;
        }
        if (!ResetButton.activeInHierarchy)
        {
            ResetButton.SetActive(true);
        }

    }

    void GenerateTablesContainer()
    {
        _tableContainer = new GameObject("TableContainer");
    }

    public void ResetObjects()
    {

        for (int x = 0; x < FieldsContainerObject.TotalRowCount; x++)
        {
            for (int y = 0; y < FieldsContainerObject.TotalColumnCount; y++)
            {
                if(FieldsContainerObject.Grid[x, y].TileType == 3 && FieldsContainerObject.Grid[x, y].IsOccopied == true)
                   FieldsContainerObject.Grid[x, y].IsOccopied = false;
                
            }
        }
               
        Destroy(_tableContainer);
        ResetButton.SetActive(false);
        GenerateTablesContainer();
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
