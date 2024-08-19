using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPUIController : MonoBehaviour
{
    private TextMeshProUGUI m_TextMeshProUGUI;

    private void Start()
    {
        // �����ǂ��������Ă�PlayerController��Start�̌�Ɏ��s�����Player����Null��
        m_TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    public void DispHp(int hp)
    {
        m_TextMeshProUGUI.text = hp.ToString();
    }
}
