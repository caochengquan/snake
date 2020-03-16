using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIcontrol : MonoBehaviour {
    Text Grade;
    Button P;
    Button Button0;
    bool Pause;
    Button Button1;
    Button Button2;
    public KeyCode keycode;
	// Use this for initialization

	void Start() {
        transform.Find("Image").gameObject.SetActive(false);
        Grade = transform.Find("Grade").GetComponent<Text>();

        P = transform.Find("P").GetComponent<Button>();
        P.onClick.AddListener(() => transform.Find("Image").gameObject.SetActive(true));

        Button0 = transform.Find("Image").transform.Find("Button0").GetComponent<Button>();
        Button0.onClick.AddListener(() => transform.Find("Image").gameObject.SetActive(false));

        Button1 = transform.Find("Image").transform.Find("Button1").GetComponent<Button>();
        Button1.onClick.AddListener(() => SceneManager.LoadScene("Start"));

        Button2 = transform.Find("Image").transform.Find("Button2").GetComponent<Button>();
        Button2.onClick.AddListener(() => Application.Quit());
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(keycode))
        {
            Pause = transform.Find("Image").gameObject.activeSelf ? false : true;
            transform.Find("Image").gameObject.SetActive(Pause);
        }
        Pause = transform.Find("Image").gameObject.activeSelf;
        if(Pause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        Grade.text = "分数:" + OnTrigger.grade.ToString();
	}
}
