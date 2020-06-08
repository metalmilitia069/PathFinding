﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool walkable = true;
    public bool current = false;
    public bool target = false;
    public bool selectable = false;

    public List<Tile> adjacencyList = new List<Tile>();

    //Needed for BFS ALgorithm (Breadth First Search)

    public bool visited = false;
    public Tile parent = null;
    public int distance = 0; //says how far each tile is from the start file


    //Needed for A*
    public float f = 0;
    public float g = 0;
    public float h = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (current)
        {
            GetComponent<Renderer>().material.color = Color.magenta;
        }
        else if (target)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else if (selectable)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }

    }

    public void ResetTile()
    {        
        current = false;
        target = false;
        selectable = false;

        adjacencyList.Clear();        

        visited = false;
        parent = null;
        distance = 0;



        f = g = h = 0;
    }

    public void FindNeighbors(float jumpHeight, Tile target)
    {
        ResetTile();

        CheckTile(Vector3.forward, jumpHeight, target);
        CheckTile(-Vector3.forward, jumpHeight, target);
        CheckTile(Vector3.right, jumpHeight, target);
        CheckTile(-Vector3.right, jumpHeight, target);
    }

    public void CheckTile(Vector3 direction, float jumHeight, Tile target)
    {
        Vector3 halfExtends = new Vector3(0.25f, (1 + jumHeight) / 2.0f, 0.25f); // ?????????????????????
        Collider[] colliders = Physics.OverlapBox(transform.position + direction, halfExtends);// ????????????????????????

        foreach (var col in colliders)
        {
            Tile tile = col.GetComponent<Tile>();
            if (tile != null && tile.walkable)
            {
                RaycastHit hit;
                if (!Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1) || (tile == target))
                {
                    adjacencyList.Add(tile);
                }
            }
        }
    }
    
}




