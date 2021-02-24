using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarPoint : MonoBehaviour
{
    public List<GameObject> stars;
    public int level;

    private void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            stars.Add(transform.GetChild(i).gameObject);
        }
    }

    public void StarUpdate()
    {
        for(int i = 0; i < stars.Count; i++)
        {
            if(i < level)
            {
                stars[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/star-01");
            }
            else
            {
                stars[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/star-02");
            }
        }
    }
}
