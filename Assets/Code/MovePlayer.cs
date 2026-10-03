using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    private ControlPlayer controlPlayer;
    private Vector2 movimiento;
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] private float velocidad = 5f;
    public bool enPiso = false;

    void Awake()
    {
        controlPlayer = new ControlPlayer();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Lee las teclas configuradas en ControlPlayer.inputactions
        movimiento = controlPlayer.Player.Move.ReadValue<Vector2>();

        CambiaEstado();
    }

    void FixedUpdate()
    {
        rb.velocity = movimiento * velocidad;
    }

    private void CambiaEstado()
    {
        if (movimiento.x > 0)
        {
            animator.SetInteger("PlayerEstado", 1);
        }
        else if (movimiento.x < 0)
        {
            animator.SetInteger("PlayerEstado", 2);
        }
        else if (movimiento.y > 0)
        {
            animator.SetInteger("PlayerEstado", 3);
        }
        else if (movimiento.y < 0)
        {
            animator.SetInteger("PlayerEstado", 4);
        }
    }

    void OnEnable()
    {
        controlPlayer.Enable();
        controlPlayer.Player.saltar.performed += OnSaltar;
    }

    void OnDisable()
    {
        controlPlayer.Disable();
        controlPlayer.Player.saltar.performed -= OnSaltar;
    }

    private void OnSaltar(InputAction.CallbackContext context)
    {
        if(ColisionadorPlayer.enPiso)
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            enPiso = false;
        }
    }
}
