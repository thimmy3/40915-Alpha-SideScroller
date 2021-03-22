using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public Color hoverColor;

    private GameObject exit;

    private Renderer rend;
    private Color startColor;

    void Start ()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }



    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
