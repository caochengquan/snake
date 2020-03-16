using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour {
    public static int grade = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        Destroy(gameObject);
        CreateFood.FoodNum--;
        ++grade;
        SnakeMove.Snake.AddLast(SnakeMove.Snake.Last.Value);
    }
}
