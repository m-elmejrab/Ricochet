using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour {

    bool attacking = false;
    float attackTime = 3f;
    float defendTime = 6f;
    public Sprite attackSprite;
    public Sprite defendSprite;
    SpriteRenderer spriteRenderer;
    public Text mainGameText;

    void Awake () {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(attacking)
        {
            if (attackTime > 0)
            {
                mainGameText.text = "Run for " + ((int)attackTime +1) + " Seconds";
                attackTime -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTime = 3f;
                spriteRenderer.sprite = defendSprite;
                mainGameText.text = "Hit within " + ((int)defendTime+1) + " Seconds";
            }
        }
        else
        {
            mainGameText.text = "Hit within " + ((int)defendTime + 1) + " Seconds";

            if (defendTime>0)
                defendTime -= Time.deltaTime;
            else
            {
                GameManager.instance.GameOver(attacking);
            }
        }
		
	}

    void OnCollisionEnter2D (Collision2D colInfo)
    {
        if (colInfo.transform.tag == "Player")
        {
            if(!attacking)
            {
                attacking = true;
                defendTime = 6f;
                spriteRenderer.sprite = attackSprite;
                mainGameText.text = "Run before " + ((int)attackTime+1) + " Seconds";

            }
            else
            { 
                GameManager.instance.GameOver(attacking);
            }
        }  
    }
}
