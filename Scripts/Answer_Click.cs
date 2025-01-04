using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Answer_Click : MonoBehaviour
{
    public GameObject Board;
    public Button BtnBoard;
    public List<GameObject> ShadowContent = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        ShadowContent[0].SetActive(false);
        Board.SetActive(false);
        BtnBoard.onClick.AddListener(ShowBoard);
        //showBoard 를 클릭했을떄.
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }
    }*/
    void ShowBoard()
    {
        Board.SetActive(true);
        ShadowContents();
    }
    void ShadowContents()
    {
        ShadowContent[0].SetActive(true);
    }
}
