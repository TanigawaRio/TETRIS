using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreObject = null;
    public int scoreNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreNum = PlayerPrefs.GetInt("SCORE", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("SCORE", scoreNum);
        PlayerPrefs.Save();
    }
}
