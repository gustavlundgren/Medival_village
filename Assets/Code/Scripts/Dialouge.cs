using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialouge
{
    public string name;
    [TextArea(3, 1)]
    public string[] sentences;
    public Sprite sprite;
}
