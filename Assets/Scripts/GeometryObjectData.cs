using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GeometryObjectData", menuName = "Geometry Data", order = 51)]
public class GeometryObjectData : ScriptableObject
{
    public List<ClickColorData> ClicksData;
}

[Serializable]
public class ClickColorData
{
    public string ObjectType;
    public int MinClickCount;
    public int MaxClickCount;
    public Color Color;
}
