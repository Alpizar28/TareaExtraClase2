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
        void MergeSorted(IList listA, IList listB, ListaDoble mergedList, SortDirection direction);


        Nodo GetFirstNode();
        void AdjustCentralNode();
        void Insert(int value);
        void MergeSortedAsceding(IList listA, IList listB, ListaDoble mergedList);

    }
}
