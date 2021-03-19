using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkBtn : MonoBehaviour
{
    public WorkController workController;

    private void Start()
    {
        workController = GameObject.FindWithTag("WorkController").GetComponent<WorkController>();
    }
    public void ViewWork()
    {
        workController.ClickNewWork(transform.GetSiblingIndex());
    }
}
