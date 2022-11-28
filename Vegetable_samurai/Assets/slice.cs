using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slice : MonoBehaviour
      
{
    public GameObject BladeTrailPrefab;
    public float minCuttingVelocity=0.001f;
    

    bool isCutting = false;
    Vector2 previousPosition;
    GameObject CurrentBladeTrail;


    Rigidbody2D rb;
    Camera cam;
    CircleCollider2D circleCollider;

   void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCut();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCut();
        }

        if(isCutting)
        {
            UpdateCut();
        }
    }

    void UpdateCut()
    {
         Vector2 newPosition= cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

        float velocity = (newPosition = previousPosition).magnitude*Time.deltaTime;

        if (velocity > minCuttingVelocity)
        {
            circleCollider.enabled = true;
        }
        else
        {
            circleCollider.enabled=false; 
        }
        previousPosition = newPosition;
    }
    void StartCut()
    {
        isCutting = true;
        CurrentBladeTrail = Instantiate(BladeTrailPrefab,transform);
        previousPosition=cam.ScreenToWorldPoint(Input.mousePosition);   
        circleCollider.enabled=false;
    }
    void StopCut()
    {
        isCutting = false;
        CurrentBladeTrail.transform.SetParent(null);
        Destroy(CurrentBladeTrail,2f);
        circleCollider.enabled = false;
    }
}
