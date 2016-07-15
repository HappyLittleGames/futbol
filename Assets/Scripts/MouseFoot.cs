using UnityEngine;
using System.Collections;

public class MouseFoot : MonoBehaviour
{
    private Rigidbody2D m_rigidBody = null;
    private SpriteRenderer m_spriteRenderer = null;
    [SerializeField]
    private float m_power;

    void Start()
    {
        if (m_rigidBody == null)
        {
            m_rigidBody = gameObject.GetComponent<Rigidbody2D>();
        }
        if (m_spriteRenderer == null)
        {
            m_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }
    }

    void FixedUpdate()
    {
        if(Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), gameObject.transform.position) < m_spriteRenderer.bounds.extents.x)
        {

        }
    }
}
