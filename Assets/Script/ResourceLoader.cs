using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader
{
    public CardCollectionSO GetCardCollectionSO(string themeName)
    {
        return Resources.Load<CardCollectionSO>(themeName);
    }
}
