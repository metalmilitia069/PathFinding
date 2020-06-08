using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : TacticsMove
{

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward);

        if (!turn)
        {
            return;
        }

        //if (!isSelectedTilesFound)
        //{
        //    FindSelectableTiles();
        //}

        if (!moving)
        {
            FindNearestTarget();
            CalculatePath();
            FindSelectableTiles();
        }
        else
        {
            Move();
        }
    }

    private void FindNearestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");

        GameObject nearest = null;
        float distance = float.MaxValue;

        foreach (var obj in targets)
        {
            float d = Vector3.Distance(transform.position, obj.transform.position); //Look at this method as solution later >>> Vector3.SqrMagnitude
            
            if (d < distance)
            {
                distance = d;
                nearest = obj;
            }
        }

        target = nearest;
    }

    private void CalculatePath()
    {
        Tile targetTile = GetTargetTile(target);
        FindPathAI(targetTile);
    }
}
