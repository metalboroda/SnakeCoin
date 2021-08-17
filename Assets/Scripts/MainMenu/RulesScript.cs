using UnityEngine;

namespace MainMenu
{
    public class RulesScript : MonoBehaviour
    {
        public GameObject rulesPanel;

        public void OpenPanel()
        {
            if (rulesPanel != null)
            {
                rulesPanel.SetActive(true);
            }
        }

        public void ClosePanel()
        {
            rulesPanel.SetActive(false);
        }
    }
}