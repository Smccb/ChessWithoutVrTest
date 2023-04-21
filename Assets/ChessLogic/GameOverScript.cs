using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text txt;
    // Start is called before the first frame update
    public void GameOverMessage(string message) 
    {
        //Debug.Log(message+" hello");
        txt.GetComponent<TMPro.TextMeshProUGUI>().text = message;

    }

    public void ChangeTextToNothing() 
    {
        txt.GetComponent<TMPro.TextMeshProUGUI>().text = "  ";
    }
}
