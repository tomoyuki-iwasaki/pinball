using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallController : MonoBehaviour
{

    private int score = 0;

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //点数を表示するテキスト
    private GameObject pointText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;

        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーン中のScoreTextオブジェクトを取得
        this.pointText = GameObject.Find("ScoreText");
    }


    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }

//        this.pointText.GetComponent<Text>().text = string.Format("SCORE:{0}", score);
        this.pointText.GetComponent<Text>().text = score.ToString("D4");
    }

    //    void OnCollisionEnter(Collision other)
    //    {
    //        // 衝突した。※相手のTag名を表示してみる。
    //        Debug.Log("衝突：" + other.gameObject.tag);
    //    }

    void OnCollisionEnter(Collision other)
    {
        string pointTag = other.gameObject.tag;

        // 衝突時：大きい星
        if (pointTag == "LargeStarTag")
        {
            score += 10;
            Debug.Log("大きい星：" + other.gameObject.tag);
        }
        else if (pointTag == "SmallStarTag")
        {
            score += 1;
            Debug.Log("小さい星：" + other.gameObject.tag);
        }
        else if (pointTag == "LargeCloudTag")
        {
            score += 100;
            Debug.Log("大きい雲：" + other.gameObject.tag);
        }
        else if (pointTag == "SmallCloudTag")
        {
            score += 50;
            Debug.Log("小さい雲：" + other.gameObject.tag);
        }
        else
        {
            Debug.Log("その他");
        }
    }





}
