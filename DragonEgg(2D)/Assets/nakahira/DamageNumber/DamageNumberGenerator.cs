using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumberGenerator : MonoBehaviour
{
    // プレハブなんでエディタから
    [SerializeField]
    private GameObject objTemp;
    private static GameObject s_damageText;

    private void Awake() // AwakeでもGameObject入るんだね
    {
        s_damageText = objTemp;
    }

    public static void GenerateText(float damage, Vector2 pos, Color color) // 与えられた数字を持ったテキストを生成する
    {
        GameObject instance = Instantiate(s_damageText, pos, Quaternion.identity);
        TextMeshPro temp = instance.GetComponent<TextMeshPro>();
        temp.text = damage.ToString("f"); // 小数点第二位まで表示（仮）
        temp.color = color; // 色も指定
    }
}
