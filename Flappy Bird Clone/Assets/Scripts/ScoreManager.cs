using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // The player score.
    // { get; private set; } means that it can be read by other classes, but not set (it becomes read only).
    public int score {get; private set;}
    
    // An array for the number sprites.
    public Sprite[] numSprites;

    // An Array for the number images.
    public Image[] numImages;

    public void AddScore()
    {
        // ++score incriments the number before printing it.
        if (++score > 999)
        {
            score = 999;
        }
        DrawScore();
    }
    
    public void DrawScore()
    {
        // Seperate the numbers into characters
        // Reverse() will reverse the characters
        // ToArray() will give back the characters as an array.
        char[] nums = score.ToString().ToCharArray().Reverse().ToArray();

        // Loop through the numbers and draw the sprite
        for (int i = 0; i < numImages.Length; i++)
        {
            if ( nums.Length > i)
            {
                // Convert that character into an integer.
                int num = int.Parse(nums[i].ToString());

                /* 
                    i = matches the image index for the score
                    num = matches the sprite we should display
                */
                numImages[i].sprite=numSprites[num];
            }
        }
    }
}
