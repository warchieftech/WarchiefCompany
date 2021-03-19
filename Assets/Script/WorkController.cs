using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkController : MonoBehaviour
{
    public GameObject WorkTab;
    public GameObject workBtn;
    public GameObject leftBtn;
    public GameObject rightBtn;
    public GameObject popup;
    public GameObject newPopup;
    public Text workText;
    public MainMoneySystem gameSystem;
    public int qCnt = 0;
    private WorkPopupManager workPopupManager;
    private WorkPopupManager newWorkPopupManager;
    private WorkManager workManager;
    void Start()
    {
        workPopupManager = popup.GetComponent<WorkPopupManager>();
        newWorkPopupManager = newPopup.GetComponent<WorkPopupManager>();
        gameSystem = GameObject.FindWithTag("GameController").GetComponent<MainMoneySystem>();
        workManager = GameObject.FindWithTag("EventManager").GetComponent<WorkManager>();
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
    public void ClickNewWork(int cCnt)
    {
        gameSystem.getWorkCnt = cCnt;
        WorkTab.transform.GetChild(cCnt).GetComponent<Button>().enabled = false;
        WorkTab.transform.GetChild(cCnt).GetChild(2).gameObject.SetActive(true);
        newWorkPopupManager.title.text = workManager.work[cCnt].name;
        newWorkPopupManager.downPay.text = workManager.work[cCnt].downPay.ToString();
        newWorkPopupManager.pay.text = workManager.work[cCnt].pay.ToString();
        newWorkPopupManager.workGage.text = workManager.work[cCnt].workPoint.ToString();
        newWorkPopupManager.stars.level = workManager.work[cCnt].star;
        newWorkPopupManager.stars.StarUpdate();
        newPopup.GetComponent<Canvas>().enabled = true;
    }
}
