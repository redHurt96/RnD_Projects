using RH.Utilities.UI;
using UnityEngine.SceneManagement;

namespace NonEcsComparisonExample.UI
{
    public class ChangeSceneButton : BaseActionButton
    {
        public int Scene;
        
        protected override void PerformOnClick() => 
            SceneManager.LoadScene(Scene);
    }
}