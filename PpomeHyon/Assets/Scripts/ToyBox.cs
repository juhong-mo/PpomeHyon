using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToyBox : MonoBehaviour
{
    public string ToyScene;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(Screen.width / 2 - 2, Screen.height / 2 - 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(ToyScene);
    }
}