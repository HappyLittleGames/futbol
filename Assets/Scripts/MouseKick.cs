using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseKick : MonoBehaviour {

    private Rigidbody2D m_rigidBody = null;
    private SpriteRenderer m_spriteRenderer = null;
    [SerializeField] private float m_power;
    [SerializeField] float m_checkTime = 0.1f;
    private float m_cooldown = 0;
    private Vector2 m_lastPoint = Vector2.zero;
    private List<Vector2> m_track;

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

    void Update()
    {
        float legPower = PowerState();
        if (Input.GetMouseButton(0))
        {
            Vector2 ballPos = gameObject.transform.position;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

             if (Vector2.Distance(mousePos, ballPos) < 1)
            {
                Debug.Log("MousePos X: " + mousePos.x + " MousePos Y: " + mousePos.y);
                Debug.Log("BallPos X: " + gameObject.transform.position.x + " BallPos Y: " + gameObject.transform.position.y);

                Vector2 direction = ballPos - mousePos;
                m_rigidBody.AddForce(direction * m_power * legPower); // legpower needs a nice curve..
            }
        }
    }

    float PowerState()
    {
        float power = 0;
        if(Input.GetMouseButton(0))
        {
            power = Vector2.Distance(m_lastPoint, Input.mousePosition);
            Debug.Log("Power: " + power);

            m_lastPoint = Input.mousePosition;
        }
        if(m_lastPoint == Vector2.zero)
        {
            return 0;
        }
        else
        {
            return power;
        }
    }
}