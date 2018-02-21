using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonBehavior : MonoBehaviour {
	public void LoadStage()  {
		SceneManager.LoadScene("game");
	}
	public void LoadStageAndLevelUp()  {
		SceneManager.LoadScene("game");
	}
}
