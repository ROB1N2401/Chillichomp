using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int spiciness_;
    public int points_;

    [SerializeField] private float speed_ = 10.0f;
    //[SerializeField] private List<Sprite> allSprites_;
    [SerializeField] private GameObject destroyPos_;
    private Rigidbody2D rb2D_;
   
    // Use this for initialization
    void Start()
    {
        //SpriteRenderer sr = GetComponent<SpriteRenderer>();
        //if (sr) sr.sprite = allSprites_[Random.Range(0, allSprites_.Count)];

        rb2D_ = this.GetComponent<Rigidbody2D>();
        rb2D_.velocity = new Vector2(0, speed_);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > destroyPos_.transform.position.y)
        {
            Destroy(this.gameObject);

            FoodInteraction c = FindObjectOfType<FoodInteraction>();
            c.inZone_ = false;
        }
    }

}
