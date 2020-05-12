using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlockable : MonoBehaviour
{
    public static void UnlockThroughAd()
    {
        PlayerPrefsX.SetBool("Ship2Locked", false);
        SelectShipController.IsShip2Locked = PlayerPrefsX.GetBool("Ship2Locked");
        print("SHIP 2 UNLOCKED!!!");
    }

    public static void UnlockThroughScore() // CALL WHEN HIGHSCORE IS SET
    {
        foreach (int highScore in PlayerPrefsX.GetIntArray("HighScores"))
        {
            if (highScore >= 10000)
            {
                PlayerPrefsX.SetBool("Ship3Locked", false);
                SelectShipController.IsShip3Locked = PlayerPrefsX.GetBool("Ship3Locked");
                print("SHIP 3 UNLOCKED!!!");
                // TODO add ship unlocked message
                break;
            }
        }
    }
}
