using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchItem : MonoBehaviour
{
    public LineRenderer lineRend;
    Vector3 mouse_Pos;
    Vector2 start_MousePos;
    GameObject[] witem;

    public GameObject correctMatch;
    bool is_Move, is_Finish;

    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 2;
    }

    void Update()
    {
        if (!is_Finish)
        {
            if (is_Move)
            {
                if (Input.GetMouseButton(0))
                {
                    mouse_Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    lineRend.SetPosition(0, new Vector3(start_MousePos.x, start_MousePos.y, 0f));
                    lineRend.SetPosition(1, new Vector3(mouse_Pos.x, mouse_Pos.y, 0f));
                }
            }
        }
    }

    private void OnMouseDown()
    {
        if (!is_Finish)
        {
            if (is_Move == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    start_MousePos = this.transform.position;
                    is_Move = true;
                }
            }

        }
    }

    private void OnMouseUp()
    {
        if (Mathf.Abs(mouse_Pos.x - correctMatch.transform.position.x) <= .8f &&
                                         Mathf.Abs(mouse_Pos.y - correctMatch.transform.position.y) <= .8f && correctMatch.activeInHierarchy)
        {
            lineRend.SetPosition(0, new Vector3(start_MousePos.x, start_MousePos.y, 0f));
            lineRend.SetPosition(1, new Vector3(mouse_Pos.x, mouse_Pos.y, 0f));
            is_Finish = true;

          GameObject. FindGameObjectWithTag("Finish").GetComponent<Win>().AddPoints();

        }
        else
        {
            lineRend.SetPosition(0, new Vector3(0, 0, 0f));
            lineRend.SetPosition(1, new Vector3(0, 0, 0f));
            is_Move = false;
           /* lineRend.SetPosition(0, new Vector3(start_MousePos.x, start_MousePos.y, 0f));
            lineRend.SetPosition(1, new Vector3(mouse_Pos.x, mouse_Pos.y, 0f));
            lineRend.SetColors(Color.red,Color.red);
            is_Finish = true;
            GameObject.FindGameObjectWithTag("Finish").GetComponent<Win>().WrongPoints();*/
        }
    }
}
