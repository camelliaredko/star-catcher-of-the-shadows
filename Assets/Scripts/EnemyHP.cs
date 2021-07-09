using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{   
    public int enemyHP;
    private int currentHP;

    private Animator theAnim;
    private bool isDead;

    private Collider2D parentCol;
    private Collider2D hurtboxCol;

    [SerializeField]
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = enemyHP;
        theAnim = transform.parent.GetComponent<Animator>();
        parentCol = transform.parent.GetComponent<Collider2D>();
        hurtboxCol = GetComponent<Collider2D>();
    }

    public void SpawnEnemy() 
    {
        if(Random.Range(0f, 1f) < 0.25f) {
            bool enemySpawned = false;
            while (!enemySpawned)
            {
                Vector3 enemyPosition = new Vector3(Random.Range(-8f, 16f), Random.Range(25f, 28f), 0f);
                if((enemyPosition - GameObject.FindGameObjectWithTag("Player").transform.position).magnitude < 3)
                {
                    continue;
                }
                else
                {
                    Instantiate(enemy, enemyPosition, Quaternion.identity);
                    enemySpawned = true;
                }
            } 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHP <= 0)
        {
            isDead = true;
            theAnim.SetBool("Dead", isDead);
            parentCol.enabled = false;
            hurtboxCol.enabled = false;
            StartCoroutine("KillSwitch");
        }
    }
    
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
    }

    IEnumerator KillSwitch()
    {
        yield return new WaitForSeconds(3f); 
        SpawnEnemy();
        Destroy(transform.parent.gameObject);
    }
}
