

using UnityEngine;

namespace MainMenu
{
    public class MenuPanel : MonoBehaviour
    {

        public void OnClickPlay()
        {
            UIManager.Instance.GameModePanel.Show();
        }

        public void OnClickExit()
        {

        }
        public void GoScene(string names)
        {
            MyLevelManager.Instance.GoScene(names);
        }
    }
}