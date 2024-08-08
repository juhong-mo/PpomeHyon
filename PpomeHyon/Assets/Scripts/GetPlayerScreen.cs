using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerScreen : MonoBehaviour
{
    private float width;
    private float height;

    private float worldScreenWidth;
    private float worldScreenHeight;

    private Vector3 xWidth;
    private Vector3 yHeight;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (sr == null) return;

        width = sr.sprite.bounds.size.x;
        height = sr.sprite.bounds.size.y;

        worldScreenHeight = Camera.main.orthographicSize * 2f;
        worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        xWidth = transform.localScale;
        xWidth.x = worldScreenWidth / width;
        transform.localScale = xWidth;

        yHeight = transform.localScale;
        yHeight.y = worldScreenHeight / height;
        transform.localScale = yHeight;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
