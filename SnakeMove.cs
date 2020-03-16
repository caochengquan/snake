using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
enum DIR//方向
{
    UP, DOWN, LEFT, RIGHT
}

public class SnakeMove : MonoBehaviour {
    public GameObject Head;
    public GameObject Body;
    public static LinkedList<Vector3> Snake;
    
    float a = 11;
    //方向
    //DIR dir;
    DIR MoveBack;
    DIR MoveFront;
    int OffsetX, OffsetZ;
    //public float time = 0;

	// Use this for initialization
	void Awake () {
        //创建蛇
        Snake = new LinkedList<Vector3>();
        for (int i = 0; i < 3; ++i)
        {
            Vector3 Pos = new Vector3(-5-i,0,0);
            Snake.AddLast(Pos);
        }
        MoveBack = DIR.RIGHT;
        MoveFront = DIR.RIGHT;
        InvokeRepeating("Move", 0, 0.3f);
	}
	
	// Update is called once per frame
    void Update()
    {
        //time++;
        //Time.timeScale = 0.1f;
        ChangeDir();
        //if (time >= 20)
        //{
            Draw();
            //Move();
            //time = 0;
        //}
        //else
        //{
        //    time += Time.deltaTime;
        //}
        if(die())
        {
            SceneManager.LoadScene("Die");
        }
	}

    void destorymap()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Sphere");
        foreach(var g in gos)
        {
            Destroy(g);
        }
    }

    void Draw()
    {
        destorymap();
        for (var Temp = Snake.First; Temp != null; Temp = Temp.Next)
        {
            if (Temp == Snake.First)
                Instantiate(Head, Temp.Value, Quaternion.identity);
            else
                Instantiate(Body, Temp.Value, Quaternion.identity);
        }
    }

    //蛇移动
    void Move()
    {
        //蛇身移动
        for (var Temp = Snake.Last; Temp != Snake.First; Temp = Temp.Previous)
        {
            var pre = Temp.Previous;
            Temp.Value = pre.Value;
            pre = pre.Previous;
        }

        if (rightabout(MoveBack))
        {
            switch (MoveBack)
            {
                case DIR.UP:
                    OffsetX = 0;
                    OffsetZ = 1;
                    break;
                case DIR.DOWN:
                    OffsetX = 0;
                    OffsetZ = -1;
                    break;
                case DIR.LEFT:
                    OffsetX = -1;
                    OffsetZ = 0;
                    break;
                case DIR.RIGHT:
                    OffsetX = 1;
                    OffsetZ = 0;
                    break;
            }
            MoveFront = MoveBack;
        }

        //蛇头移动
        Vector3 headpos = new Vector3(Snake.First.Value.x + OffsetX, 0, Snake.First.Value.z + OffsetZ);

        if(headpos.x>a)
        {
            headpos.x = -a;
        }
        else if(headpos.x<-a)
        {
            headpos.x = a;
        }
        else if(headpos.z>a)
        {
            headpos.z = -a;
        }
        else if (headpos.z  < -a)
        {
            headpos.z = a;
        }
        Snake.First.Value = headpos;
        
    }

    bool die()
    {
        var head = Snake.First;
        var tail = Snake.Last;
        for(int i=0;i<Snake.Count-3;++i)
        {
            if(tail.Value==head.Value)
            {
                return true;
            }
            tail=tail.Previous;
        }
        return false;
    }

    //控制移动
    void ChangeDir()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveBack=(DIR.UP);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            MoveBack=(DIR.DOWN);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            MoveBack = (DIR.LEFT);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MoveBack = (DIR.RIGHT);
        }
    }

    //判断反方向
    bool rightabout(DIR dirlater)
    {
        switch(dirlater)
        {
            case DIR.UP:
                if (MoveFront == DIR.DOWN)
                    return false;
                break;
            case DIR.DOWN:
                if (MoveFront == DIR.UP)
                    return false;
                break;
            case DIR.RIGHT:
                if (MoveFront == DIR.LEFT)
                    return false;
                break;
            case DIR.LEFT:
                if (MoveFront == DIR.RIGHT)
                    return false;
                break;
        }
        return true;
    }

}
