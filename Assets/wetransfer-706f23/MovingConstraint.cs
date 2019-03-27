using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingConstraint : MonoBehaviour
{
    [Tooltip("Object now can't move outside the screen")]
    public bool moveWithinScreen;

    [Tooltip("Higher values -> smaller area to move around")]
    [Header("Reduce Maximum and Minimum")]
    public float xMaxAdjust;
    public float yMaxAdjust;
    public float xMinAdjust;
    public float yMinAdjust;


    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;
    private float halfWidth;
    private float halfHeight;

    private void Start()
    {
        if (moveWithinScreen)
        {
            MeasureObject();
            CalculateBoundary();
        }
    }

    private void Update()
    {
        if(moveWithinScreen)
            RestrictToScreen();

    }

    private void CalculateBoundary()
    {
        //Upper Corner
        Vector3 screenCorner = new Vector3(Screen.width, Screen.height, 0f);
        Vector3 worldCorner = Camera.main.ScreenToWorldPoint(screenCorner);

        xMax = worldCorner.x-halfWidth- xMaxAdjust;
        yMax = worldCorner.z-halfHeight- yMaxAdjust;

        //Lower Corner
        screenCorner = new Vector3(0f,0f,0f);
        worldCorner = Camera.main.ScreenToWorldPoint(screenCorner);

        xMin = worldCorner.x+halfWidth + xMinAdjust;
        yMin = worldCorner.z+halfHeight + yMinAdjust;

    }
    private void MeasureObject()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        halfWidth = spriteRenderer.bounds.extents.x;
        halfHeight = spriteRenderer.bounds.extents.z;
    }
    private void RestrictToScreen()
    {
        var x = transform.position.x;
        var y = transform.position.y;
        var z = transform.position.z;

        if (x > xMax)
            x = xMax;
        if (x < xMin)
            x = xMin;

        if (z > yMax)
            z = yMax;
        if (z < yMin)
            z = yMin;

        transform.position = new Vector3(x, y, z);
    }
}
