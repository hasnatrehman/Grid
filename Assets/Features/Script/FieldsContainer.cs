using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "FieldsContainer", menuName = "Inventory/Data")]
public class FieldsContainer : ScriptableObject
{
    public int TotalRowCount, TotalColumnCount;
    
    public Sprite[] GridTiles;

    public GridTile[,] Grid;
}
