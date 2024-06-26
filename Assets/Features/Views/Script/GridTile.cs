using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    public int TileType;
    public SpriteRenderer SpriteRendererReference;
    public bool IsOccopied;
    public static Action<int, int> RootTileData;

    private void OnMouseDown()
    {
        if (TileType == 3 && !IsOccopied)
        {
            int x = (int)transform.position.x;
            int y = (int)transform.position.y;

            RootTileData?.Invoke(x, y);
        }

    }

}
