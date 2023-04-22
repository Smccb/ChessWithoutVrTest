using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Pieces
{
    private bool movedFromStartPos;
    //[SerializeField] private GameObject[] pawnProOptions;
    public bool currentlyBlocking;
    private Pieces promotionSC;

    // Start is called before the first frame update
    void Start()
    {
        movedFromStartPos = false;
        pieceWorth = 1;
        currentlyBlocking = true;
    }

    public void SetMovedFromStartPos(bool movedFromStartPos) 
    {
        this.movedFromStartPos = movedFromStartPos;
    }
    public bool GetMovedFromStartPos()
    {
        return this.movedFromStartPos;
    }

    public List<Vector3> pawnMoveRules(Board boardScript, GameObject gO, int counter)
    {
        Pieces pieceScript = gO.GetComponent<Pieces>();
        //int forward = (pieceScript.currentZPos + 1), forward2 = (pieceScript.currentZPos + 2);

        //white pieces moves are 1, black pieces moves are 0. [1, 0] single move forward white..
        //int[,] positions = { { (pieceScript.currentZPos - 1), (pieceScript.currentZPos - 2) }, { (pieceScript.currentZPos + 1), (pieceScript.currentZPos + 2) } };
        List<Vector3> avaiableMoves = new List<Vector3>();
        //if piece at position
        Vector3 temp; bool doesPosCauseCheck;
        //bool check = false;
        //King details
        //Pieces wKScript = null; Pieces bKScript = null;
        //Vector3 wKPos; Vector3 bKPos;

        if (pieceScript.team == 1 && pieceScript.currentZPos < 7 || pieceScript.team == 0 && pieceScript.currentZPos > 0)
        {
            
        //white piece team
            if (pieceScript.team == 1)
            {
                Pieces wKScript = boardScript.GetWKingScript();
                Vector3 wKPos = new Vector3((float)wKScript.currentXPos,0f, (float)wKScript.currentZPos);
                //Debug.Log(pieceScript.currentZPos + 1);
                temp = new Vector3((float)pieceScript.currentXPos, 0f, (float)pieceScript.currentZPos + 1);
                bool isPieceOnPos = boardScript.isPieceOnTile(temp);
                //doesPosCauseCheck = boardScript.IsMoveACheckPos(wKPos, boardScript, wKScript, 0);
                if (!isPieceOnPos && counter < 1 )//&& !doesPosCauseCheck)
                {
                    avaiableMoves.Add(temp);

                    currentlyBlocking = false;
                }
                    

                int zPos = pieceScript.currentZPos + 1;
                
                if (pieceScript.currentXPos < 7) 
                {
                    
                    isPieceOnPos = TakeChecksAdding(avaiableMoves, pieceScript, zPos, boardScript);
                    //doesPosCauseCheck = boardScript.IsMoveACheckPos(wKPos, boardScript, wKScript, 0);
                    if (isPieceOnPos)// && !doesPosCauseCheck) 
                    {
                        temp = new Vector3((float)pieceScript.currentXPos + 1, 0f, (float)zPos);
                        avaiableMoves.Add(temp);

                        //if (temp.z == 7)
                        //pawnProcalled
                        //PawnPromotion(boardScript, pieceScript);
                    }
                }
                if (pieceScript.currentXPos > 0)
                {
                   isPieceOnPos = TakeChecksMinus(avaiableMoves, pieceScript, zPos, boardScript);
                   // doesPosCauseCheck = boardScript.IsMoveACheckPos(wKPos, boardScript, wKScript, 0);
                   if (isPieceOnPos )//&& !doesPosCauseCheck)
                   {
                        temp = new Vector3((float)pieceScript.currentXPos - 1, 0f, (float)zPos);
                        avaiableMoves.Add(temp);
                   }
                }
            }

            //black piece team
            else if(pieceScript.team == 0)
            {
                //king details
                Pieces bKScript = boardScript.GetBKingScript();
                Vector3 bKPos = new Vector3((float)bKScript.currentXPos,0f, (float)bKScript.currentZPos);    

                temp = new Vector3((float)pieceScript.currentXPos, 0f, (float)pieceScript.currentZPos - 1);
                bool isPieceOnPos = boardScript.isPieceOnTile(temp);
                //doesPosCauseCheck = boardScript.IsMoveACheckPos(bKPos, boardScript, bKScript, 0);
                if (!isPieceOnPos)// && !doesPosCauseCheck)
                {
                    avaiableMoves.Add(temp);
                    currentlyBlocking = false;
                }

                int zPos = pieceScript.currentZPos - 1;

                if (pieceScript.currentXPos < 7)
                {
                    //doesPosCauseCheck = boardScript.IsMoveACheckPos(bKPos, boardScript, bKScript, 0);
                    isPieceOnPos = TakeChecksAdding(avaiableMoves, pieceScript, zPos, boardScript);
                    if (isPieceOnPos || counter == 1)// && !doesPosCauseCheck)
                    {
                        temp = new Vector3((float)pieceScript.currentXPos + 1, 0f, (float)zPos);
                        avaiableMoves.Add(temp);

                        /*if(counter < 1)
                        {
                            if (temp.z == 0)
                            //pawnProcalled
                            PawnPromotion(boardScript, pieceScript);
                        }*/
                    }
                }
                if (pieceScript.currentXPos > 0)
                {
                    isPieceOnPos = TakeChecksMinus(avaiableMoves, pieceScript, zPos, boardScript);
                    //doesPosCauseCheck = boardScript.IsMoveACheckPos(bKPos, boardScript, bKScript, 0);
                    if (isPieceOnPos || counter == 1)// && !doesPosCauseCheck)
                    {
                        temp = new Vector3((float)pieceScript.currentXPos - 1, 0f, (float)zPos);
                        avaiableMoves.Add(temp);

                        /*if(counter < 1)
                        {
                            if (temp.z == 0)
                            //pawnProcalled
                            PawnPromotion(boardScript, pieceScript);
                        }*/
                    }
                }
            }

            if (!GetMovedFromStartPos() && !currentlyBlocking && counter < 1)
            {
                if (pieceScript.team == 0 && pieceScript.currentZPos > 1 || pieceScript.team == 1 && pieceScript.currentZPos < 6)
                {
                    if (pieceScript.team == 1)
                    {
                       //Pieces wKScript = boardScript.GetBKingScript();
                       //Vector3 wKPos = new Vector3((float)wKScript.currentXPos,0f, (float)wKScript.currentZPos);
                       temp = new Vector3((float)pieceScript.currentXPos, 0f, (float)pieceScript.currentZPos + 2);
                       bool isPieceOnPos = boardScript.isPieceOnTile(temp);
                       //doesPosCauseCheck = boardScript.IsMoveACheckPos(wKPos, boardScript, wKScript, 0);
                       if (!isPieceOnPos)// && !doesPosCauseCheck)
                       {
                            avaiableMoves.Add(temp);
                        }
                    }
                    else
                    {
                        //Pieces bKScript = boardScript.GetBKingScript();
                        //Vector3 bKPos = new Vector3((float)bKScript.currentXPos,0f, (float)bKScript.currentZPos);
                        temp = new Vector3((float)pieceScript.currentXPos, 0f, (float)pieceScript.currentZPos - 2);
                        bool isPieceOnPos = boardScript.isPieceOnTile(temp);
                        //doesPosCauseCheck = boardScript.IsMoveACheckPos(bKPos, boardScript, bKScript, 0);
                        if (!isPieceOnPos)// && !doesPosCauseCheck)
                        {
                            avaiableMoves.Add(temp);
                        }
                    }
                }
            }
        }
        counter = 0;
        //boardScript.SetMovesAvailable(avaiableMoves);
        return avaiableMoves;
    }
    public bool TakeChecksMinus(List<Vector3> movesList, Pieces pieceScript, int zPos, Board boardScript) 
    {
        Vector3 temp;
        temp = new Vector3((float)pieceScript.currentXPos - 1, 0f, (float)zPos);
        bool tileAtPos = boardScript.isPieceOnTile(temp);
        Pieces pieceOnTile =boardScript.getChessArray()[(int)currentXPos - 1, zPos];

        if (tileAtPos && pieceScript.team != pieceOnTile.team)
        {
            //movesList.Add(temp);
            return true;
        }
        //return movesList;
        return false;
    }
    public bool TakeChecksAdding(List<Vector3> movesList, Pieces pieceScript, int zPos, Board boardScript)
    {
        Vector3 temp;
        temp = new Vector3((float)pieceScript.currentXPos+1, 0f, (float)zPos);
        bool tileAtPos = boardScript.isPieceOnTile(temp);
        Pieces pieceOnTile = boardScript.getChessArray()[(int)currentXPos + 1, zPos];

        if (tileAtPos && pieceScript.team != pieceOnTile.team)
        {
            //movesList.Add(temp);
            return true;
        }
        //return movesList;
        return false;
    }

    //handels pawn promotion after piece reached other side
    public void PawnPromotion(Board boardScript, Pieces pieceCS, Vector3 pos)
    {
        Debug.Log("Pawn promotion");
        //boardScript.getChessArray();
        int x = (int)pos.x; int z = (int)pos.z;
        GameObject game = pieceCS.gameObject;
        //remove
        boardScript.removePiece(pieceCS);
        //SpawnOnePiece
        Pieces temp;

        Vector3 positionOfPawn = new Vector3((float)pos.x,0f, (float)pos.z);
        //Pieces piece = Instantiate(prefabs[(int)ptype-1], gameObject.transform).GetComponent<Pieces>();
        if(pieceCS.team == 1)
        {
            temp = boardScript.spawnPawnPromotion(PieceType.Queen, 1,positionOfPawn);
        }
        else
        {
            temp = boardScript.spawnPawnPromotion(PieceType.Queen, 0, positionOfPawn);
        }
        //Pieces[,] p = boardScript.getChessArray();

        promotionSC = temp;
        boardScript.updateChessArray(positionOfPawn, 1);
    }

    public Pieces GetPromotion() 
    {
        return this.promotionSC;
    }
}
