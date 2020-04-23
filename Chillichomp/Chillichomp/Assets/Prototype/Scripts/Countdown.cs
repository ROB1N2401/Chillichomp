using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;


public class Countdown : MonoBehaviour
{
    public float startingTime_ = 5.5f;
    public TextMeshProUGUI text_;
    public GameObject victory_;

    [SerializeField] private UnityEvent disableControls_;
    private bool instantiate_victory_condition_ = true;

    // Start is called before the first frame update
    void Start()
    {
        text_.text = startingTime_.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (startingTime_ > 0)
        {
            startingTime_ -= Time.deltaTime;
            //Debug.Log(startingTime_);
        }

        text_.text = Mathf.Round(startingTime_).ToString();

        if (startingTime_ <= 0)
        {
            if (instantiate_victory_condition_ == true)
            { 
                GameObject f = Instantiate(victory_) as GameObject;
                f.transform.position = Camera.main.transform.position;
                instantiate_victory_condition_ = false;
            }

            disableControls_.Invoke();

            StartCoroutine(RestartGame());
        }
    }

    IEnumerator RestartGame()
    {
        //yield return new WaitForSeconds(0.1f);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("PrototypeScene");
    }
}
