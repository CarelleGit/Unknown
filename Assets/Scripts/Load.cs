using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Load : MonoBehaviour {

	public void Level(int idx)
    {
        SceneManager.LoadScene(idx);
    }
}
