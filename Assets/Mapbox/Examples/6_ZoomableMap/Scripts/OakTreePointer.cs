using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Utils;
using Mapbox.Examples;
using UnityEditor;


public class OakTreePointer : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 30.0f;   // Slower rotation speed
    [SerializeField] private float amplitude = 0.2f;        // Increased bobbing amplitude
    [SerializeField] private float frequency = 0.5f;        // Bobbing frequency remains the same
    [SerializeField] private float yOffset = -0.1f;         // Offset to ensure it dips slightly into the ground

    LocationStatus playerLocation;
    
    public Vector2d eventPos;
    public int eventID;

    [SerializeField] private string gameIdentifier;

    private MenuUIManager menuUIManager;
    private EventManager eventManager;
    // Start is called before the first frame update

    void Start()
    {
        menuUIManager = GameObject.Find("Canvas").GetComponent<MenuUIManager>();
        eventManager = GameObject.Find("-EventManager").GetComponent<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        FloatAndRotatePointer();
    }

    private void FloatAndRotatePointer()
    {
        // Rotate the object around the Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Calculate the new Y position for bobbing
        float newY = Mathf.Sin(Time.time * Mathf.PI * frequency) * amplitude + yOffset;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnMouseDown()
    {
        playerLocation = GameObject.Find("Canvas").GetComponent<LocationStatus>();
        var currentPlayerLocation = new GeoCoordinatePortable.GeoCoordinate(playerLocation.GetLocationLat(), playerLocation.GetLocationLon());
        var eventLocation = new GeoCoordinatePortable.GeoCoordinate(eventPos[0], eventPos[1]);
        var distance = currentPlayerLocation.GetDistanceTo(eventLocation);
        //Debug.Log("Distance is: " + distance);
        //Debug.Log("Clicked!");
        if (distance < eventManager.maxDistance)
        {
            // Here you have both eventID and gameIdentifier available to choose how to proceed:
            // For example, you can pass both to the UI manager.
            menuUIManager.DisplayInRangePanel(gameIdentifier);
        }
        else
        {
            menuUIManager.DisplayNotInRangePanel();
        }


    }
}
