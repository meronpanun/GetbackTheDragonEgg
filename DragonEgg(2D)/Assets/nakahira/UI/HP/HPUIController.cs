using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPUIController : MonoBehaviour
{
    private TextMeshProUGUI m_TextMeshProUGUI;

    private void Start()
    {
        // ‚±‚±‚Ç‚¤‚ ‚ª‚¢‚Ä‚àPlayerController‚ÌStart‚ÌŒã‚ÉÀs‚³‚ê‚ÄPlayer‘¤‚ªNull‚é
        m_TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    public void DispHp(int hp)
    {
        m_TextMeshProUGUI.text = hp.ToString();
    }
}
