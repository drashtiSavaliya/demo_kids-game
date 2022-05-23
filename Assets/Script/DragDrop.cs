using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public GameObject correct_Item;
    private bool move,isFinished;
    
    private float startPos_X, startPos_Y;

	private Vector3 reset_Pos;

    // Start is called before the first frame update
    private void Start()
    {
        //Reset Position of an Actual_item
        reset_Pos = this.transform.localPosition;	
    }

    // Update is called once per frame
    private void Update()
    {
		if (!isFinished)
		{
			if (move)
			{
				Vector3 Mouse_pos;
				Mouse_pos = Input.mousePosition;
				Mouse_pos = Camera.main.ScreenToWorldPoint(Mouse_pos);

				this.gameObject.transform.localPosition = new Vector3(Mouse_pos.x - startPos_X, Mouse_pos.y - startPos_Y, this.transform.localPosition.z);

			}
		}
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
		{
			Vector3 Mouse_pos;
			Mouse_pos = Input.mousePosition;
			Mouse_pos = Camera.main.ScreenToWorldPoint(Mouse_pos);

			startPos_X = Mouse_pos.x - this.transform.localPosition.x;
			startPos_Y = Mouse_pos.y - this.transform.localPosition.y;

			move = true;
		}
    }

    private void OnMouseUp()
    {
        move = false;

		// Checking whether the position is correct or not 

		if (Mathf.Abs(this.transform.localPosition.x - correct_Item.transform.localPosition.x) <= 0.5f &&
			Mathf.Abs(this.transform.localPosition.y - correct_Item.transform.localPosition.y) <= 0.55f)
		{
			this.transform.position = new Vector3(correct_Item.transform.position.x, correct_Item.transform.position.y, correct_Item.transform.position.z);
			isFinished = true;

			GameObject. FindGameObjectWithTag("Finish").GetComponent<Win>().AddPoints();
		}

		else
		{
			this.transform.localPosition = new Vector3(reset_Pos.x, reset_Pos.y, reset_Pos.z);
		}
    }
}
