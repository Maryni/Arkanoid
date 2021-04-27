using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private bool needToChangeZ;
    [SerializeField] private float mZCoordFromInspector;
    [SerializeField] private float modX;
    [SerializeField] private Vector3 mOffset;


    private void Update()
    {
        if(transform.position.x>6 || transform.position.x<-5)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
    }
    private float mZCoord;
    private void OnMouseDown()
    {
        if (!needToChangeZ) mZCoord = cam.WorldToScreenPoint(gameObject.transform.position).z;
        if (needToChangeZ && mZCoordFromInspector != 0) mZCoord = mZCoordFromInspector;

        mOffset = gameObject.transform.position - GetMouseWorldPos();
       // mOffset = new Vector3(transform.position.x,mOffset.y, mOffset.z);
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
        Vector3 tempPlusOffset;
        //print(GetMouseWorldPos());
        temp = GetMouseWorldPos();
        if (transform.position.x>=-5 && transform.position.x<=5)
        {
             
            tempPlusOffset = temp + mOffset;
            tempPlusOffset = new Vector3(tempPlusOffset.x * modX, tempPlusOffset.y, tempPlusOffset.z);
            tempPlusOffset.x = -tempPlusOffset.x;  //for normal <-x-> moving cuz else - it's reverte
            transform.position = tempPlusOffset;
        }
        else if(transform.position.x>5 || transform.position.x<5)
        {
            
            if (transform.position.x > 5) { temp.x -= 0.1f; }
            if (transform.position.x < 5) { temp.x += 0.1f; }

            tempPlusOffset = temp + mOffset;
            tempPlusOffset = new Vector3(tempPlusOffset.x * modX, tempPlusOffset.y, tempPlusOffset.z);
            transform.position = tempPlusOffset;
        }
        
    }
}
//-5 | 5