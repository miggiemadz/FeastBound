using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameManager : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Transform textPosition;
    private Weapon weaponScript;
    private Item itemScript;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        weaponScript = GetComponentInParent<Weapon>();
        itemScript = GetComponentInParent<Item>();
        textPosition = transform.parent.GetChild(1).transform;
    }

    private void Update()
    {
        text.transform.position = textPosition.position;

        if ( weaponScript != null)
        {
            if (weaponScript.IsCollected )
            {
                Destroy(text);
            }
        }
        if ( itemScript != null )
        {
            if ( itemScript.IsCollected )
            {
                Destroy(text);
            }
        }
    }
}
