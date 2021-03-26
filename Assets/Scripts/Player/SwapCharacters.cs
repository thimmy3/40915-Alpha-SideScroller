using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapCharacters : MonoBehaviour
{
    public GameObject[] characters;
    public Sprite[] characterSprites;
    public Button swapButton;

    int characterIndex;

    public void Swap()
    {
        if (characterIndex + 1 < characters.Length)
            characterIndex++;
        else
            characterIndex = 0;

        int spriteIndex;
        if (characterIndex + 1 < characters.Length)
            spriteIndex = characterIndex + 1;
        else
            spriteIndex = 0;

        swapButton.image.sprite = characterSprites[spriteIndex];

        for (int i = 0; i < characters.Length; i++)
        {
            if (i == characterIndex)
                characters[i].SetActive(true);
            else
                characters[i].SetActive(false);
        }
    }

}

