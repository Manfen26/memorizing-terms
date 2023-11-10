using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    [SerializeField] private Sprite[] Theoty;
    public GameObject imgObj;
    public int pagenumber = 0;

    public void theorypageup()
    {
        if (pagenumber <= Theoty.Length)
        {
            pagenumber += 1;
            changeimgvoid(pagenumber);
        }
    }

    public void theorypagedown()
    {
        if (pagenumber > 0)
        {
            pagenumber -= 1;
            changeimgvoid(pagenumber);
        }
    }

    private void changeimgvoid(int i)
    {
        imgObj.GetComponent<Image>().sprite = Theoty[i];
    }
}
