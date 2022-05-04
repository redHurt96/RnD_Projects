using UnityEngine;
using UnityEngine.SceneManagement;

namespace EcsComparison
{
    public class Bootstrapper : MonoBehaviour
    {
        private void Start() => 
            SceneManager.LoadScene(1);
    }
}
