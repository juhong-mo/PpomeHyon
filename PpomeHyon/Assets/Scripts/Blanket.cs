using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Blanket : MonoBehaviour
{
    private float mouseX, mouseY;

    private Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        Vector2 inputPosition = Input.mousePosition;

        mouseX = Camera.main.ScreenToWorldPoint(inputPosition).x + offset.x;
        mouseY = Camera.main.ScreenToWorldPoint(inputPosition).y + offset.y;

        transform.position = new Vector2(mouseX, mouseY);
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
