using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toy : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    private Rigidbody2D rb;

    public float throwForce = 1f;
    public ToyboxObject box;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);

        float sizeX = GetComponent<Collider2D>().bounds.size.x;
        float sizeY = GetComponent<Collider2D>().bounds.size.y;

        float randomX = Random.Range(sizeX * 3, Screen.width - sizeX * 3);
        float randomY = Random.Range(sizeY * 3, Screen.height - sizeY * 3);

        float boxLeft = box.transform.position.x - box.GetComponent<Collider2D>().bounds.size.x * 2;
        float boxRight = box.transform.position.x + box.GetComponent<Collider2D>().bounds.size.x * 2;
        float boxTop = box.transform.position.y + box.GetComponent<Collider2D>().bounds.size.y * 2;
        float boxBottom = box.transform.position.y - box.GetComponent<Collider2D>().bounds.size.y * 2;

        float left = randomX - sizeX / 2;
        float right = randomX + sizeX / 2;
        float top = randomY + sizeY / 2;
        float bottom = randomY - sizeY / 2;

        while(left < boxRight && right > boxLeft)
        {
            randomX = Random.Range(0, Screen.width);
        }

        while(top < boxBottom && bottom > boxTop)
        {
            randomY = Random.Range(0, Screen.height);
        }

        Vector2 screenPos = new Vector2(randomX, randomY);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        transform.position = worldPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }

    private void OnMouseUp()
    {
        rb.isKinematic = false;
        Vector2 dir = (Vector2)transform.position - (Vector2)GetMouseWorldPos();
        rb.AddForce(dir * throwForce, ForceMode2D.Force);
    }

    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
        rb. isKinematic = true;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ToyBox")
        {
            Invoke("Cleaned", 1.25f);
        }
    }

    public void Cleaned()
    {
        gameObject.SetActive(false);
    }
}
