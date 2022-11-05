using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Apple_item : MonoBehaviour
{
    private int apples = 0;
    [SerializeField] private TextMeshProUGUI appleText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("apple"))
        {
            Destroy(collision.gameObject);
            apples++;
            appleText.text = "apple: " + apples;
        }
    }
}
