using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPiece : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
  {
         //Check for mouse click 
         if (Input.GetMouseButtonDown(0))
         {
             RaycastHit raycastHit;
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             if (Physics.Raycast(ray, out raycastHit, 100f))
             {
                 if (raycastHit.transform != null)
                 {
                    GameObject  gO =raycastHit.transform.gameObject;
                    Pieces p = gO.GetComponent<Pieces>();
                    CurrentClickedGameObject(gO);
                 }
             }



             //CurrentClickedGameObject(gameObject);

         }
  }
 
     public void CurrentClickedGameObject(GameObject gameObject)
     {

     //Debug.Log(gameObject.name);
            Pieces p = gameObject.GetComponent<Pieces>();
            GameObject board = GameObject.FindWithTag("BoardLayout");

            Board boardScript = board.GetComponent<Board>();

            if (gameObject.tag == "Piece")
            {
                //checks for player turns
                if(boardScript.getPlayerTurn() && p.team == 1) 
                {
                    boardScript.setCurrentPiece(gameObject);

                    //piece highlighting
                    boardScript.unHighlightAllPieces();
                    boardScript.highlightSeletedPiece(gameObject);
                }
                else if(!boardScript.getPlayerTurn() && p.team == 0)
                {
                    boardScript.setCurrentPiece(gameObject);

                    //piece highlighting
                    boardScript.unHighlightAllPieces();
                    boardScript.highlightSeletedPiece(gameObject);
                }
                else
                {
                    Debug.Log("Other Players turn");
                }
               //  Debug.Log("hello piece");

                
            }
            else if (gameObject.tag == "Tile")
            {
                //Debug.Log("Hello tile");

                if (boardScript.getCurrentPiece() != null)
                {
                    movePieceToTile(gameObject, boardScript);
                }
                else
                {
                    //Debug.Log("error, No piece selected");//display this out to user
                }
            }
            
     }

     public void movePieceToTile(GameObject gameObject, Board boardSript)
     {
    // Debug.Log("hello");
        boardSript.setCurrentMoveValid(false);
        Vector3 xPos = gameObject.GetComponent<Transform>().position;

        bool validMove = boardSript.TileIsValid(xPos);
         // Debug.Log("Is tile valid: " + validMove);
        if (validMove)
        {
            //Debug.Log("valid move...if");
            Pieces[,] p = boardSript.getChessArray();

                boardSript.getCurrentPiece().transform.position = xPos;
                boardSript.updateChessArray(xPos);
               // boardSript.setCurrentPiece(null);

                //Debug.Log("Before move: " + boardSript.getPlayerTurn());

                //after valid move change player turn
                if(boardSript.getPlayerTurn()) 
                {
                    boardSript.setPlayerTurn(false);
                    //boardSript.unHighlightSinglePiece(boardSript.getCurrentPiece());
                }
                else 
                {
                    boardSript.setPlayerTurn(true);
                }
                //Debug.Log("After move: " + boardSript.getPlayerTurn());
                boardSript.unHighlightSinglePiece(boardSript.getCurrentPiece());
        }

        else
        {
            Debug.Log("Not valid move");
            boardSript.setCurrentPiece(null);
        }
    }
}
