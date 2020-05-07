using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Food : ScriptableObject
{
    public enum FoodType
    {
        Mild,
        Medium,
        Hot
    }

    FoodMovement foodMovement_;

    public FoodType foodType_;
    public string name_;
    public Sprite sprite_;
    public int spiciness_;
    public int score_;

    public Food()
    {
        spiciness_ = 0;
        score_ = 0;
    }
}

[CreateAssetMenu(menuName = "Food/Hot")]
public class Hot : Food
{
    public Hot()
    {
        spiciness_ = 5;
        score_ = 5;
        foodType_ = FoodType.Hot;
    }
}

[CreateAssetMenu(menuName = "Food/Medium")]
public class Medium : Food
{
    public Medium()
    {
        spiciness_ = 3;
        score_ = 3;
        foodType_ = FoodType.Medium;
    }
}

[CreateAssetMenu(menuName = "Food/Mild")]
public class Mild : Food
{
    public Mild()
    {
        spiciness_ = 1;
        score_ = 1;
        foodType_ = FoodType.Mild;
    }
}

