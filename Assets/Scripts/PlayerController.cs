using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject mainUiCanvasObj;
    private MainUiCanvas mainUiCanvasScript;
    private Animator animator;
    private Rigidbody2D rb;
    public float speed = 5f;
    private bool isMoving;
    public bool isAttacking;
    public int enemiesKilled = 0;
    public int enemiesKilledScore = 0;
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public bool right = true;
    public IPlayerHandler playerDelegate;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        mainUiCanvasScript = mainUiCanvasObj.GetComponent<MainUiCanvas>();
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetBool("isAttacking", true);
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
        animator.SetBool("isAttacking", false);
    }

    IEnumerator KillEnemy(GameObject enemy)
    {
        Animator enemyAnimator = enemy.GetComponent<Animator>();
        enemyAnimator.SetBool("isAttacking", false);
        yield return new WaitForSeconds(0.5f);
        Destroy(enemy);
    }

    // Update is called once per frame
    void Update()
    {
        float axis = Input.GetAxis("Horizontal");
        float translation = axis * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("Attack");
        }
        else
        {
            if (axis == 1.0f && right == false)
            {
                right = true;
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }

            if (axis == -1.0f && right == true)
            {
                right = false;
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }

            ApplyMovement(translation);
        }
        
    }

    void ApplyMovement(float translation)
    {
        
        if (translation == 0)
        {
            animator.SetBool("isRunning", false);
            return;
        }
        
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);
        animator.SetBool("isRunning", true);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag.Equals("WALL"))
        {
            animator.SetBool("isRunning", false);
            isMoving = false;
            rb.velocity = Vector2.zero;
        }

        if (other.gameObject.tag == Tags.Enemy)
        {
            if (isAttacking)
            {
                StartCoroutine("KillEnemy", other.gameObject);
                //Destroy(other.gameObject);
                enemiesKilled++;
                enemiesKilledScore++;
                if (enemiesKilled == 2)
                {
                    enemiesKilled = 0;
                    Instantiate(enemyPrefab1, Vector3.zero, Quaternion.identity);
                    Instantiate(enemyPrefab2, Vector3.zero, Quaternion.identity);
                }
                mainUiCanvasScript.printScore(enemiesKilledScore * 10);
                mainUiCanvasScript.printEnemy(enemiesKilledScore);
            }
            else
            {
                Destroy(this.gameObject);
                SceneManager.LoadScene(SceneNames.MainMenuScene);
            }
        }

    }
}
