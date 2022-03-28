using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XemoryCard : MonoBehaviour
{
    private AudioSource audio;
    [SerializeField]
    private GameObject cardBack;
    [SerializeField]
    private XampleController scene;
    private int _id;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public int id
    {
        get { return _id; }
    }
    private void OnMouseDown()
    {
        if (cardBack.activeSelf && scene.canReveal)
        {
            cardBack.SetActive(false);
            scene.CardRevealed(this);
        }
        audio.Play();
    }
    public void Unreveal()
    {
        cardBack.SetActive(true);
    }
    public void SetCard(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }
}
