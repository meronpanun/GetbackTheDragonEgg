using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDragonFryController : Enemy
{
    private const int DRAGONFRYATTACK = 1;
    private const float SHOOTSPAN = 1;
    private Rigidbody2D myRigid;
    // �悯��ۂ̑���
    private float dodgeForce = 250;
    // �A��Ƃ��̃X�s�[�h
    private float exitForceX = 10f;
    private float exitForceY = -1f;
    // �G�f�B�^��
    public GameObject bulletPrefab;
    // ���b�őޏꂷ�邩
    private const float LIFESPAN = 10f;
    private float timer = 0;
    // Start���ɍ��ɂ͂��邩�E�ɂ͂��邩���߂Ă���
    private int leftOrRight = 0;
    protected override void Start()
    {
        base.Start();
        attack = DRAGONFRYATTACK;
        myRigid = GetComponent<Rigidbody2D>();
        shootSpan = SHOOTSPAN;
        // ���E�̂ǂ���ɂ悯�邩�B-1�����A1���E
        leftOrRight = Random.Range(0, 2);
        if (leftOrRight == 0)
        {
            leftOrRight = -1;
        }
        // �ŏ�����������ƑO�ɏo��
        myRigid.AddForce(Vector2.down * 200);
    }

    protected override void Update()
    {
        base.Update();
        // �^�C�}�[���Z
        timer += Time.deltaTime;
        // �����𒴂��Ă��Ȃ���΂��̐�̏����͎��s����Ȃ�
        if (timer < LIFESPAN) return;
        // �ޏꂷ�邽�߂�AddForce���Ă���
        Exit();
    }

    private void Exit()
    {
        // �ړ�
        myRigid.AddForce(new Vector2(exitForceX * leftOrRight, 0f));
        // X�����͉����AY�����͓���
        transform.Translate(0f, exitForceY * Time.deltaTime, 0f);
    }

    public void Dodge()
    {
        // ���E�̂ǂ���ɂ悯�邩�B0�����A1���E
        int leftOrRight = 1;
        // ���[���h���W���E�ɂ�����
        if (transform.position.x > 0)
        {
            // -1�ɋ��������Ă��炢�܂���
            leftOrRight = -1;
        }
        // �㉺�̊p�x(���W�A����)
        float direction = Random.Range(-10f, 10f) * Mathf.Deg2Rad;
        // �ړ�����x�N�g�����쐬
        Vector2 dodgeDir = new Vector2(Mathf.Cos(direction) * dodgeForce * leftOrRight, Mathf.Sin(direction) * dodgeForce);
        // ���s
        myRigid.AddForce(dodgeDir);
    }

    protected override void Shoot()
    {
        base.Shoot();
        // �����̂悤�Ƀv���C���[�̈ʒu�𒲂�
        Vector2 playerVec = UnitVector(PlayerController.player);
        // �w��ɂ�����łĂȂ�
        if (playerVec.y > 0) return;
        // ����
        InstantiateBulletToAngle(bulletPrefab, playerVec);
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        gameObject.GetComponent<CircleCollider2D>().enabled = false; // �e�I�u�W�F�N�g�̃R���C�_�[���e���Ő؂邱�ƁB
    }
}