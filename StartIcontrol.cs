using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartIcontrol : MonoBehaviour {
    Button Button0;
    Button Button1;
    Button Button2;
    // Use this for initialization

    void Awake()
    {
        Screen.SetResolution(640, 400, false);
    }

    void Start()
    {
        Button0 = transform.Find("Image").transform.Find("Button0").GetComponent<Button>();
        Button0.onClick.AddListener(() => SceneManager.LoadScene("Game"));
        Button0.onClick.AddListener(() => CreateFood.FoodNum = 0);
        Button0.onClick.AddListener(() => OnTrigger.grade = 0);

        Button1 = transform.Find("Image").transform.Find("Button1").GetComponent<Button>();
        Button1.onClick.AddListener(() => SceneManager.LoadScene("Game"));
        Button1.onClick.AddListener(() => CreateFood.FoodNum = 0);
        Button1.onClick.AddListener(() => OnTrigger.grade = 0);

        Button2 = transform.Find("Image").transform.Find("Button2").GetComponent<Button>();
        Button2.onClick.AddListener(() => Application.Quit());
    }
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		
	}
}
