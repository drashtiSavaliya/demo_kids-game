        using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    private int win_points;
    private int current_points,Wrong_points;
    public GameObject Actual_images;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        win_points= Actual_images.transform.childCount;
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if(current_points>=win_points)
        {
           transform.GetChild(0).gameObject.SetActive(true);
        }*/
    }

    public void AddPoints()
    {
        current_points++;
        if(current_points>=win_points)
        {
           transform.GetChild(0).gameObject.SetActive(true);
        }
        // else 
        // {
        //      transform.GetChild(1).gameObject.SetActive(true);
        // }
    }

    public void WrongPoints()
    {
        Wrong_points++;
        if(current_points+Wrong_points >= win_points)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    
}
