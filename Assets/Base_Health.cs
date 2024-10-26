using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using System.Collections;
using UnityEngine.SceneManagement;

public class Base_Health : MonoBehaviour
{
    [SerializeField] public int health;
    private Label Health_Label;
    private Label Lose_Label;
    private Label Label_label;
    private void Start()
    {
        var ui_document=GetComponentInChildren<UIDocument>();
        var root=ui_document.rootVisualElement;

        Health_Label = root.Q<Label>("HealthLabel");
        Lose_Label = root.Q<Label>("LoseLabel");
        Label_label =root.Q<Label>("Label");

        // Hide the lose label initially
        Lose_Label.style.display = DisplayStyle.None;

        Update_Ui(health);
    }
     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health--;

            Update_Ui(health);

            if (health <= 0)
            {
                Lose_State();
            }
            Debug.Log("Collided");
        }
        Debug.Log("collided");
    }

    private void Update_Ui(int currenthealth)
    {

        Health_Label.text = currenthealth.ToString();
    }

    void Lose_State()
    {
        Lose_Label.style.display = DisplayStyle.Flex;
        Health_Label.style.display = DisplayStyle.None;
        Label_label.style.display = DisplayStyle.None;
        StartCoroutine(ExitPlayMode());
    }
    IEnumerator ExitPlayMode()
    {
        yield return new WaitForSeconds(2);
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
