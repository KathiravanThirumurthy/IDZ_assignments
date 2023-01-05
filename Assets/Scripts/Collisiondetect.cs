using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisiondetect : MonoBehaviour
{
    private Uimanager _uimanager;
    private void Start()
    {
        _uimanager = GameObject.Find("Uimanager").GetComponent<Uimanager>();
        if (_uimanager == null)
        {
            Debug.LogError("The UImnager is null");
        }
    }
    private int score = 0;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collectable")
        {
            collision.gameObject.SetActive(false);
            score++;
            _uimanager.scoring(score);
            Debug.Log("Score:"+score);
        }
        //Debug.Log(collision.gameObject.name);

    }
}
