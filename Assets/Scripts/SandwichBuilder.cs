using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SandwichBuilder : MonoBehaviour
{
    public MenuManager menuManager; // Referência ao MenuManager
    public List<IngredientData> selectedIngredients; // Lista de ingredientes selecionados
    
    public AudioSource successAudioSource;
    public AudioSource failureAudioSource;
    public AudioClip successSound;
    public AudioClip failureSound;

    public GameObject ingredientPrefab;
    public GameObject sandwichModelPrefab;

    private void Start()
    {
        selectedIngredients = new List<IngredientData>();
    }

    public void AddIngredientToSandwich(IngredientData ingredient)
    {
        float minX = 0.4f; // Valor mínimo de X
        float maxX = 0.930f; // Valor máximo de X
        float minY = 0.9f; // Valor mínimo de Y
        float maxY = 1.3f; // Valor máximo de Y
        float minZ = 1.08f; // Valor mínimo de Z
        float maxZ = 1.38f; // Valor máximo de Z
        float randomX = Random.Range(minX, maxX); // Valor aleatório de X
        float randomY = Random.Range(minY, maxY); // Valor aleatório de Y
        float randomZ = Random.Range(minZ, maxZ); // Valor aleatório de Z
        Quaternion randomRotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)); // Rotação aleatória

        // Adiciona o ingrediente à lista de ingredientes selecionados
        if (selectedIngredients.Count < 3){
            
            // Adiciona o ingrediente
            selectedIngredients.Add(ingredient);
            
            // Instancia o prefab do ingrediente em uma posição e rotação aleatória
            GameObject ingredientPrefab = ingredient.ingredientPrefab;
            Instantiate(ingredientPrefab, new Vector3(randomX, randomY, randomZ), randomRotation);
        }
        
        // Verifica se a lista de ingredientes selecionados tem 3 ingredientes
        if (selectedIngredients.Count == 3)
        {
            CheckSandwich();
        }
    }

    private void CheckSandwich()
    {
        foreach (SandwichData sandwich in menuManager.sandwiches)
        {
            // Verifica se a sequência de ingredientes corresponde ao sanduíche atual
            if (IsIngredientSequenceMatch(sandwich) && sandwich.ingredients.Length == 3)
            {
                // Cria o sanduíche
                CreateSandwich(sandwich);

                // Instancia o prefab do sanduíche
                Instantiate(sandwichModelPrefab, new Vector3(1.2892f, 2.319f, 1.058f), Quaternion.identity);
                
                // Limpa os prefabs de ingredientes utilizados no sanduíche
                foreach (GameObject ingredientObj in GameObject.FindGameObjectsWithTag("Ingredient"))
                    {
                    Destroy(ingredientObj);
                    }
                return;
            }
        }

        // Se a sequência de ingredientes não corresponde a nenhum sanduíche disponível        
        // "Descartar" os ingredientes, deixando eles jogados na cena
        foreach (GameObject ingredientObj in GameObject.FindGameObjectsWithTag("Ingredient"))
                    {
                    ingredientObj.tag = "Untagged";
                    }

        // Reseta o sanduíche            
        ResetSandwich();    
    }

    private bool IsIngredientSequenceMatch(SandwichData sandwich)
    {
        // Verifica se a sequência de ingredientes corresponde ao sanduíche atual
        if (selectedIngredients.Count != sandwich.ingredients.Length)
            return false;

        for (int i = 0; i < selectedIngredients.Count; i++)
        {
            if (selectedIngredients[i] != menuManager.currentSandwich.ingredients[i])
                return false;
        }

        return true;
    }

    private void CreateSandwich(SandwichData sandwich)
    {
        // Cria um sanduíche com os ingredientes selecionados
        SandwichData newSandwich = Instantiate(sandwich);
        newSandwich.ingredients = selectedIngredients.ToArray();

        // Toca o áudio de sucesso e aumenta a pontuação
        successAudioSource.clip = successSound;
        successAudioSource.Play();
        menuManager.IncreaseScore();

        // Limpa a lista de ingredientes selecionados para o próximo sanduíche
        selectedIngredients.Clear();
        menuManager.RequestRandomSandwich();
    }

    private void ResetSandwich()
    {
        // Toca o áudio de falha e diminui a pontuação
        failureAudioSource.clip = failureSound;
        failureAudioSource.Play();
        menuManager.DecreaseScore();

        //Limpa a lista de ingredientes selecionados para o próximo sanduíche
        selectedIngredients.Clear();
        menuManager.RequestRandomSandwich();
    }
}
