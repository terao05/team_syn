using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KszUtil;
public class safetouch : MonoBehaviour
{
    public safestate State;
    [SerializeField]
    private Smoothtransform dial;
    private string ObjectName;
    private void Start()
    {
       ObjectName = gameObject.name;
        Debug.Log(ObjectName);
    }
    public void OnClick()
    {
        if (State.clear == false)
        {
            if (ObjectName == "dial.001")
            {
                if (State.dial1 != 2)
                {
                    dial.TargetRotation *= Quaternion.Euler(120, 0, 0);
                    State.dial1++;
                }
                else if (State.dial1 == 2)
                {
                    State.dial1 = 0;
                    dial.TargetRotation *= Quaternion.Euler(120, 0, 0);
                }
            }
            if (ObjectName == "dial.002")
            {
                if (State.dial2 != 2)
                {
                    dial.TargetRotation *= Quaternion.Euler(120, 0, 0);
                    State.dial2++;
                }
                else if (State.dial2 == 2)
                {
                    State.dial2 = 0;
                    dial.TargetRotation *= Quaternion.Euler(120, 0, 0);
                }
            }
            if (ObjectName == "dial.003")
            {
                if (State.dial3 != 2)
                {
                    dial.TargetRotation *= Quaternion.Euler(120, 0, 0);
                    State.dial3++;
                }
                else if (State.dial3 == 2)
                {
                    State.dial3 = 0;
                    dial.TargetRotation *= Quaternion.Euler(120, 0, 0);
                }
            }
            if (State.dial1 == 1 && State.dial2 == 2 && State.dial3==0)
            {
                State.clear = true;
                Debug.Log("ê≥âÇæÇ®ÅI");
            }
        }
        else
        {
            Debug.Log("ê≥âÇæÇ©ÇÁìÆÇ©Ç»Ç¢Ç®ÅI");
        }
    } 
}
