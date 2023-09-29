using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] private int PowerUpCounts;
    [SerializeField] private GameObject Shield;
    [SerializeField] private TextMeshProUGUI PowerDisplay;
    private bool isShielding;
    private SpriteRenderer rend;
    [SerializeField] private int NumberOfBlink;
    [SerializeField] private float m_iFramesDuration;

    private void Awake()
    {
        PowerUpCounts = 0;
        isShielding = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shield"))
        {
            Destroy(collision.gameObject);
            PowerUpCounts++;
        }
    }

    private void Update()
    {
        PowerDisplay.text = "X " + PowerUpCounts.ToString();

        if (Input.GetKeyDown(KeyCode.B) && PowerUpCounts > 0 && !isShielding)
        {
            StartCoroutine(UsePower());
            
        }
    }

    private IEnumerator UsePower()
    {
        isShielding = true;
        PowerUpCounts--;
        Shield.SetActive(true);
        rend = Shield.GetComponent<SpriteRenderer>();
        Physics2D.IgnoreLayerCollision(6, 7, true);
        yield return new WaitForSeconds(7f);
        for (int i = 0; i < NumberOfBlink; i++)
        {
            rend.color = new Color(1, 1, 1, 0.2f);
            yield return new WaitForSeconds(m_iFramesDuration / (NumberOfBlink));
            rend.color = Color.white;
            yield return new WaitForSeconds(m_iFramesDuration / (NumberOfBlink));
        }
        Shield.SetActive(false);
        Physics2D.IgnoreLayerCollision(6, 7, false);
        isShielding = false;
    }
}
