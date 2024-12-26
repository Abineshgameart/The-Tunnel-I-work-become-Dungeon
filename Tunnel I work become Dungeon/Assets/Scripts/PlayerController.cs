using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlayerController : MonoBehaviour
{
    // Private
    [SerializeField] private InputActionReference moveActionToUse;
    [SerializeField] private float speed;
    Animator anim;
    Rigidbody2D rb;

    // Public



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movements();
    }

    private void Movements()
    {
        Vector2 moveDirection = moveActionToUse.action.ReadValue<Vector2>();
        transform.Translate(moveDirection * speed * Time.deltaTime);
        if (moveDirection.x != 0)
        {
            Flipping(moveDirection.x);
        }
        
        // Animations
        anim.SetFloat("xVal", moveDirection.x);
    }

    private void Flipping(float moveDir)
    {
        if (moveDir < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveDir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

}
