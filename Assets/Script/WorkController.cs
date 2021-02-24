using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkController : MonoBehaviour
{
    public GameObject workBtn;
    public GameObject leftBtn;
    public GameObject rightBtn;
    public GameObject popup;
    public Text workText;
    public MainMoneySystem gameSystem;
    public int qCnt = 0;
    private WorkPopupManager workPopupManager;
    void Start()
    {
        workPopupManager = popup.GetComponent<WorkPopupManager>();
        gameSystem = GameObject.FindWithTag("GameController").GetComponent<MainMoneySystem>();
        workText = workBtn.transform.GetChild(0).GetComponent<Text>();
    }

    void Update()
    {
        if(gameSystem.Works.Count < 2)
        {
            leftBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/testMAn");
            rightBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/testMAn");
            leftBtn.GetComponent<Button>().enabled = false;
            rightBtn.GetComponent<Button>().enabled = false;
        }
        else
        {
            leftBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/sign");
            rightBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/sign");
            leftBtn.GetComponent<Button>().enabled = true;
            rightBtn.GetComponent<Button>().enabled = true;
        }
        if(gameSystem.Works.Count != 0)
        {
            workBtn.GetComponent<Button>().enabled = true;
            workText.text = gameSystem.Works[qCnt].name;
        }
        else {         
            workBtn.GetComponent<Button>().enabled = false;
            workText.text = "계약한 업무가 없습니다.";
        }
    }
    public void ClickLeft()
    {
        if(qCnt == 0)
        {
            qCnt = gameSystem.Works.Count - 1;
        }
        else
        {
            qCnt -= 1;
        }
    }
    public void ClickRight()
    {
        if (qCnt == gameSystem.Works.Count - 1)
        {
            qCnt = 0;
        }
        else
        {
            qCnt += 1;
        }
    }
    public void ClickWork()
    {
        workPopupManager.title.text = gameSystem.Works[qCnt].name;
        workPopupManager.downPay.text = gameSystem.Works[qCnt].downPay.ToString();
        workPopupManager.pay.text = gameSystem.Works[qCnt].pay.ToString();
        workPopupManager.stars.level = gameSystem.Works[qCnt].star;
        workPopupManager.stars.StarUpdate();
        popup.GetComponent<Canvas>().enabled = true;
    }
}
