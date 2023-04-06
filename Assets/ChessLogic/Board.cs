using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  
//using UnityEngine.XR.Interaction.Toolkit;


public class Board : MonoBehaviour
{
    private GameObject currecntlySelectedPiece;

    public Pieces[,] chessPieces;//array for all chess pieces/pieces objects

    int lengthOfBoard = 8; //int tileSize = 1;

    public GameObject boardTiles;

    GameObject[,] tilesArray = new GameObject[8, 8];

    private string PawnPro;

    private int wPlayerScore = 0;
    private int bPlayerScore = 0;
    private bool playerTurn;
    public Material[] tileMaterials;

    private bool currentMoveValid;

    public Material pieceSelectedMaterial;


    //for asset type, piece type and colours/materials
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Material[] teamMaterials;

    // Start is called before the first frame update
    void Start()
    {
        setStartLayout();
        playerTurn = true;
    }

    public void setStartLayout() 
    {
        BoardTilesCreated();
        SpawnAllPieces();
        positionAllPiece();
    }

   public void getPieces()
    {
        Debug.Log("items inPieces: " + chessPieces);
    }

    void BoardTilesCreated()
    {
        for (int i = 0; i < lengthOfBoard; i++)
        {
            for (int j = 0; j < lengthOfBoard; j++)
            {
                tilesArray[i, j] = Instantiate(boardTiles, new Vector3(i, (float)0.01, j), Quaternion.identity);

            }
        }
    }

    private void SpawnAllPieces(){
        chessPieces = new Pieces[lengthOfBoard, lengthOfBoard];

        int whiteTeam = 1, blackTeam = 0;


        //white team
        chessPieces[0, 0] = SpawnOnePiece(PieceType.Rook, whiteTeam);
        chessPieces[1, 0] = SpawnOnePiece(PieceType.Knight, whiteTeam);
        chessPieces[2, 0] = SpawnOnePiece(PieceType.Bishop, whiteTeam);
        //black square start
        chessPieces[3, 0] = SpawnOnePiece(PieceType.Queen, whiteTeam);
        chessPieces[4, 0] = SpawnOnePiece(PieceType.King, whiteTeam);
        chessPieces[5, 0] = SpawnOnePiece(PieceType.Bishop, whiteTeam);
        //white square start
        chessPieces[6, 0] = SpawnOnePiece(PieceType.Knight, whiteTeam);
        chessPieces[7, 0] = SpawnOnePiece(PieceType.Rook, whiteTeam);


        //white pawns
        for (int i = 0; i < lengthOfBoard; i++) {
            chessPieces[i, 1] = SpawnOnePiece(PieceType.Pawn, whiteTeam);
        }


        //black team
        chessPieces[0, 7] = SpawnOnePiece(PieceType.Rook, blackTeam);
        chessPieces[1, 7] = SpawnOnePiece(PieceType.Knight, blackTeam);
        chessPieces[2, 7] = SpawnOnePiece(PieceType.Bishop, blackTeam);
        //white square start
        chessPieces[3, 7] = SpawnOnePiece(PieceType.Queen, blackTeam);
        chessPieces[4, 7] = SpawnOnePiece(PieceType.King, blackTeam);
        chessPieces[5, 7] = SpawnOnePiece(PieceType.Bishop, blackTeam);
        //black square start
        chessPieces[6, 7] = SpawnOnePiece(PieceType.Knight, blackTeam);
        chessPieces[7, 7] = SpawnOnePiece(PieceType.Rook, blackTeam);


        for (int i = 0; i < lengthOfBoard; i++)
        {
            chessPieces[i, 6] = SpawnOnePiece(PieceType.Pawn, blackTeam);
        }
    }

    public Pieces SpawnOnePiece(PieceType ptype, int team) {
        Pieces p = Instantiate(prefabs[(int)ptype-1], transform).GetComponent<Pieces>();

        p.ptype = ptype;
        p.team = team;
        p.GetComponent<MeshRenderer>().material = teamMaterials[team];

        return p;
    }


    void positionAllPiece() {
        for (int i = 0; i < lengthOfBoard; i++) {
            for (int j=0; j < lengthOfBoard;  j++) {
                if (chessPieces[i, j] != null) {
                    positionSinglePiece(i, j, true);
                }
            }
        }
    }

    void positionSinglePiece(int i, int j, bool force = false)
    {
        chessPieces[i, j].currentXPos = i;
        chessPieces[i, j].currentZPos = j;
        if (chessPieces[i, j].team == 0) {
           chessPieces[i, j].transform.Rotate(0, 180, 0);
        } 
        chessPieces[i, j].transform.position = new Vector3(i, 0, j);
    }

    //set piece last selected
    public void setCurrentPiece(GameObject piece) 
    {
        //highlightSeletedPiece(piece);
        this.currecntlySelectedPiece = piece;
    }

    //get last piece selected
    public GameObject getCurrentPiece() {
        return this.currecntlySelectedPiece;
    }

    //used for changing turns
    public void setPlayerTurn(bool playerTurn) {
        this.playerTurn = playerTurn;
    }

    public bool getPlayerTurn() {
        return this.playerTurn;
    }

    public void updateChessArray(Vector3 position)
    {

        Pieces tempScript = getCurrentPiece().GetComponent<Pieces>();
        int oldZPos = tempScript.currentZPos;
        int oldXPos = tempScript.currentXPos;
        chessPieces[oldXPos, oldZPos] = null;//removing piece at old position

        tempScript.currentXPos = (int)position.x;
        tempScript.currentZPos = (int)position.z;//changing script pos

        chessPieces[(int)position.x, (int)position.z] = getCurrentPiece().GetComponent<Pieces>();//setting piece at new position
    }

    public Pieces[,] getChessArray() {
        return this.chessPieces;
    }

    public bool TileIsValid(Vector3 tilePos)
    {
        bool pieceAtPos = isPieceOnTile(tilePos);
        if (pieceAtPos)
        {
            //piece at position and oposite team
            //TakePieceRules();
            int teamPieceOnTile = chessPieces[(int)tilePos.x, (int)tilePos.z].team; //[this checks the team of the piece on the tile selected]
            Debug.Log(teamPieceOnTile + " compared to " + getCurrentPiece().GetComponent<Pieces>().team);
            if (teamPieceOnTile == getCurrentPiece().GetComponent<Pieces>().team)
            {
                Debug.Log("invalid move");
                return false;
            }

            //check for pawn due to taking differently than moving
            if (getCurrentPiece().GetComponent<Pieces>().ptype == PieceType.Pawn)
            {
                Pawn pawn = getCurrentPiece().GetComponent<Pawn>();
                pawn.pawnTakeRules(tilePos);
            }
            else 
            {
                getCurrentPiece().GetComponent<Pieces>().Rules(tilePos);
            }

            //remove piece if move is valid
            if (getCurrentMoveValid())
            {
                removePiece(chessPieces[(int)tilePos.x, (int)tilePos.z]);
            }

            //removePiece(tempPiece);
            return getCurrentMoveValid();

        }
        else
        {
            //piece not at position
            getCurrentPiece().GetComponent<Pieces>().Rules(tilePos);
            if (!getCurrentMoveValid())
            {
                return false;
            }
        }
        return true;
    }


    //removes gameobject from scene using script instance
    public void removePiece(Pieces tempPiece)
    {
       GameObject gO = tempPiece.gameObject;
        int t = tempPiece.team;


        //king taken ends game in win
        if(tempPiece.ptype == PieceType.King)
        {
            winSceneRedirect();// needs check for which player gets sent to which scene
        }

        //update player score
        if (t == 0)
        {
            bPlayerScore += tempPiece.pieceWorth;
            Debug.Log(bPlayerScore);
        }
        else 
        {
            wPlayerScore += tempPiece.pieceWorth;
            Debug.Log(wPlayerScore);
        }
        Destroy(gO);
    }

    public void highlightSeletedPiece(GameObject selected)
    {
        selected.GetComponent<MeshRenderer>().material = pieceSelectedMaterial;
    }

    //checks if pieces on tile
    public bool isPieceOnTile(Vector3 tilePos)
    {
        if (chessPieces[(int)tilePos.x, (int)tilePos.z] != null) {
            return true;
        }
        return false;
    }


    //keeps track if the move is considered valid
    public void setCurrentMoveValid(bool isMoveValid) 
    {
        this.currentMoveValid = isMoveValid;
    }

    public bool getCurrentMoveValid() 
    {
        return this.currentMoveValid;
    }


    //redirects to correct scene if player won or lost / drew the game
    public void winSceneRedirect() {  
        SceneManager.LoadScene("Win scene");  
    } 

    public void loseSceneRedirect() {  
        SceneManager.LoadScene("Lose scene");  
    }
    public void drawSceneRedirect() {  
        SceneManager.LoadScene("Draw scene");  
    }

    public void unHighlightAllPieces()
    {
        GameObject[] PieceObjects;
        PieceObjects = GameObject.FindGameObjectsWithTag("Piece");
        for(int i =0; i< PieceObjects.Length; i++)
        {
           unHighlightSinglePiece(PieceObjects[i]);
        }
    }
     public void unHighlightSinglePiece(GameObject gameObject)
     {
        Pieces p = gameObject.GetComponent<Pieces>();
 
        gameObject.GetComponent<MeshRenderer>().material = teamMaterials[p.team];
     }
     public void HighlightAllTiles(List<Vector3> availableMoves)
    {
        //foreach (var i in avaiableMoves) {
            
        //}
    }
     public void HighlightSingleTile(GameObject gameObject)
     {
        Pieces p = gameObject.GetComponent<Pieces>();
 
        gameObject.GetComponent<MeshRenderer>().material = tileMaterials[1];
     }
}
