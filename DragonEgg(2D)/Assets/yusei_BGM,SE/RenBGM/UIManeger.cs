using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManeger : MonoBehaviour
{

    //�R��Panel���i�[����ϐ�
    //�C���X�y�N�^�[�E�B���h�E����Q�[���I�u�W�F�N�g��ݒ肷��
    [SerializeField] GameObject SoundPanel;
    //[SerializeField] GameObject xrHubPanel;
    //[SerializeField] GameObject unityPanel;


    // Start is called before the first frame update
    void Start()
    {
        //BackToMenu���\�b�h���Ăяo��
        BackToMenu();
    }


    //SoundPanel��OKButton�������ꂽ�Ƃ��̏���
    //XR-HubPanel���A�N�e�B�u�ɂ���
    public void SelectXrHubDescription()
    {
        SoundPanel.SetActive(true);
        //.SetActive(true);
    }


    ////MenuPanel��UnityButton�������ꂽ�Ƃ��̏���
    ////UnityPanel���A�N�e�B�u�ɂ���
    //public void SelectUnityDescription()
    //{
    //    menuPanel.SetActive(false);
    //    unityPanel.SetActive(true);
    //}


    //2��DescriptionPanel��BackButton�������ꂽ�Ƃ��̏���
    //MenuPanel���A�N�e�B�u�ɂ���
    public void BackToMenu()
    {
        SoundPanel.SetActive(true);
        //xrHubPanel.SetActive(false);
        //unityPanel.SetActive(false);
    }
}
