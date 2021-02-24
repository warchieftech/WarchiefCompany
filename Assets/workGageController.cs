using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class workGageController : MonoBehaviour
{
    public Text workGage;
    public Image workBar;

    public MainMoneySystem mainSystem;
    public Work work;
    public WorkController workController;

    private void Start()
    {
        mainSystem = GameObject.FindWithTag("GameController").GetComponent<MainMoneySystem>();
        workController = GameObject.FindWithTag("WorkController").GetComponent<WorkController>();
        StartCoroutine(workGageUpdater());
    }

    IEnumerator workGageUpdater()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (mainSystem.Works.Count > 0)
            {
                WorkGager();
            }
        }
    }

    void WorkGager()
    {
        work = mainSystem.Works[workController.qCnt];
        if(work.workCheckPoint >= work.workPoint)
        {
            workBar.fillAmount = (float)work.workCheckPoint / (float)work.workPoint;
            workGage.text = "계약 완료";
            mainSystem.FinishWork(work.key);
        }
        else
        {
            workBar.fillAmount = (float)work.workCheckPoint / (float)work.workPoint;
            workGage.text = string.Format(work.workCheckPoint.ToString());
        }
    }
}
