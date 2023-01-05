using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uimanager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    // Start is called before the first frame update
    public void scoring(int score)
    {
        //Debug.Log(score);
        _scoreText.text = "Score :" +score.ToString();
    }
}
