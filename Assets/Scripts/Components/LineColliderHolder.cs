using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineColliderHolder : MonoBehaviour
{
    public BoardLine ParentLine { get; set; }


    private void OnMouseDown()
    {
        
        OnClick();
    }

    public void OnClick()
    {
        Debug.Log("mouseclicked");
        ParentLine.OnClick();
    }
}
