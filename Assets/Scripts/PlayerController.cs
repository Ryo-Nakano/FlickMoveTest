using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Vector3 touchStartPos;//タッチを始めた場所を格納しておく為の変数
    public Vector3 touchEndPos;//タッチが終わった場所を格納しておく為の変数
    public string Direction;//タッチの方向
    bool oneplay;

    void Start()
    {

    }

    void Update()
    {
        Flick();//フリックを検知する関数
    }

    //フリックを検知する関数
    void Flick()
    {
		if (Input.GetKeyDown(KeyCode.Mouse0))//マウスが左クリックされた時(画面がタッチされた時)
        {
			//画面がタッチされた瞬間の座標を変数touchStartPosに格納
            touchStartPos = new Vector3(Input.mousePosition.x,
                Input.mousePosition.y,
                Input.mousePosition.z);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
			//画面タッチが終わった瞬間の座標を変数touchEndtPosに格納
            touchEndPos = new Vector3(Input.mousePosition.x,
                Input.mousePosition.y,
                Input.mousePosition.z);
            GetDirection();//フリックの方向を見極める為の関数
        }
    }

	//フリックの方向を見極める為の関数
    void GetDirection()
    {
		float directionX = touchEndPos.x - touchStartPos.x;//指が横向きに動いた量(この時点では値がマイナスの可能性あり)
		float directionY = touchEndPos.y - touchStartPos.y;//指が縦向きに動いた量(この時点では値がマイナスの可能性あり)
        

		///Mathf.Abs()は"絶対値"を求めてくれる！
		/// →どれだけ指が動いたのか、その量を算出してくれる！
        if (Mathf.Abs(directionY) < Mathf.Abs(directionX))//指の動きが"横方向"の方が大きかった時
        {
            if (30 < directionX)//指が左→右に動いていた時
            {
                //右向きにフリック
                Direction = "right";

            }
            if (-30 > directionX)//指が右→左に動いていた時
            {
                //左向きにフリック
                Direction = "left";
            }
        }
        else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))//指の動きが"縦方向"の方が大きかった時
        {
            if (30 < directionY)//指が下→上に動いていた時
            {
                //上向きにフリック
                Direction = "up";
            }
			if (-30 > directionY)//指が上→下に動いていた時
            {
                //下向きのフリック
                Direction = "down";
            }
        }
        else//指が動いていなかった時
        {
            //タッチを検出
            Direction = "touch";
        }
        switch (Direction)//変数Directionの値に応じて条件分岐！
        {
            case "up":
				//上フリックされた時の処理
				Debug.Log("Up");
                break;

            case "down":
                //下フリックされた時の処理
				Debug.Log("Down");
                break;

            case "right":
                //右フリックされた時の処理
				Debug.Log("Right");

				if(this.transform.position.x < 3)//Playerが画面から出ない時
				{
					this.transform.position += new Vector3(1, 0, 0);//Playerを右に一定距離移動
				}
				else
				{
					Debug.Log("I can't move !!!");
				}

                break;

            case "left":
                //左フリックされた時の処理
				Debug.Log("Left");

				if (this.transform.position.x > -3)//Playerが画面から出ない時
                {
                    this.transform.position += new Vector3(-1, 0, 0);//Playerを左に一定距離移動
                }
                else
                {
                    Debug.Log("I can't move !!!");
                }

                break;

            case "touch":
                //タッチされた時の処理
				Debug.Log("Touch");
                break;
        }

    }
}
