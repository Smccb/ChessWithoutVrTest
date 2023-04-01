using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPromotion : MonoBehaviour
{
//in real (VR version) implement this class like the piece movement one
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
             RaycastHit raycastHit;
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             if (Physics.Raycast(ray, out raycastHit, 100f))
             {
                 if (raycastHit.transform != null)
                 {
                    GameObject  gO =raycastHit.transform.gameObject;

                    if (gameObject.tag == "PawnPro") {
                        Debug.Log(gameObject.name);
                        pawnPromotionUpdatepiece(gO);
                    }
                 }
             }
        }
    }

    public void pawnPromotionUpdatepiece(GameObject gameObject)
    {
        //.removePawnPromotionPieces();
        //take in the selected type they want to upgrade to
        //Debug.Log(gameObject.name);
        //call singleSpawn function and the positioning method to place a piece onto the board at that position
    }
}
