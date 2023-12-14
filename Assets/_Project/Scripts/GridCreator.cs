using UnityEngine;
using System.Collections.Generic;

public class GridCreator : MonoBehaviour
{
    [SerializeField] 
    private SpriteRenderer _cellPrefab;
    [SerializeField]
    private Color _freeColorFirst;
    [SerializeField]
    private Color _freeColorSecond;
    [SerializeField]
    private Color _blockedColor;
    [SerializeField] 
    private float _cellSize = 1f;
    [SerializeField]
    private int _width;
    [SerializeField]
    private int _height;

    public void ClearAndCreateGrid()
    {
        ClearGrid();
        CreateGrid();
    }
    
    public void CreateGrid()
    {
        Vector2 offset = new Vector2(_width-1, _height-1) / 2;
        for(int x = 0; x < _width; x++)
        {
            for(int y = 0; y <_height; y++)
            {
                Vector2 position = (new Vector2(x,y) - offset) * _cellSize;
                bool isLight = (x + y) % 2 == 0;
                CreateGridCell(position, isLight);
                
            }
        }
    }

    private void CreateGridCell(Vector2 position, bool isLight)
    {
        SpriteRenderer newCell = Instantiate(_cellPrefab, transform);
        newCell.transform.position = position;
        
        Color color;
        if (Random.Range(0, 4) == 0)
        {
            color = _blockedColor;
        }
        else
        {
            if (isLight)
            {
                color = _freeColorFirst;
            }
            else
            {
                color = _freeColorSecond;
            }
        }

        newCell.color = color;
    }

    private void ClearGrid()
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }
}
