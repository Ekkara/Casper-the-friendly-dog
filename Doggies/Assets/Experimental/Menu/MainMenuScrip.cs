using UnityEngine;

public class MainMenuScrip : MonoBehaviour
{
    public int currentOption = 0;
    public int oldOption = 0;
    [SerializeField]
    MenuOptionscript[] menuOptions;

    [SerializeField]
    Color selectedImageColor, deselectedImageColor,
        selectedTextColor, deselectedTextColor;

    private void Start() {
        //ensure all elemen is in right color
        for(int i = 0; i < menuOptions.Length; i++) {
            menuOptions[i].UpdateColors(deselectedTextColor, deselectedImageColor);
        }
        menuOptions[currentOption].UpdateColors(selectedTextColor, selectedImageColor);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.W)) {
            currentOption--;
            UpdateMenu();
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            currentOption++;
            UpdateMenu();
        }
        if (Input.GetKeyDown(KeyCode.E) ||
            Input.GetMouseButtonDown(0)) {
            menuOptions[currentOption].OptionSelected();
        }
    }

    public void ChangeOptionTo(int index) {
        currentOption = index;
        UpdateMenu();
    }

    void UpdateMenu() {
        currentOption = GetMenuFormatedPointer(currentOption);

        menuOptions[oldOption].UpdateColors(deselectedTextColor, deselectedImageColor);
        oldOption = currentOption;

        menuOptions[currentOption].UpdateColors(selectedTextColor, selectedImageColor);     
    }

    int GetMenuFormatedPointer(int pointer) {
        if(pointer < 0) {
            return menuOptions.Length - 1;
        }
        return pointer % menuOptions.Length;
    }
}
