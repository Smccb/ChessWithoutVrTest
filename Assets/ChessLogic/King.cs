using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Pieces
{ 

    bool movedFromStartPos;
    // Start is called before the first frame update
    void Start()
    {
        pieceWorth = 0;
        movedFromStartPos = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void kingRules(Vector3 tilePos, Board boardScript) {
        Debug.Log("King Rules");

        King k = boardScript.getCurrentPiece().GetComponent<King>();

        int x = (k.currentXPos);
        int z = (k.currentZPos);


        //pairs of positions x and z value

        //ArrayList<ArrayList<Integer>> positions;
        int[,] positions
       //List<List<Integer>> matrix= new List<List<String>>();

        if(z != 7)
        {
            positions[x, z+1];
            if(x != 7) {
                positions[]positions.Add(x+1, z+1);
            }
            if(x != 0) 
            {
                positions.Add(x-1, z+1);
            }
        }
        if(z != 0)
        {
            positions.Add(x, z-1);
            if(x != 7) {
                positions.Add(x+1, z-1);
            }
            if(x != 0) 
            {
                positions.Add(x-1, z-1);
            }
        }
        if(x != 7) {
            positions.Add(x+1, z);
        }
        if(x != 0) 
        {
            positions.Add(x-1, z);
        }

        //check all moves
        for (int i = 0; i < 8; i++)
        {
            if (tilePos.x == positions.GetItem(i, 0) && tilePos.z == positions.GetItem(i, 1))
            {
                boardScript.setCurrentMoveValid(true);
            }
        }
    }*/

    /*public void kingRules(Vector3 tilePos, Board boardScript) {
        Debug.Log("King Rules");

        King kingScipt = boardScript.getCurrentPiece().GetComponent<King>();

        int x = (kingScipt.currentXPos);
        int z = (kingScipt.currentZPos);


        //pairs of positions x and z value
        int[,] positions = {
            { (x), (z+1)},
            { (x), (z-1)},
            { (x+1), (z+1)},
            { (x+1), (z)},
            { (x+1), (z-1)},
            { (x-1), (z+1)},
            { (x-1), (z)},
            { (x-1), (z-1)}
        };

        //check all moves
        for (int i = 0; i < 8; i++)
        {
            if (tilePos.x == positions[i, 0] && tilePos.z == positions[i, 1])
            {
                boardScript.setCurrentMoveValid(true);
            }
        }
    }*/

    public void kingRules(Vector3 tilePos, Board boardScript) 
    {
        King kingScipt = boardScript.getCurrentPiece().GetComponent<King>();

        float x = (float)(kingScipt.currentXPos);
        float z = (float)(kingScipt.currentZPos);


        // create an ArrayList
        //int[,] avaiableMoves = new int[8,8];

        List<Vector3>  avaiableMoves = new List<Vector3>();

        if(z != 7)
        {
            avaiableMoves.Add(new Vector3(x,0f,z+1));
            if(x != 7) {
                
                avaiableMoves.Add(new Vector3(x+1,0f,z+1));
            }
            if(x != 0) 
            {;
                 avaiableMoves.Add(new Vector3(x-1,0f,z+1));
            }
        }
        if(z != 0)
        {
             avaiableMoves.Add(new Vector3(x,0f,z-1));
            if(x != 7) {
                 avaiableMoves.Add(new Vector3(x+1,0f,z-11));
            }
            if(x != 0) 
            {
                 avaiableMoves.Add(new Vector3(x-1,0f,z-1));
            }
        }
        if(x != 7) {
            avaiableMoves.Add(new Vector3(x+1,0f,z));
        }
        if(x != 0) 
        {
            avaiableMoves.Add(new Vector3(x-1,0f,z));
        }
        boardScript.setCurrentMoveValid(true);
    }
}
