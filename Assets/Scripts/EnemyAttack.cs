using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{

    bool attacking = false;
    float attackTime = 3f;
    float defendTime = 6f;
    [SerializeField] Sprite attackSprite;
    [SerializeField] Sprite defendSprite;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (attacking)
        {
            if (attackTime > 0)
            {
                GameManager.instance.UpdateGameText(false, (int)attackTime + 1);
                attackTime -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTime = 3f;
                spriteRenderer.sprite = defendSprite;
                GameManager.instance.UpdateGameText(true, (int)defendTime + 1);
            }
        }
        else
        {
            GameManager.instance.UpdateGameText(true, (int)defendTime + 1);

            if (defendTime > 0)
                defendTime -= Time.deltaTime;
            else
            {
                GameManager.instance.GameOver(attacking);
            }
        }

    }

    void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.transform.tag == "Player")
        {
            if (!attacking)
            {
                attacking = true;
                defendTime = 6f;
                spriteRenderer.sprite = attackSprite;
                GameManager.instance.UpdateGameText(false, (int)attackTime + 1);

            }
            else
            {
                GameManager.instance.GameOver(attacking);
            }
        }
    }
}
