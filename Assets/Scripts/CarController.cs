using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public Button actionBtn;

    private Animator anim;
    private bool IsDoorOpen = false;
 
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void AddActionBtnListener()
    {
        actionBtn.onClick.RemoveAllListeners();
        actionBtn.onClick.AddListener(DoorOpenClose);
    }

    public void DoorOpenClose()
    {
        if(!IsDoorOpen)
        {
            anim.SetTrigger("open");
            IsDoorOpen = true;
        }
        else
        {
            anim.SetTrigger("close");
            IsDoorOpen = false;
        }
    }

}
