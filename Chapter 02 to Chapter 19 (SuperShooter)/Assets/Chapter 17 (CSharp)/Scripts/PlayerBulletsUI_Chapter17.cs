using TMPro;
using UnityEngine;

public class PlayerBulletsUI_Chapter17 : MonoBehaviour
{
    TMP_Text text;

    public PlayerShooting_Chapter17 targetShooting;

    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        text.text = "Bullets: " + targetShooting.bulletsAmount;
    }
}

