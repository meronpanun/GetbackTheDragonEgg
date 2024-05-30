using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : PlayerBullet
{
    private float FIREATTACK = 1f;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        attack = FIREATTACK;
        bulletSpeedx = Random.Range(-1f, 1f); // ‚Î‚ç‚Â‚©‚¹‚é
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        // ­‚µ‚¸‚ÂŒ¸‘¬‚·‚é
        bulletSpeedx *= 0.99f;
        bulletSpeedy *= 0.99f;

        // ‘¬“x‚ªˆê’èˆÈ‰º‚É‚È‚Á‚Ä‚àÁ‚·
        if (bulletSpeedy < 0.8f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("’Ê‚Á‚½");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
