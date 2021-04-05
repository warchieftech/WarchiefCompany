using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSwitch : MonoBehaviour
{
    public void TitleStatus(Slave s)
    {
        switch (s.titleKey)
        {
            case 5000:
                s.loyalty = s.loyaltyBase + 10;
                break;
            case 5001:
                s.loyalty = s.loyaltyBase + 20;
                break;
            case 5002:
                s.runAngle = false;
                break;
        }
    }
}
