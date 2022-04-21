using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
        public int currentDeathId = 0;
        public string[] inGameDialog = new string[7];
        public SaveData(int id)
        {
            currentDeathId = id;
            inGameDialog[0] = "Where am ý";
            inGameDialog[1] = "Noooo I'm stuck in time";
            inGameDialog[2] = "How did that trap not kill me?";
            inGameDialog[3] = "am i a soul";
            inGameDialog[4] = "please end this";
            inGameDialog[5] = "how the arrow bends me and time";
            inGameDialog[6] = "I don't remember this one anymore";
        }
}
