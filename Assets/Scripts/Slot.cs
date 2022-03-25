using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Text count;

    public void DisableCounter()
    {
        count.enabled = false;
    }

    public void SetCount(int n)
    {
        count.text = n.ToString();
    }

}
