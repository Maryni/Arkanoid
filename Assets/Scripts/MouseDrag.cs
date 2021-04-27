using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private bool needToChangeZ;
    [SerializeField] private float mZCoordFromInspector;
    [SerializeField] private float modX;
    private Vector3 mOffset;
   

    private float mZCoord;
    private void OnMouseDown()
    {
        if (!needToChangeZ) mZCoord = cam.WorldToScreenPoint(gameObject.transform.position).z;
        if (needToChangeZ && mZCoordFromInspector != 0) mZCoord = mZCoordFromInspector;

        mOffset = gameObject.transform.position - GetMouseWorldPos();
        mOffset = new Vector3(transform.position.x,mOffset.y, mOffset.z);
    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.y = transform.position.y;
        mousePoint.z = mZCoordFromInspector;
        return cam.ScreenToWorldPoint(mousePoint);
    }
    private void OnMouseDrag()
    {
        Vector3 temp;
        //print(GetMouseWorldPos());
        temp = GetMouseWorldPos();
        if (transform.position.x>=-5 && transform.position.x<=5)
        {
            temp.x = -temp.x;
            transform.position = temp + mOffset;
        }else if(transform.position.x>5 || transform.position.x<5)
        {
            
            if (transform.position.x > 5) { temp.x -= 0.1f; }
            if (transform.position.x < 5) { temp.x += 0.1f; }
            transform.position = temp + mOffset;
            transform.position = new Vector3(transform.position.x * modX,transform.position.y,transform.position.z);
        }
        
    }
}
//-5 | 5