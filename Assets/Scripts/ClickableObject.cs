using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableObject : MonoBehaviour
{
    public Text nomeItem;
    public IngredientData ingredient; // Referência ao Scriptable Object do ingrediente
    public SandwichBuilder sandwichBuilder; // Referência ao SandwichBuilder
    public AudioSource audioSource;
    public AudioClip ingredientSound;


    void OnMouseOver(){
        nomeItem.text = gameObject.name;

        if(Input.GetMouseButtonDown(0)){
            
            // Adicionar o ingrediente ao sanduíche
            sandwichBuilder.AddIngredientToSandwich(ingredient);
        }
    }

    private void OnMouseDown(){
        
        // Tocar o som do ingrediente quando o mouse clicar no objeto.
        audioSource.clip = ingredientSound;;
        audioSource.Play();
    }

    void OnMouseExit()
    {
        // Resetar o texto do nome do item quando o mouse sair do objeto.
        nomeItem.text = "";
    }
}
