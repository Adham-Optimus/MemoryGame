using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XampleController : MonoBehaviour
{
    public const int gridRows = 3;
    public const int gridCols = 4;
    public const float offsetX = 3f;
    public const int offsetY = 3;

    [SerializeField] private XemoryCard originalCard;
    [SerializeField] private Sprite[] images;
    public static XampleController xample;
    private XemoryCard _firstRevealed;
    private XemoryCard _secondRevealed;
    [SerializeField]
    private TextMesh _scoreLabel;

    public int _score = 0;

    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }
    public void CardRevealed(XemoryCard card)// этот код присваивает карточке 1 или 2
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()// этот код (самый главный) проверяет равна ли первая карточка второй
    {
        if (_firstRevealed.id == _secondRevealed.id)
        {
            _score++;
            _scoreLabel.text = "Score: " + _score;
        }
        else
        {
            yield return new WaitForSeconds(.5f);
            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
        }
        _firstRevealed = null;
        _secondRevealed = null;
    }
    private void Start()// этот код просто расставляет карты и присваивает id 
    {
        xample = this;
        Vector3 startPos = originalCard.transform.position;

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
        numbers = ShuffleArray(numbers);

        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                XemoryCard card;
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard);
                }

                int index = j * gridCols + i;
                int id = numbers[index];
                card.SetCard(id, images[id]);

                float x = (offsetX * i) + startPos.x;
                float y = -(offsetY * j) + startPos.y;
                card.transform.position = new Vector3(x, y, startPos.z);
            }
        }
    }

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }
}
