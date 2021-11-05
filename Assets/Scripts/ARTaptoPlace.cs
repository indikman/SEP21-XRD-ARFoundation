using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTaptoPlace : MonoBehaviour
{
    public GameObject spawnPrefab; // This is the prefab that will be instantiated when you tap on the screen.

    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject spawnedPrefab;
    
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    
    void Update()
    {
        if(spawnedPrefab == null)
        {
            if(Input.touchCount > 0) // Identify the number of touches
            {
                Vector2 touchPosition = Input.GetTouch(0).position;

                if(raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hits[0].pose;

                    spawnedPrefab = Instantiate(spawnPrefab, hitPose.position, hitPose.rotation);
                }


            }
        }

    }
}
