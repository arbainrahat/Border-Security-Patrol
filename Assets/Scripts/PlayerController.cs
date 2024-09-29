using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Transform aim;
    public Button actionBtn;

    private Outline outline;
   
    void Update()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(aim.position);

        if (Physics.Raycast(ray, out hit, 5f))
        {
            if (hit.collider.CompareTag("openable"))
            {
                actionBtn.gameObject.SetActive(true);
                hit.collider.GetComponent<CarController>().AddActionBtnListener();

                if (outline)
                    outline.enabled = false;

                outline = hit.collider.GetComponent<Outline>();
                outline.enabled = true;   

            }
            else
            {
                actionBtn.gameObject.SetActive(false);

                if (outline)
                    outline.enabled = false;
            }
        }
        
    }
}
