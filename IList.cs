namespace Tarea2
{
    public enum SortDirection
    {
        Asc,
        Desc
    }

    public interface IList
    {
        void InsertInOrder(int value);
        int DeleteFirst();
        int DeleteLast();
        bool DeleteValue(int value);
        int GetMiddle();
        int GetFirst();
        int GetLast();
        Nodo GetFirstNode();
        void MergeSorted(IList listA, IList listB, ListaDoble mergedList, SortDirection direction);
    }
}
