using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{

    // キューブの移動速度
    private float speed = -0.2f;

    // 消滅位置
    private float deadLine = -10;

    //（課題追記）衝突音
    public AudioClip block;
    AudioSource aud;


    // Use this for initialization
    void Start()
    {
        this.aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    //（課題追記）衝突時に衝突音を鳴らし、unityChan2Dに衝突時にはボリュームを0にする
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
        this.aud.PlayOneShot(this.block);
        if (collision.gameObject.tag == "UnityChan2D")
        {
            Debug.Log("uhit");
            GetComponent<AudioSource>().volume = 0;

        }
    }
}