using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FavoriteCategory : MonoBehaviour
{
    public VideoCategory favoriteCategory;

    // Start is called before the first frame update
    void Start()
    {
        // Get all values of the VideoCategory enum
        Array values = Enum.GetValues(typeof(VideoCategory));

        // Select a random index
        int randomIndex = UnityEngine.Random.Range(0, values.Length);

        // Assign a random value from the VideoCategory enum
        favoriteCategory = (VideoCategory)values.GetValue(randomIndex);

        Debug.Log("Right favorite:" + favoriteCategory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
