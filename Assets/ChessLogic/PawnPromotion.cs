using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPromotion : MonoBehaviour
{
//in real (VR version) implement this class like the piece movement one
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
         {
             RaycastHit raycastHit;
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             if (Physics.Raycast(ray, out raycastHit, 100f))
             {
                 if (raycastHit.transform != null)
                 {
                    GameObject  gO =raycastHit.transform.gameObject;

                    GameObject board = GameObject.FindWithTag("BoardLayout");

                    Board boardScript = board.GetComponent<Board>();

                    boardScript.pawnPromotionUpdatepiece(gO);
                 }
             }
         }
    }
}
