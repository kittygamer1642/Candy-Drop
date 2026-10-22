using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using Unity.VisualScripting;

public class BuildControls : MonoBehaviour
{
    public Vector2 ScreenPosition;
    public Vector2 WorldPosition;

    public List<GameObject> Cursor = new List<GameObject>();
    public int Type = 0;

    public bool PlacingObject;
    public Vector2 PlacePosition;
    public Vector2 PlaceScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScreenPosition = Mouse.current.position.ReadValue();
        WorldPosition = Camera.main.ScreenToWorldPoint(ScreenPosition);

        PlacingObject = Mouse.current.leftButton.wasPressedThisFrame;
        PlacePosition = WorldPosition;
        Cursor[Type].transform.position = new Vector3(PlacePosition.x, PlacePosition.y, 0);

        if (PlacingObject) {
            GameObject placed = Instantiate(Cursor[Type]);
            placed.transform.position = PlacePosition;
        }
    }

    Vector2 getScaleFromMouse(Vector2 pos)
    {
        float dx = pos.x - PlacePosition.x;
        float dy = pos.y - PlacePosition.y;

        return new Vector2(Mathf.Abs(dx), Mathf.Abs(dy));
    }
}
