using UnityEngine;
using TMPro;

public class FlashingText : MonoBehaviour
{
    public TextMeshProUGUI tmpText;
    public Color color1;
    public Color color2;
    public float flashspeed = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.FloorToInt(Time.time * flashspeed) % 2 == 0)
        {
            tmpText.color = color1;
        }
        else
        {
            tmpText.color = color2;
        }
    }
}
