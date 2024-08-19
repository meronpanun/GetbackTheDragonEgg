using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundManeger : MonoBehaviour
{
    //�\��������UI�p�l��
    public GameObject pousePanel;
    public GameObject SoundPanel;

    //�����I���{�^��
    public GameObject pouseFirstbutton;
    public GameObject SoundFirstbutton;

    //�|�[�Y���j���[�ɐ؂�ւ�
    public void SelectedPouseMenu()
    {
        //�����I���{�^���̏�����
        EventSystem.current.SetSelectedGameObject(null);
        //�����I���{�^���̍Ďw��
        EventSystem.current.SetSelectedGameObject(pouseFirstbutton);

        pousePanel.SetActive(true);
        SoundPanel.SetActive(false);
    }

    //�T�E���h���j���[�ɐ؂�ւ�
    public void SelectedSoundMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(SoundFirstbutton);

        pousePanel.SetActive(false);
        SoundPanel.SetActive(true);
    }
}
