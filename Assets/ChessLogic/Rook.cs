using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Pieces
{
    // Start is called before the first frame update
    void Start()
    {
        pieceWorth = 5;
    }

   /* public void rookRules(Vector3 tilePos, Board boardScript)
    {
        Debug.Log("Rook Rules");

        //[x, z++] , [x, z--] , [x++, z] , [x--, z]

        //check all tiles from piece to tile location
        int tileX = (int)tilePos.x; int tileZ = (int)tilePos.z;
        Rook rookScipt = boardScript.getCurrentPiece().GetComponent<Rook>();

        int x = (rookScipt.currentXPos);
        int z = (rookScipt.currentZPos);
        bool forwardOrBack, blocked;

        boardScript.setCurrentMoveValid(true);

        //right
        if (tileX > x && tileZ == z)
        {
            forwardOrBack = false;
            for (int i = x; i < tileX; i++)
            {
                blocked = isMoveBlocked(boardScript, i, x, z, forwardOrBack);
                if (blocked)
                {
                    boardScript.setCurrentMoveValid(false);
                }
            }
        }

        //forward
        else if (tileZ > z && tileX == x)
        {
            forwardOrBack = true;
            for (int i = z; i < tileZ; i++)
            {
                blocked = isMoveBlocked(boardScript, i, x, z, forwardOrBack);
                if (blocked)
                {
                    boardScript.setCurrentMoveValid(false);
                }
            }
        }

        //backwards
        else if (tileZ < z && tileX == x)
        {
            forwardOrBack = true;
            for (int i = z; i < tileZ; i--)
            {
                blocked = isMoveBlocked(boardScript, i, x, z, forwardOrBack);
                if (blocked)
                {
                    boardScript.setCurrentMoveValid(false);
                }
            }
        }

        //left
        else if (tileX < x && tileZ == z)
        {
            forwardOrBack = false;
            for (int i = x; i < tileX; i--)
            {
                blocked = isMoveBlocked(boardScript, i, x, z, forwardOrBack);
                if (blocked) 
                {
                    boardScript.setCurrentMoveValid(false);
                }
            }
        }

        else 
        {
            boardScript.setCurrentMoveValid(false);
        }
    }

    public bool isMoveBlocked(Board boardScript, int i, int x, int z, bool forwardOrBack) 
    {
        int tempX =0, tempZ=0;

        if (!forwardOrBack)
        {
            tempX = i;
            tempZ = z;
        }
        else if (forwardOrBack) 
        {
            tempZ = i;
            tempX = x;
        }

        //check if piece in the way
        Vector3 temp = new Vector3((float)tempX, 0.0f, (float)tempZ);
        Debug.Log(temp); bool pieceAtPos = false;

        pieceAtPos = boardScript.isPieceOnTile(temp);
        Debug.Log(pieceAtPos);

        if (!pieceAtPos)
        {
            boardScript.setCurrentMoveValid(true);
            //check colour
            Pieces[,] chessArray = boardScript.getChessArray();
            Pieces p = chessArray[x, i];
            if (p.team == rookScipt.team) 
            {
                boardScript.setCurrentMoveValid(false);
                //Debug.Log("this here");
        /*    }
        }

        return false;
    }*/


  /*  public void rookRules(Vector3 tilePos, Board boardScript)
    {
    Debug.Log("Rook Rules");

        //[x, z++] , [x, z--] , [x++, z] , [x--, z]

        //check all tiles from piece to tile location
        int tileX = (int)tilePos.x; int tileZ = (int)tilePos.z;
        Rook rookScipt = boardScript.getCurrentPiece().GetComponent<Rook>();

        int x = (rookScipt.currentXPos);
        int z = (rookScipt.currentZPos);
        bool forwardOrBack, blocked;

        boardScript.setCurrentMoveValid(true);

        if(tileZ == z)
        {
            
        }
        else if(tileX == x)
        {
            
        }
        else
        {
            boardScript.setCurrentMoveValid(false);
        }
    }*/



    /* public void rookRules(Vector3 tilePos, Board boardScript)
    {
    //check all tiles from piece to tile location
        int tileX = (int)tilePos.x; int tileZ = (int)tilePos.z;
        Rook rookScipt = boardScript.getCurrentPiece().GetComponent<Rook>();

        boardScript.setCurrentMoveValid(false);

        int x = (rookScipt.currentXPos);
        int z = (rookScipt.currentZPos);

        int start =0, end =0; 

        if(tileX == x && tileZ != z)
        {
            start = z, end = tileZ;
            if(tileZ > z)//fowards
            {
                addingCheckIsValid(start, end);
            }
            else//moving backwards
            {
                minusCheckValid(start, end);
            }
        }
        else if(tileZ == z && tileX != x)//side to side
        {
            start = x, end = tileX;
            if(tileX > x)//moving right
            {
                addingCheckIsValid(start, end);
            }
            else//moving left
            {
                minusCheckValid(start, end);
            }
        }
    }

    public bool addingCheckIsValid(int start, int end, Board boardScript)
    {
        Vector3 temp;

        for(int i = start; i <= end; i++){
            temp = ();
            if(boardScript.isPieceOnTile())
            {
                
            }
        }
        return true;
    }

    public bool minusCheckValid(int start, int end, Board boardScript)
    {
        Vector3 temp;    

        for(int i = start; i <= end; i--){
            if()
            {
                
            }    

        }
        return true;
    }*/

    public void rookRules(Vector3 tilePos, Board boardScript)
    {
        int tileX = (int)tilePos.x; int tileZ = (int)tilePos.z;
        Rook r = boardScript.getCurrentPiece().GetComponent<Rook>();

        int x = (r.currentXPos);
        int z = (r.currentZPos);

        Vector3 temp = new Vector3();
        List<Vector3> positions = new List<Vector3>();

        //piece location to tile location
        /*for()
        {
        
        }*/

        //right
        if (tileX > x && tileZ == z)
        {
            
        }

        //left
        else if (tileX < x && tileZ == z)
        {
            int i = x;
           //temp = (Vector3)(i, 0, z);
            //while(!boardScript.isPieceOnTile(temp) && x >= 0) 
            {
             //   positions.Add(temp);
             //   i++;
             //   Debug.Log(temp);
            }
        }

        //forward
        else if (tileZ > z && tileX == x)
        {
            int i = z;
            //temp = (x, 0, i);
            
        }

        //backwards
        else if (tileZ < z && tileX == x)
        {
           
        }

        else 
        {
            boardScript.setCurrentMoveValid(false);
        }
        
    }
}
