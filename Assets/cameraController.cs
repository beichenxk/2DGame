
using Unity.VisualScripting;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public static cameraController instance;
    public Vector3 minBound,maxBound;
    public Transform Playertransform;

    void Start()
    {
        instance=this;
    }
    void LateUpdate()
    {
        if(minBound!=Vector3.zero&&maxBound!=Vector3.zero)
        {
            float clampedX=Mathf.Clamp(Playertransform.position.x,minBound.x,maxBound.x);
            float clampedY=Mathf.Clamp(Playertransform.position.y,minBound.y,maxBound.y);
            transform.position=new Vector3(clampedX,clampedY,transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("进入边界");
        if(other.CompareTag("CamaraBound"))
        {
            minBound=other.GetComponent<BoxCollider2D>().bounds.min;
            maxBound=other.GetComponent<BoxCollider2D>().bounds.max;
        }
    }
    public void freeCamera()
    {
        minBound=Vector3.zero;
        maxBound=Vector3.zero;
        transform.position=new Vector3(Playertransform.position.x,Playertransform.position.y,-10);
    }
}
