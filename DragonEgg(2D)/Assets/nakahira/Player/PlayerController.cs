using System.Collections;
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

    private HPUIController hpText;

    private Shooter playerShooter;
    private Shooter rightShooter;
    private Shooter leftShooter;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject; // ����Ōl�����J�ł��邩��
        cameraComponent = Camera.main; // �J�����R���|�[�l���g�擾
        animator = GetComponent<Animator>();
        SetStatusFromData();
        fadePanel = GameObject.Find("FadePanel");
        hpText = GameObject.Find("HP").GetComponent<HPUIController>();
        hpText.DispHp(hitPoint);
        // 
        playerShooter = GetComponent<Shooter>();
        rightShooter = transform.GetChild(0).GetComponent<Shooter>();
        leftShooter = transform.GetChild(1).GetComponent<Shooter>();
    }

    private void SetStatusFromData()
    {
        // Start����PlayerPrefs����U���͂��Q��
        // �����f�[�^��������Ȃ������珉���l�Ƃ���1���Z�[�u�@
        playerAttack = PlayerPrefs.GetInt("Attack", 0);
        if (playerAttack == 0)
        {
            playerAttack = 1;
            PlayerPrefs.SetInt("Attack", 1);
            PlayerPrefs.Save();
        }
        hitPoint = 50; // ���e�����p���`
        speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        // ���X�e�B�b�N
        // Horizontal ��
        // Vertical �@�c
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
        AudioSource.PlayClipAtPoint(audioClip, transform.position);

        DamageNumberGenerator.GenerateText(attack, transform.position, Color.red);
        hitPoint -= attack;
        if (hitPoint > 0) // �����Ă�����
        {
            StartCoroutine(Blinking(4, 0.05f)); // �_��
            hpText.DispHp(hitPoint); // HP�̌����𔽉f
        }
        else // �łȂ����
        {
            animator.SetTrigger("Death"); // ���b���[�V�������Đ�
            hpText.DispHp(0);
            // �v���C���[�ƃR�h���h���S���ɂ��Ă���R���|�[�l���g���擾����
            // �e���������Ȃ��悤�ɂ�����
            playerShooter.SetCanShoot(false);
            if (rightShooter != null) rightShooter.SetCanShoot(false);
            if (leftShooter != null) leftShooter.SetCanShoot(false);
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
