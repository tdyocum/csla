﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csla.Test.DataPortal
{
  [Serializable]
  public class MultipleDataAccess
    : MultipleDataAccessBase<MultipleDataAccess>
  {
    public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(c => c.Name);
    public string Name
    {
      get { return GetProperty(NameProperty); }
      set { SetProperty(NameProperty, value); }
    }

    public static readonly PropertyInfo<bool?> BooleanValueProperty = RegisterProperty<bool?>(c => c.BooleanValue);
    public bool? BooleanValue
    {
      get { return GetProperty(BooleanValueProperty); }
      set { SetProperty(BooleanValueProperty, value); }
    }
    public static readonly PropertyInfo<int?> IntValueProperty = RegisterProperty<int?>(c => c.IntValue);
    public int? IntValue
    {
      get { return GetProperty(IntValueProperty); }
      set { SetProperty(IntValueProperty, value); }
    }

    public static MultipleDataAccess GetMultiple(int id)
    {
      return Csla.DataPortal.Fetch<MultipleDataAccess>(id);
    }

    public static MultipleDataAccess GetMultiple()
    {
      return Csla.DataPortal.Fetch<MultipleDataAccess>();
    }

    public static MultipleDataAccess GetMultiple(int id, bool? value)
    {
      return Csla.DataPortal.Fetch<MultipleDataAccess>(id, value);
    }

    public static MultipleDataAccess GetMultiple(int id, int? value)
    {
      return Csla.DataPortal.Fetch<MultipleDataAccess>(id, value);
    }

    [Fetch]
    private void Fetch(int id)
    {
      using (BypassPropertyChecks)
      {
        base.Fetch(id);

        Name = "abc";
      }
    }

    [Fetch]
    private void Fetch(int id, bool? value)
    {
      using (BypassPropertyChecks)
      {
        base.Fetch(id);

        Name = "abc";
        BooleanValue = value;
      }
    }

    [Fetch]
    private void Fetch(int id, int? value)
    {
      using (BypassPropertyChecks)
      {
        base.Fetch(id);

        Name = "abc";
        IntValue = value;
      }
    }
  }
}