//#using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class RulerManager : MonoBehaviour
{

    public enum RulerType
    {
        None, Train, Duck, SpaceShip, Robot
    }
    public RulerType rulerType = RulerType.None;
    public List<Text> rulerText = new List<Text>();
    public int correctLength;
    public List<GameObject> rulerContents = new List<GameObject>();
    public List<GameObject> rulerContents2 = new List<GameObject>();
    [SerializeField]
    public int randLength;
    public Text Text_Main;
    public List<GameObject> ShadowContent = new List<GameObject>();
    public List<Text> Answer_Text = new List<Text>();
    public Numpad numpad;
    public List<GameObject> BoardContent = new List<GameObject>();
    public int oldNum;
    public int ant;
    //public List<GameObject> ani_Board = new List<GameObject>();
    //public Animation ani_Board;
    public List<int> contentsLine = new List<int>();
    public List<Animator> BoardAni2 = new List<Animator>();
    public List<GameObject> Success = new List<GameObject>();
    public GameClearController gameClearController;
    [SerializeField]
    private int select = 0;



    // Start is called before the first frame update
    void Start()
    {
        RandomContentsOn();
        RandomLengthType();
    }

    void RandomContentsOn()
    {
        //������ �̱�
        randLength = Random.Range(0, rulerContents.Count);

        //����̱��� �迭 ������ �귯 �������� �������� ���� ��
        while(contentsLine.Count < rulerContents.Count)
        {
            //����̱� �迭���� randLength ���ڸ� �����ϰ� �ִٸ�
            if(contentsLine.Contains(randLength))
            {
                //������ �̱�
                randLength = Random.Range(0, rulerContents.Count);
            }
            //����̱� �迭���� randLength ���ڸ� �����ϰ� ���� �ʴٸ�
            else
            {
                //����̱� �迭�� randLegth���� �߰��Ѵ�.
                contentsLine.Add(randLength);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomLengthType()
    {
        randLength = Random.Range(0, rulerContents.Count);
        ShowContents();
    }

    void ShowContents()
    {
        rulerContents[select].SetActive(true);
        rulerContents2[select].SetActive(true);
        switch (select)
        {
            case 0:
                {
                    correctLength = 10;
                    rulerType = RulerType.Train;
                    break;
                }
            case 1:
                {
                    correctLength = 4;
                    rulerType = RulerType.Duck;
                    break;
                }
            case 2:
                {
                    correctLength = 5;
                    rulerType = RulerType.SpaceShip;
                    break;
                }
            case 3:
                {

                    correctLength = 3;
                    rulerType = RulerType.Robot;
                    break;
                }
        }
    }

    public void RulerTextInput(int r)
    {
        rulerText[select].text = r.ToString();
        
    }
    public void RulerResultInput(int r)
    {
        rulerText[select].text = r.ToString();
        switch (r)
        {
            case int _ when r == correctLength:
                if (select == 3)
                {
                    Debug.Log("����");
                    //StartCoroutine(FShadowContents());
                    BoardContent[0].SetActive(false);
                    //Success[0].SetActive(true);
                    SuccessGame();
                }
                else
                {
                    select++;
                    Debug.Log("����");
                    //rulerContents[0].SetActive(false);
                    //rulerContents2[0].SetActive(false);
                    oldNum = randLength;
                    Reset();
                    //Success[1].SetActive(true);
                    //StartCoroutine(SuccessTextOff());
                    SuccessGame();
                }
                break;
            default:
                Debug.Log("����");
                Answer_Text[select].text = "?";
                BoardAni2[select].SetInteger("BoardState", 1);
                StartCoroutine(BoardStateChange());
                break;
        }
    }

    IEnumerator SuccessTextOff()
    {
        yield return new WaitForSeconds(0.5f);
        Success[1].SetActive(false);
    }

    IEnumerator BoardStateChange()
    {
        yield return new WaitForSeconds(0.5f);
        BoardAni2[select].SetInteger("BoardState", 2);
    }


    private void Reset()
    {
       //������ ���ڿ� �ٽ� �������� �̾Ƴ� ���ڰ� ���� ���
        
        ShowContents();
        StartCoroutine(FShadowContents());
        Answer_Text[select].text = "?";
        BoardContent[select].SetActive(false);

    }

    public IEnumerator FShadowContents()
    {
        yield return new WaitForSeconds(1.0f);
        ShadowContent[select].SetActive(false);
    }

    void SuccessGame()
    {
        gameClearController.UpdateClearCount();
    }

    
}
