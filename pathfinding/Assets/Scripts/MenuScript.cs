using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuScript 
{
    [MenuItem("Tools/Assign Tile Material")]
    public static void AssignTileMaterial()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        Material mat = Resources.Load<Material>("Material/Tile");

        foreach (var item in tiles)
        {
            item.GetComponent<Renderer>().material = mat;
        }
    }

    [MenuItem("Tools/Assign Tile Script")]
    public static void AssignTileScript()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");

        foreach (var item in tiles)
        {
            item.AddComponent<Tile>();
        }
    }

}
