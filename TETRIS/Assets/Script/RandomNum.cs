using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNum : MonoBehaviour
{
    //public Sprite sprite;
    public int randomNum;

    public Sprite s_ichi;
    public Sprite s_ni;
    public Sprite s_san;
    public Sprite s_yon;
    public Sprite s_go;
    public Sprite s_roku;

    // Start is called before the first frame update
    void Start() 
    {
        randomNum = UnityEngine.Random.Range(0, 6);

        switch(randomNum)
        {
            case 0:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = s_ichi;
                break;
            case 1:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = s_ni;
                break;
            case 2:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = s_san;
                break;
            case 3:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = s_yon;
                break;
            case 4:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = s_go;
                break;
            case 5:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = s_roku;
                break;
        }
    }

    // Update is called once per frame
    private void Update()
    {

    }
}
