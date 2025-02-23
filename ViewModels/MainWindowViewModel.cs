using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Avalonia.Collections;

namespace AvaDic.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
  public AvaloniaDictionaryList<string, int> DataMap { get; set; } = new()
  {
    { "first", 1 },
    { "second", 2 },
    { "third", 3 },
    { "fourth", 4 },
  };

  public Dictionary<string, int> DataDict { get; set; } = new()
  {
    { "fifth", 5 },
    { "sixth", 6 },
    { "seventh", 7 },
    { "eighth", 8 },
  };

  public MainWindowViewModel()
  {
    DataMap.CollectionChanged += (_, _) => { Debug.WriteLine("ViewModel::CollectionChanged"); };
    DataMap.PropertyChanged += (_, _) => { Debug.WriteLine("ViewModel::PropertyChanged"); };
  }

  public void AddKey()
  {
    DataMap.Add(Guid.NewGuid().ToString(), 0);
    DataDict.Add(Guid.NewGuid().ToString(), 0);
  }
}

public class AvaloniaDictionaryList<TKey, TValue> : AvaloniaDictionary<TKey, TValue>, IList<KeyValuePair<TKey, TValue>> where TKey : notnull
{
  public int IndexOf(KeyValuePair<TKey, TValue> item)
  {
    throw new NotImplementedException();
    return Keys.ToList().IndexOf(item.Key);
  }

  public void Insert(int index, KeyValuePair<TKey, TValue> item)
  {
    throw new NotImplementedException();
    Add(item.Key, item.Value);
  }

  public void RemoveAt(int index)
  {
    throw new NotImplementedException();
    Keys.ToList().RemoveAt(index);
  }

  public KeyValuePair<TKey, TValue> this[int index]
  {
    get
    {
      throw new NotImplementedException();
      var key = Keys.ToList()[index];
      return new KeyValuePair<TKey, TValue>(key, this[key]);
    }

    set
    {
      throw new NotImplementedException();
      var key = Keys.ToList()[index];
      this[key] = value.Value;
    }
  }
}
