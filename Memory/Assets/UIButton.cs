using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    
    [SerializeField] private GameObject targetObject;
    [SerializeField] private string targetMessage;
    private int id;
    public bool isExit = false;
    public enum Scenes
    {
        Sample = 0,
        Xample = 1,
        Yample = 2
    }
    public Scenes scene = Scenes.Sample;
    SpriteRenderer sprite;
    public Sprite image;
    public Color highlightColor = Color.green;

    private void Start()
    {
        id = GetId();
        sprite = GetComponent<SpriteRenderer>();
    }

    
   
    private void FixedUpdate()
    {
        if (id == 0 && SceneController.sceneC._score == 4)
        {
            isExit = true;
        }
        else if (id == 1 && XampleController.xample._score == 6)
        {
            isExit = true;
        }
        else if (id == 2 && YampleController.yample._score == 9)
        {
            isExit = true;
        }
        if (isExit)
        {
            sprite.sprite = image;
            //sprite.sprite = Resources.Load<Sprite>("Assets/PNG/Cards/mustHave/exit.png");
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1.5f, 1.5f);
        }
    }
    private void OnMouseEnter()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = highlightColor;
        }
    }
    
    private void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = Color.white;
        }
    }
    private void OnMouseDown()
    {
        transform.localScale = new Vector3(2.1f, 2.1f, 1);   
    }

    private void OnMouseUp()
    {
        transform.localScale = new Vector3(2f, 2f, 1);
        if (isExit)
        {
            
            LoadScene();
        }
        else if (targetObject != null)
        {
            Restart();
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private int GetId()
    {
        return (int)scene;
    }
    void LoadScene()
    {
        switch(id)
        {
            case 0:SceneManager.LoadScene("Xample");break;
            case 1:SceneManager.LoadScene("Yample");break;
            case 2:SceneManager.LoadScene("Zample");break;
        }
    }
}
