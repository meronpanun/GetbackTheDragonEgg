using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �����̓g���K�[���Ƀv���C���[�̍U���������Ă�����
// �e�I�u�W�F�N�g�ɒm�点�܂��B
// �N�[���^�C������B�@

public class DF_ApproachObserver : MonoBehaviour
{
    // �e�̃I�u�W�F�N�g
    private GameObject dragonFry;
    private DragonFryController dragonFryController;
    // ��x��������牽�b�̃N�[���^�C���ɓ��邩
    private const float coolTime = 1f;
    // �L�^�p�^�C�}�[
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        // �擾
        dragonFry = transform.parent.gameObject;
        dragonFryController = dragonFry.GetComponent<DragonFryController>();
    }

    // Update is called once per frame
    void Update()
    {
        // OnTriggerEnter2D�Ŏg���܂��B
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("�Ă΂�Ă܂�");
        // �N�[���^�C�����Ȃ疳��
        if (timer < coolTime) return;

        // �ꕶ���ɂ����Ⴄ
        GameObject g = collision.gameObject;
        if (g.CompareTag("Player") || g.CompareTag("PlayerBullet"))
        {
            // �悯��I�I
            //Debug.Log("�悯��I");
            dragonFryController.Dodge();
            timer = 0;
        }
    }
}
