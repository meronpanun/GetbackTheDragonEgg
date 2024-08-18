using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumberGenerator : MonoBehaviour
{
    // プレハブなんでリソースから
    private static GameObject s_damageText;
    private static GameObject s_canvas;

    private void Awake() // AwakeでもGameObject入るんだね
    {
        s_damageText = (GameObject)Resources.Load("DamageNumber");
        s_canvas = GameObject.Find("Canvas");
    }

    public static void GenerateText(int damage, Vector2 pos, Color color) // 与えられた数字を持ったテキストを生成する
    {
        GameObject instance = Instantiate(s_damageText, pos, Quaternion.identity);
        TextMeshPro temp = instance.GetComponent<TextMeshPro>();
        temp.text = damage.ToString();
        temp.color = color; // 色も指定
        // 最後、作ったやつをキャンバスに置く
        temp.transform.SetParent(s_canvas.transform, true);
    }
}
