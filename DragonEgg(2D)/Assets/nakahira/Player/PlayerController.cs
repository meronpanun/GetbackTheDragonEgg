using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static GameObject player;

    private float speed = 1f;
    private int hitPoint = 10;

    private Camera cameraComponent;

    // �r���[�|�[�g�̕␳���`
    private float viewOffsetRight = 0.38f;
    private float viewOffset = 0.1f;

    private Animator animator; // �����̃A�j���[�^�[�R���|�[�l���g

    [SerializeField] // Resourse�t�@�C�����S�~���~�ɂȂ肻���Ȃ̂ŃA�E�g���b�g�ڑ�
    private AudioClip audioClip;

    private GameObject fadePanel;

    public static int playerAttack; // �U����

    private TextMeshProUGUI hpText;

    private Shooter playerShooter;
    private GameObject rightShooter;
    private GameObject leftShooter;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject; // ����Ōl�����J�ł��邩��
        cameraComponent = Camera.main; // �J�����R���|�[�l���g�擾
        animator = GetComponent<Animator>();
        SetStatusFromData();
        fadePanel = GameObject.Find("FadePanel");
        hpText = GameObject.Find("HP").GetComponent<TextMeshProUGUI>();
        hpText.text = hitPoint.ToString(); // �X�N���v�g���삾��Null�邩�璼�ڑ��삵���Ȃ����ă}?
        // 
        playerShooter = GetComponent<Shooter>();
        leftShooter = transform.GetChild(0).gameObject;
        // �����ŏ���Shooter���擾���銴������������
        // �Ȃ����擾�ł��Ȃ������̂Ŏ��񂾂Ƃ��Ɏ擾����
        rightShooter = transform.GetChild(1).gameObject;
    }

    private void SetStatusFromData()
    {
        // ���݂̃X�e�[�W�N���A�󋵂��L�^���Ă���"Progress"����
        // ���̃X�e�[�^�X�����߂�
        int saveData = PlayerPrefs.GetInt("Progress", 0);�@
        switch (saveData)
        {
            case 0:
                hitPoint = 50; // ���e�����p���`
                speed = 2;
                playerAttack = 1;
                break;
            case 1:
                hitPoint = 75;
                speed = 3;
                playerAttack = 3;
                break;
            case 2:
                hitPoint = 100;
                speed = 3;
                playerAttack = 6;
                break;
            case 3:
                hitPoint = 125;
                speed = 3.5f;
                playerAttack = 10;
                break;
            case 4:
                hitPoint = 150;
                speed = 4;
                playerAttack = 12;
                break;
            default:
                hitPoint = 999;
                speed = 8;
                playerAttack = 114514;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //���X�e�B�b�N
        Vector2 speedVec = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //Debug.Log("H" + Input.GetAxis("Horizontal"));
        //Debug.Log("V" + Input.GetAxis("Vertical"));

        //Debug.Log($"{speedVec}, {fadeSpeed}");

        if (hitPoint <= 0) // ���񂾂�
        {
            // �J�����Ɏ��c����銴���Őe����
            transform.parent = null;
        }
        else
        {
            Move(speedVec, speed);
        }
    }

    private void Move(Vector2 speedVec, float speed) // �ړ��\����Ƃ����l�ߍ���
    {
        // �܂��P�ʃx�N�g����
        Vector2 generalVec = speedVec.normalized;
        // �֐��ŕ�����g���`��ϐ��Ƃ��Đ錾
        float speedX = generalVec.x * speed * Time.deltaTime;
        float speedY = generalVec.y * speed * Time.deltaTime;
        // �����̍��W���J��������o�Ȃ��悤�ɐ���
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);

        // �z������i�߂Ȃ�
        // �E�����ɂ�UI������̂Œǉ��ŕ␳����
        if (viewPos.x + viewOffsetRight < 1.0f && speedX > 0)
        {
            transform.Translate(speedX, 0f, 0f);
        }
        if (viewPos.x - viewOffset > 0f && speedX < 0)
        {
            transform.Translate(speedX, 0f, 0f);
        }
        if (viewPos.y + viewOffset < 1.0f && speedY > 0)
        {
            transform.Translate(0f, speedY, 0f);
        }
        if (viewPos.y - viewOffset > 0f && speedY < 0)
        {
            transform.Translate(0f, speedY, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject temp = collision.gameObject;
        if (temp.CompareTag("Enemy") || temp.CompareTag("Boss")) // �G�ɓ���������
        {
            Damage(collision.GetComponent<Enemy>().attack);
        }
        else if (temp.CompareTag("EnemyBullet"))
        {
            Damage(collision.GetComponent<EnemyBullet>().attack);
        }
    }

    private void Damage(int attack) // hitPoint�͂������猸�炷����
    {
        GameAudio.InstantiateSE(audioClip);

        DamageNumberGenerator.GenerateText(attack, transform.position, Color.red);
        hitPoint -= attack;
        if (hitPoint > 0) // �����Ă�����
        {
            StartCoroutine(Blinking(4, 0.05f)); // �_��
            hpText.text = hitPoint.ToString(); // HP�̌����𔽉f
        }
        else // �łȂ����
        {
            animator.SetTrigger("Death"); // ���b���[�V�������Đ�
            hpText.text = "0";
            // �v���C���[�ƃR�h���h���S���ɂ��Ă���R���|�[�l���g���擾����
            // �e���������Ȃ��悤�ɂ�����
            playerShooter.SetCanShoot(false);
            if (rightShooter.GetComponent<Shooter>() != null) rightShooter.GetComponent<Shooter>().SetCanShoot(false);
            if (leftShooter.GetComponent<Shooter>() != null) leftShooter.GetComponent<Shooter>().SetCanShoot(false);
        }
    }

    IEnumerator Blinking(int count, float interval) // interval�͕b�P��
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color visibleColor = new Color(255, 255, 255, 255);
        Color invisibleColor = new Color(255, 255, 255, 0);
        for (int i = 0; i < count; i++) // count��J��Ԃ�
        {
            spriteRenderer.color = invisibleColor;
            yield return new WaitForSeconds(interval); // interval�b�҂�
            spriteRenderer.color = visibleColor;
            yield return new WaitForSeconds(interval); // ����Ȃ���Ł@�ǂ��ł��傤
        }
    }

    // ���S���̏��� �A�j���[�V�����Ŏ��s���Ă���
    public void Death()
    {
        fadePanel.GetComponent<FadeManager>().FadeOutSwitch(12);
    }
}
