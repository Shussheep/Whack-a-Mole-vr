using UnityEngine;

public class Mole : MonoBehaviour
{
    [SerializeField] private int minTime = 2;
    [SerializeField] private int maxTime = 10;
    [SerializeField] private float popOffSet = 0.1f;
    [SerializeField] private int score = 10; 
    [SerializeField] private ScoreText scoreText;
   // [SerializeField] private 


    private bool isUp = false;
    float popTime = 0;
    float popFailTime = 0; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        popTime = Random.Range(minTime * 60,maxTime * 60) + 60 * 10;
    }

    // Update is called once per frame
    

    private void FixedUpdate()
    {
        if (!isUp)
        {
            Debug.Log(popTime);
            popTime--;
            if (popTime == 0)
            {
                isUp = true;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, (float)(gameObject.transform.position.y + popOffSet), gameObject.transform.position.z);
                popFailTime = Random.Range(minTime * 60, maxTime * 60);
            }

        }
        else 
        {
            popFailTime--;
            if (popFailTime == 0) 
            {
                isUp = false;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, (float)(gameObject.transform.position.y - popOffSet), gameObject.transform.position.z);
                popTime = Random.Range(minTime * 60, maxTime * 60);
                scoreText.increaseScore(score * -2);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "stick")
        {
            if (isUp)
            {
                isUp = false;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, (float)(gameObject.transform.position.y - popOffSet), gameObject.transform.position.z);
                popTime = Random.Range(minTime * 60, maxTime * 60);
                scoreText.increaseScore(score);
                GetComponent<AudioSource>().Play();
            }
        }
    }
}


 
