using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControler : MonoBehaviour
{
    [SerializeField] private float moventSpeed;
    [SerializeField] private float jumpForece;
    [Space]
    [SerializeField] private LayerMask groundLayerMask;
    [field: SerializeField] public Color accentColor { get; private set; }
    [SerializeField] private Color defaultColor;


    private Rigidbody2D rb;
    private bool isGround;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            Move(horizontalInput * moventSpeed);

        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
        }
    }
    private void Move(float moveSpeed)
    {
        rb.AddForce(new Vector2(moveSpeed, 0));
    }
    private void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForece),ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMaskUtil.LayerMaskContatinsLayer(groundLayerMask, collision.gameObject.layer))
        {
            isGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (LayerMaskUtil.LayerMaskContatinsLayer(groundLayerMask, collision.gameObject.layer))
        {
            isGround = false;
            ColorTile(collision.gameObject.GetComponent<SpriteRenderer>());
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (LayerMaskUtil.LayerMaskContatinsLayer(groundLayerMask, collision.gameObject.layer))
        {
            isGround = true;
        }
    }
    private void ColorTile(SpriteRenderer spriteRenderer)
    {
        if(spriteRenderer.color == defaultColor)
        {
            spriteRenderer.color = accentColor;
        }
        else
        {
            spriteRenderer.color = defaultColor;
        }
        //spriteRenderer.color = spriteRenderer.color == defaultColor) ?? accentColor : defaultColor;
    }
}
