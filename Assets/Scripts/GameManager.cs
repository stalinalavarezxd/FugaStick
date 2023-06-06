using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menuPrincipal;
    public GameObject menuGameOver;
   
    public float speed = 4;
    public GameObject colum;
    public Renderer background;
    public GameObject piedra1;
    public GameObject piedra2;
    public GameObject caja;
    public GameObject buzon;
    public GameObject nube;
    public List<GameObject> columList;
    public List<GameObject> obstaculos;
    public List<GameObject> obstaculos2;
    public bool gameOver = false;
    
    public bool start = false;
    private int score = 0;
    private void OnEnable()
    {
        CoinController.OnCoinCollected += IncreaseScore;
    }
    private void OnDisable()
    {
        CoinController.OnCoinCollected -= IncreaseScore;
    }

    private void IncreaseScore()
    {
        score++;
        Debug.Log("Score: " + score);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 21; i++)
        {
            columList.Add(Instantiate(colum, new Vector2(-8 + i, -3), Quaternion.identity));
        }
        //Crear piedras 
        obstaculos.Add(Instantiate(piedra1, new Vector2(14, -2), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra2, new Vector2(18, -2), Quaternion.identity));
        //Crear obstaculos adicionales
        obstaculos.Add(Instantiate(caja, new Vector2(6, -2), Quaternion.identity));
        obstaculos.Add(Instantiate(buzon, new Vector2(10, -2), Quaternion.identity));
        //Crear nubes 
        obstaculos2.Add(Instantiate(nube, new Vector2(10, 4), Quaternion.identity));
        obstaculos2.Add(Instantiate(nube, new Vector2(14, 4), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {

        if (start == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }

        if (start == true && gameOver == true)
        {
            menuGameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (start == true && gameOver == false)
        {
            menuPrincipal.SetActive(false);
            background.material.mainTextureOffset += new Vector2(0.03f, 0) * Time.deltaTime;

            for (int i = 0; i < columList.Count; i++)
            {
                if (columList[i].transform.position.x <= -10)
                {
                    columList[i].transform.position = new Vector3(10, -3, 0);
                }
                columList[i].transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
            }
            //mover obstaculos 

            for (int i = 0; i < obstaculos.Count; i++)
            {
                if (obstaculos[i].transform.position.x <= -10)
                {
                    float randomObs = Random.Range(8, 18);
                    obstaculos[i].transform.position = new Vector3(randomObs, -2, 0);
                }
                obstaculos[i].transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
            }

            for (int i = 0; i < obstaculos2.Count; i++)
            {
                if (obstaculos2[i].transform.position.x <= -10)
                {
                    float randomObs = Random.Range(3, 6);
                    obstaculos2[i].transform.position = new Vector3(randomObs,4, 0);
                }
                obstaculos2[i].transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
            }
        }
    }
}
