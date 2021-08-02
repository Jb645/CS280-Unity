using UnityEngine;
using UnityEngine.SceneManagement;

namespace eradication
{
    public class SceneUpdateManager : MonoBehaviour
    {
   
        public void ChangeScene(int desiredStage)
        {
            if(desiredStage>SceneManager.sceneCountInBuildSettings){
                Debug.LogError($"<color=RED>Unknown Stage: {desiredStage}</color>");
                return;
            } 
            SceneManager.LoadScene(desiredStage);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

    }
}
