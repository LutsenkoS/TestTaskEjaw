using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeometryObjectModel : MonoBehaviour
{
    public int ClickCount;

    private GeometryObjectData _geometryObjectData;
    private Color _objectColor;
    private Renderer _objRenderer;
    private int _index;
    void Start()
    {
        _objRenderer = GetComponent<Renderer>();
        _geometryObjectData = Resources.Load<GeometryObjectData>(gameObject.name.Substring(0, gameObject.name.IndexOf('(')) + "Data");
    }

    public void Clicked()
    {
        ClickCount++;
        ClickColorData clickData = new ClickColorData();

        clickData = _geometryObjectData.ClicksData.Find(t => t.MinClickCount <= ClickCount && t.MaxClickCount >= ClickCount);
        if (clickData != null)
        {
            _objRenderer.material.color = clickData.Color;
        }

    }

    public void SetColor()
    {
        _objRenderer.material.color = 
            new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}
