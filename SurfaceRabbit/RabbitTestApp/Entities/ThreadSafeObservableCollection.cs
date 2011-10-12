using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using System.Threading;

// Taken from http://khason.net/blog/thread-safe-observable-collection/

namespace RabbitTestApp.Entities
{

  public class ThreadSafeObservableCollection<T> : ObservableCollection<T>
  {

    Dispatcher _dispatcher;
    ReaderWriterLock _lock;

    public ThreadSafeObservableCollection()
    {
      _dispatcher = Dispatcher.CurrentDispatcher;
      _lock = new ReaderWriterLock();
    }

    public ThreadSafeObservableCollection(Dispatcher d)
    {
      _dispatcher = d;
      _lock = new ReaderWriterLock();
    }

    protected override void ClearItems()
    {
      if (_dispatcher.CheckAccess())
      {
        LockCookie c = _lock.UpgradeToWriterLock(-1);
        base.ClearItems();
        _lock.DowngradeFromWriterLock(ref c);
      }
      else
      {
        _dispatcher.Invoke(DispatcherPriority.DataBind, (SendOrPostCallback)delegate { Clear(); });
      }
    }

    protected override void InsertItem(int index, T item)
    {
      if (_dispatcher.CheckAccess())
      {
        if (index > this.Count)
          return;
        LockCookie c = _lock.UpgradeToWriterLock(-1);
        base.InsertItem(index, item);
        _lock.DowngradeFromWriterLock(ref c);
      }
      else
      {
        object[] e = new object[] { index, item };
        _dispatcher.Invoke(DispatcherPriority.DataBind, (SendOrPostCallback)delegate { InsertItemImpl(e); }, e);
      }
    }

    void InsertItemImpl(object[] e)
    {
      if (_dispatcher.CheckAccess())
      {
        InsertItem((int)e[0], (T)e[1]);
      }
      else
      {
        _dispatcher.Invoke(DispatcherPriority.DataBind, (SendOrPostCallback)delegate { InsertItemImpl(e); });
      }
    }

    protected override void MoveItem(int oldIndex, int newIndex)
    {
      if (_dispatcher.CheckAccess())
      {
        if (oldIndex >= this.Count | newIndex >= this.Count | oldIndex == newIndex)
          return;
        LockCookie c = _lock.UpgradeToWriterLock(-1);
        base.MoveItem(oldIndex, newIndex);
        _lock.DowngradeFromWriterLock(ref c);
      }
      else
      {
        object[] e = new object[] { oldIndex, newIndex };
        _dispatcher.Invoke(DispatcherPriority.DataBind, (SendOrPostCallback)delegate { MoveItemImpl(e); }, e);
      }
    }

    void MoveItemImpl(object[] e)
    {
      if (_dispatcher.CheckAccess())
      {
        MoveItem((int)e[0], (int)e[1]);
      }
      else
      {
        _dispatcher.Invoke(DispatcherPriority.DataBind, (SendOrPostCallback)delegate { MoveItemImpl(e); });
      }
    }

    protected override void RemoveItem(int index)
    {
      if (_dispatcher.CheckAccess())
      {
        if (index >= this.Count)
          return;
        LockCookie c = _lock.UpgradeToWriterLock(-1);
        base.RemoveItem(index);
        _lock.DowngradeFromWriterLock(ref c);
      }
      else
      {
        _dispatcher.Invoke(DispatcherPriority.DataBind, (SendOrPostCallback)delegate { RemoveItem(index); }, index);
      }
    }

    protected override void SetItem(int index, T item)
    {
      if (_dispatcher.CheckAccess())
      {
        LockCookie c = _lock.UpgradeToWriterLock(-1);
        base.SetItem(index, item);
        _lock.DowngradeFromWriterLock(ref c);
      }
      else
      {
        object[] e = new object[] { index, item };
        _dispatcher.Invoke(DispatcherPriority.DataBind, (SendOrPostCallback)delegate { SetItemImpl(e); }, e);
      }
    }

    void SetItemImpl(object[] e)
    {
      if (_dispatcher.CheckAccess())
      {
        SetItem((int)e[0], (T)e[1]);
      }
      else
      {
        _dispatcher.Invoke(DispatcherPriority.DataBind, (SendOrPostCallback)delegate { SetItemImpl(e); });
      }
    }

    public ThreadSafeObservableCollection<T> GetCopy()
    {
      ThreadSafeObservableCollection<T> copyTSOC = new ThreadSafeObservableCollection<T>(_dispatcher);

      LockCookie c = _lock.UpgradeToWriterLock(-1);
      foreach (T objectT in this)
        copyTSOC.Add(objectT);
      _lock.DowngradeFromWriterLock(ref c);

      return copyTSOC;
    }

    public void GetCopy(ThreadSafeObservableCollection<T> copyTSOC)
    {
      //Adds new objects
      LockCookie c = _lock.UpgradeToWriterLock(-1);
      foreach (T objectT in this)
      {
        if (copyTSOC.Contains(objectT))
          continue;
        copyTSOC.Add(objectT);
      }
      _lock.DowngradeFromWriterLock(ref c);

      //Removes the non existing ones
      ThreadSafeObservableCollection<T> removeCopy = copyTSOC.GetCopy();
      foreach (T objectT in removeCopy)
      {
        if (Contains(objectT))
          continue;
        copyTSOC.Remove(objectT);
      }
    }

  }

}
