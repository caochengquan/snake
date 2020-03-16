using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFood : MonoBehaviour
{
    public GameObject Food;
    public static int FoodNum = 0;

	// Use this for initialization
	void OnEnble() {
	}
	
	// Update is called once per frame
	void Update () {
        FoodCreate();
	}

    //void FoodNUM()
    //{
    //    GameObject[] gos = GameObject.FindGameObjectsWithTag("Food");
    //    foreach(var g in gos)
    //    {
            
    //    }
    //}

    void FoodCreate()
    {
        while (0 == FoodNum)
        {
            bool may = true;
            Vector3 temp = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            for (var Temp = SnakeMove.Snake.Last; Temp != null; Temp = Temp.Previous)
            {
                if (Temp.Value == temp)
                {
                    may = false;
                    break;
                }
            }
            if (may)
            {
                Instantiate(Food, transform.position, transform.rotation);
                FoodNum++;
            }
        }
    }
}
