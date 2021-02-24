using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSwitch : MonoBehaviour
{
    public void TitleStatus(Slave s)
    {
        switch (s.titleKey)
        {
            case 5003:
                s.loyalty = s.loyaltyBase + 20;
                break;
        }
    }
}
