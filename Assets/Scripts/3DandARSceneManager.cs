using UnityEngine;
using UnityEngine.SceneManagement;

public class _3DandARSceneManager: MonoBehaviour
{
    public void OpenScene ()
    {
        SceneManager.LoadSceneAsync("3DScene", LoadSceneMode.Additive);
    }
    public void CloseScene()
    {
        Scene mainScene = SceneManager.GetSceneByName("UIScene");
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene != mainScene)
            {
                SceneManager.UnloadSceneAsync(scene).completed += (op) =>
                {
                    Debug.Log($"{scene.name} ���������");
                };
            }
        }
    }
}
