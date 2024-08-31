using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace ClearSky
{
    public class PlayerController : MonoBehaviour
    {
        public GameController gameController;
        public GameObject ballPrefab;
        private bool isPaused = false;
        private float movePower = 10f;
        private float jumpPower = 30f; //Set Gravity Scale in Rigidbody2D Component to 5

        private Rigidbody2D rb;
        private Animator anim;
        private int direction = 1;        
        private bool alive = true;
        private Vector3 cameraOffset; // 相机与角色的偏移量
        private Vector3 initialPosition; // 角色的初始位置
        private float timer; // 1-1.3计时
        private float waittime = 1.3f;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            // 计算相机与角色之间的初始偏移量
            cameraOffset = Camera.main.transform.position - transform.position;
            // 保存角色的初始位置
            initialPosition = transform.position;
            gameController.GetInitialPosition(initialPosition, Camera.main.transform.position);
        }

        private void Update()
        {
            if (alive && !isPaused)
            {
                Attack();
                Jump();
                Run();
                if (timer > 0.5f)
                {
                    timer += Time.deltaTime;
                    if (timer > waittime)
                    {
                        timer = 0f;
                        Vector3 positionTmp = new Vector3(transform.position.x + direction * 3f, transform.position.y + 2f, 0);
                        // 实例化小球预制体
                        GameObject gameObject = Instantiate(ballPrefab, positionTmp, Quaternion.identity);
                        BallController ballController = gameObject.transform.GetComponent<BallController>();
                        ballController.SetDirection(direction);
                    }
                }
            }
            if (isPaused)
            {
                timer = 0f;
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Ground")
            {
                anim.SetBool("isJump", false);
            }
            if (other.tag == "Die")
            {
                gameController.ToggleCanva(false);
            }
        }


        void Run()
        {
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isRun", false);


            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                direction = -1;
                moveVelocity = Vector3.left;
                
                // 检查角色是否已经到达或越过初始位置的左侧
                if (transform.position.x <= initialPosition.x)
                {
                    moveVelocity = Vector3.zero;
                }
                
                transform.localScale = new Vector3(direction, 1, 1);
                
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);

            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = 1;
                moveVelocity = Vector3.right;

                transform.localScale = new Vector3(direction, 1, 1);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);

            }
            transform.position += moveVelocity * movePower * Time.deltaTime;

            // 更新相机的位置，仅在水平移动时
            Vector3 cameraPosition = Camera.main.transform.position;
            cameraPosition.x = transform.position.x + cameraOffset.x;
            Camera.main.transform.position = cameraPosition;
        }
        void Jump()
        {
            if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0)
            && !anim.GetBool("isJump"))
            {
                anim.SetBool("isJump", true);
                rb.velocity = Vector2.zero;

                Vector2 jumpVelocity = new Vector2(0, jumpPower);
                rb.AddForce(jumpVelocity, ForceMode2D.Impulse);
            }       
        }
        void Attack()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                anim.SetTrigger("attack");

                timer = 1.0f;
            }
        }
        void Hurt()
        {
            anim.SetTrigger("hurt");
            if (direction == 1)
                rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
            else
                rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
        }
        void Die()
        {
            anim.SetTrigger("die");
            alive = false;
        }
        public void Restart()
        {
            anim.SetTrigger("idle");
            anim.SetTrigger("restart");
            alive = true;
        }
        public void SetPaused(bool flag)
        {
            isPaused = flag;
        }
    }
}