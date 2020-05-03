using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public static CameraMovement instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void SetViewTarget(Transform targetPos)
    {
        this.target = targetPos;
    }



    public Transform target;
    public float smoothing;

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(target ==null)
        {
            return;
        }

        if(transform.position != target.position)
        {
            transform.position = Vector3.Lerp(transform.position,
                target.position, smoothing);
            transform.position += new Vector3(0, 0, -10);
        }
    }

}
