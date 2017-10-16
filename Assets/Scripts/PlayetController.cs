using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayetController : MonoBehaviour {
	
	public float speed;
	public Text countText;
	public Text winText;
	
	private Rigidbody rb;
	private int count = 0;

	//Start
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		count = 0;
		countText.text = "Count: " + count.ToString();
		winText.text = "";
    }
	
	//Before Physics
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		
		rb.AddForce(movement * speed);
	}
	
	void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Points"))
        {
            other.gameObject.SetActive (false);
			count++;
			countText.text = "Count: " + count.ToString();
			
			if(count >= 12) {
				winText.text = "You Win Zlamasie";
			}
        }
    }
}
