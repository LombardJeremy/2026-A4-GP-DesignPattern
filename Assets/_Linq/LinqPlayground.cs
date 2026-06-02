using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using Newtonsoft.Json;
using UnityEngine;

public class LinqPlayground : MonoBehaviour
{
    [SerializeField] TextAsset _jsonDocument;

    List<PokemonDto> LoadJson() => JsonConvert.DeserializeObject<List<PokemonDto>>(_jsonDocument.text);
    
    [Button]
    void Run()
    {
        var pokedex = LoadJson();
        Debug.Log("Pokedex loaded");

        print(pokedex.Count(i => i.Type.Contains("Psychic")));

         float GetHeight(PokemonDto pokemon) => float.Parse((pokemon.Profile.Height.Split(' ')[0]));
         var pokemon = pokedex
             .Where(i => i.Type.Contains("Electric"))
             .Aggregate((a, b) => GetHeight(a) > GetHeight(b) ? a : b);

        var auto = pokedex.OrderByDescending(pok => pok.Base.Attack + pok.Base.Defense).Take(10).ToList();

        foreach (var pok in auto)
        {
            print(pok.Name.French);
        }
        
    }
    
}
