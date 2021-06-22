using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public Text levelCleared;
    public Text levelClearedShadow;
    public GameObject transitionScene;
    public Text totalFruits;
    public Text catchFruits;
    private int totalFruitsInLevel;


    public void Start()

    {
        totalFruitsInLevel = transform.childCount;
    }

    public void Update()
    {
        AllFruitsCollected();
        totalFruits.text = totalFruitsInLevel.ToString();
        catchFruits.text = transform.childCount.ToString();
    }

    public void AllFruitsCollected()
    {
        if (transform.childCount==0)
        {
            levelCleared.gameObject.SetActive(true);
            levelClearedShadow.gameObject.SetActive(true);
            transitionScene.SetActive(true);
            PlayerPrefs.DeleteAll();
            Invoke("ChangeScene", 2); 
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
