using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentsView : MonoBehaviour
{
    [SerializeField] Sprite[] Views;
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Views[Mathf.RoundToInt(transform.position.x) ];
    }
}
