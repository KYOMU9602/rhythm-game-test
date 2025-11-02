using UnityEngine;
using System.Collections;

// 讓音符從遠處飛向判定點的腳本
public class NoteMovement : MonoBehaviour
{
    // ----------------------
    // 參數設定 (會在 Unity Editor 中調整)
    // ----------------------

    [Tooltip("音符從生成到判定點所需的時間（秒）")]
    public float timeToReachHitPoint = 2f;

    // ----------------------
    // 私有變數
    // ----------------------

    // 音符的移動速度
    private float moveSpeed;

    // ----------------------
    // Unity 生命週期方法
    // ----------------------

    void Start()
    {
        // 計算移動速度：
        // 速度 (Speed) = 距離 (Distance) / 時間 (Time)
        // 由於我們還沒有設定距離，這裡先簡單地用 Z 軸座標來代表距離。
        
        // 假設音符的起始 Z 座標就是它要移動的總距離。
        float distance = transform.position.z; 

        // 計算速度：每秒需要移動多少單位距離。
        moveSpeed = distance / timeToReachHitPoint;
    }

    void Update()
    {
        // 讓音符沿著 Z 軸（從遠到近）移動。
        // Time.deltaTime 是自上次 Update 以來經過的時間，確保移動速度與幀率無關。
        
        // 使用 Translate 方法移動物件
        // Vector3.forward 相當於 (0, 0, 1)
        // 因為我們希望音符是朝鏡頭（-Z方向）移動，所以是負值。
        transform.Translate(Vector3.forward * -moveSpeed * Time.deltaTime);

        // 檢查音符是否飛過判定點（假設判定點在 Z=0）
        if (transform.position.z < -2f) // 設定一個比 0 更遠的銷毀點
        {
            // 如果音符飛過判定點太遠，就將它銷毀，釋放資源
            Destroy(gameObject);
        }
    }
}
